using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScanRedHardwareSoftware
{
    class Program
    {
        private static bool onlyPI = false;
        private static CancellationTokenSource cts = new CancellationTokenSource();
        static void Main(string[] args)
        {

            string yol = "e:\\mac.txt";
            ArrayList arrText = new ArrayList();
            string yedek = null;
            string ip = "192.168.30.";
            bool durum = File.Exists(yol);
            if (durum == true)
            {
                StreamReader objReader = new StreamReader("e:\\mac.txt");
                string oku = "";
                while (oku != null)
                {
                    oku = objReader.ReadLine();
                    if (oku != null)
                        arrText.Add(oku);
                }
                objReader.Close();
                //kontroll
                for (int i = 1; i < 50; i++)
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(ip + i);
                    yedek = pingReply.Status.ToString().Trim();
                    if (yedek.Equals("Success"))
                    {
                        foreach (string eleman in arrText)
                        {
                            int k = eleman.IndexOf("\\");
                            string deneme = eleman.Substring(0, k);
                            if (eleman.Equals(ip + i + "\\" + GetMacAddress(ip + i)) && (ip + i).Equals(deneme))
                            {
                                Console.WriteLine(eleman + " correctamente con MAC ");
                            }
                            if ((ip + i).Equals(deneme) && !eleman.Equals(ip + i + "\\" + GetMacAddress(ip + i)))
                            {
                                Console.WriteLine(eleman + " mac está con problemas ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(ip + i + " no utilizado en la red");
                    }
                }
            }
            else
            {
                for (int i = 1; i < 50; i++)
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(ip + i);
                    yedek = pingReply.Status.ToString().Trim();
                    if (yedek.Equals("Success"))
                    {
                        var macAddress = GetMacAddress(ip + i);
                        StreamWriter SW = File.AppendText("e:\\mac.txt");
                        SW.WriteLine(ip + i + "\\" + macAddress);
                        SW.Close();
                    }
                    else
                    {
                        Console.WriteLine(ip + i + " no utilizado en la red");
                    }
                }
            }
            Console.ReadLine();

            //Console.CancelKeyPress += Console_CancelKeyPress;
           
            //var onlyPIParams = new string[] { "-o", "/o", "-onlypi", "/onlypi" };
            //var helpParams = new string[] { "-h", "/h", "-help", "/help" };
            //for (var i = 0; i < args.Count(); i++)
            //{
            //    if (helpParams.Contains(args[i].ToLowerInvariant()))
            //    {
            //        Console.WriteLine(string.Format("Usage : {0} [IP] [-a|-all] [-h|-help]", System.AppDomain.CurrentDomain.FriendlyName));
            //        Console.WriteLine("IP: The IP you want check using 0.0.0.0 format (ex: 192.168.1.1 10.0.0.1). We'll check all the machines on the same network.");
            //        Console.WriteLine(string.Format("{0}: Display the parameters help", string.Join("|", helpParams)));
            //        Console.WriteLine(string.Format("{0}: List only Raspberry PI machines. By default, all machines will be listed.", string.Join("|", onlyPIParams)));
            //        return;
            //    }
            //    else if (onlyPIParams.Contains(args[i].ToLowerInvariant()))
            //    {
            //        onlyPI = true;
            //    }
            //    else
            //    {
            //        IPAddress paramIP;
            //        if (IPAddress.TryParse(args[i], out paramIP))
            //        {
            //            IPAddressHelper.ScanMac(ScanOutput, cts.Token, paramIP);
            //        }
            //    }
            //}
            //IPAddressHelper.ScanMac(ScanOutput, cts.Token);

            //Console.ReadKey(false);
        }


        private static string GetMacAddress(string strAddress)
        {
            var inetAddr = inet_addr(strAddress);
            uint addressLen = 16;
            var macAddress = new byte[addressLen];
            if (SendARP(inetAddr, 0, macAddress, ref addressLen) == 0)
            {
                var sb = new StringBuilder();
                for (var index = 0; index < addressLen; index++)
                {
                    if (index > 0)
                    {
                        sb.Append("-");
                    }
                    sb.Append(
                        string.Format(
                            "{0:X}",
                            macAddress[index]).PadLeft(2, '0'));
                }
                return sb.ToString();
            }
            throw new Exception("SendARP call failed.");
        }
        [DllImport("Ws2_32.dll", CharSet = CharSet.Ansi)]
        private static extern uint inet_addr(string address);
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(
            uint destinationIp,
            uint sourceIp,
            byte[] macAddress,
            ref uint addressLen);


        static void ScanOutput(IPAddress ip, string mac)
        {
            //All Raspberry PI MAC address start with the same prefix
            var spotted = mac.ToString().ToUpper().StartsWith("B8:27:EB");
            if ((onlyPI && spotted) || !onlyPI)
                Console.WriteLine(string.Format("IP={0} MAC={1}{2}", ip, mac, spotted ? " <- Raspberry PI spotted !!!" : ""));
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            cts.Cancel();
        }
    }
}
