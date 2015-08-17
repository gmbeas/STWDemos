using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Rebex.Legacy;
using Rebex.Net;

namespace RespaldoFTPServerBD
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("Cargando parametros...");
            var dsFtp = DbGeneral.GetFtpParametros();
            var lstFtp = dsFtp.Tables[0].ToList<FtpParametros>();
            var serverC = Properties.Settings.Default.Server;
            var baseC = Properties.Settings.Default.Base;
            var datoBases = baseC.Split(',');

            for (int x = 0; x < datoBases.Count(); x++)
            {
                Console.WriteLine("Backup para BD..." + datoBases[x]);
                var dsParam = DbGeneral.GetServerParametros(serverC, datoBases[x]);

                var lstParam = dsParam.Tables[0].ToList<ServerParametros>();
                Console.WriteLine("Parametros cargados...");

                //create FTP client
                Ftp client = new Ftp();

                //Connect to the FTP server
                client.Connect(lstFtp[0].Ip);
                //authorize to the server
                client.Login(lstFtp[0].User, lstFtp[0].Pass);

                Console.WriteLine("Conectado al ftp...");

                for (int i = 0; i < int.Parse(lstFtp[0].Reintentos); i++)
                {
                    string[] filePaths = Directory.GetFiles(lstParam[0].LocalFolder, "*.bak");
                    Console.WriteLine(filePaths.Count() + " archivos encontrados");
                    if (filePaths.Any())
                    {
                        for (int j = 0; j < filePaths.Count(); j++)
                        {
                            var fileName = Path.GetFileName(filePaths[j]);
                            Console.WriteLine("Procesando archivo " + fileName);
                            var archivoFtpUpload = "/" + lstParam[0].FtpFolder + "/" + fileName;
                            var fileExiste = client.FileExists(archivoFtpUpload);
                            var archivoLocalMover = filePaths[j];

                            var archivoRemoteFolder = lstParam[0].RemoteFolder + "/" + fileName;

                            if (!fileExiste)
                            {
                                Console.WriteLine("Cargando archivo... " + fileName);
                                long uploadLength = client.PutFile(archivoLocalMover, archivoFtpUpload);

                                long remoteLength = client.GetFileLength(archivoFtpUpload);
                                long localLength = new FileInfo(archivoLocalMover).Length;

                                var sigue = true;
                                if (uploadLength != localLength || remoteLength != localLength)
                                {
                                    Console.WriteLine("Archivo cargado con errores... " + fileName);
                                    sigue = false;
                                    DbGeneral.InsertaLog("Tamaño kb de archivos diferente", "ERROR UPLOAD", fileName, datoBases[x]);
                                }


                                if (sigue)
                                {
                                    //consulta checksum
                                    try
                                    {
                                        Console.WriteLine("Validando checksum " + fileName);
                                        var localChecksum = Ftp.CalculateLocalChecksum(FtpChecksumType.MD5,
                                            archivoLocalMover);
                                        var uploadfileChecksum = Ftp.CalculateLocalChecksum(FtpChecksumType.MD5,
                                            archivoRemoteFolder);
                                        if (localChecksum.Equals(uploadfileChecksum))
                                        {
                                            Console.WriteLine("Procesando cargado con exito " + fileName);
                                            try
                                            {
                                                File.Delete(archivoLocalMover);
                                            }
                                            catch (Exception e)
                                            {
                                                DbGeneral.InsertaLog("No se pudo eliminar archivo local", "Inesperado", fileName, datoBases[x]);
                                                Console.WriteLine("Error Inesperado " + e.ToString());
                                                //Console.ReadLine();
                                            }

                                            DbGeneral.InsertaLog(
                                                "Upload correcto, se procede a eliminar archivo local","UPLOAD OK", fileName, datoBases[x]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Archivo cargado con errores " + fileName);
                                            client.DeleteFile(archivoFtpUpload);
                                            DbGeneral.InsertaLog(
                                                "CheckSum de archivos diferente, se procede a eliminar archivo cargado", "ERROR UPLOAD", fileName, datoBases[x]);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Ocurrio un error inesperado " + fileName);
                                        Console.WriteLine(e.ToString());
                                        //Console.ReadLine();
                                        //DbGeneral.InsertaLog("Error inesperado: " + e.ToString(), "TryCatch");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Archivo ya se encuentra en destino " + fileName);
                                DbGeneral.InsertaLog("Archivo ya se encuentra en destino", "Duplicado", fileName, datoBases[x]);
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }
    }
}
