using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using WcfTablet.Content;

namespace WcfTablet
{
    public class ServiceSTW : IServiceSTW
    {

        public Login ValidaLogin(string user, string pass)
        {
            var ds = DbGeneral.WPL_ValidaUsuario(user, pass);
            var info = new Login();
            var dr = ds.Tables[0].Rows[0];
            var valida = dr[0].ToString();
            var xx = valida.Substring(0, 1);
            if (xx != "-")
            {
                var datos = valida.Split('|');
                info.Id = int.Parse(datos[0]);
                info.Nombre = datos[1];
                info.Email = datos[3].Replace("|", "");
                info.Valida = 1;
                info.Respuesta = "OK";
            }
            else
            {
                info.Valida = 2;
                info.Respuesta = valida;
            }

            return info;
        }

        public List<Contratos> GetContratos(string tipo, int folio, int cliente, string fechad, string fechah, string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop, string tipoarrvta, string solofletes)
        {
            var ds = DbGeneral.WPL_POW_EntregaRetiro(tipo, folio, cliente,  fechad,  fechah,  sku,  nombrefoto, movid,  cadena, usrid,  patente,  estwop,  tipoarrvta,  solofletes);

            var listado = new List<Contratos>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string thumb = @"http://192.168.30.250/entrega.jpg";
                if (dr["Tipo"].Equals("RETIRO")) 
                    thumb = @"http://192.168.30.250/retiro.jpg";

                listado.Add(new Contratos
                {
                    Tipo = dr["Tipo"].ToString().Trim(),
                    Folio = int.Parse(dr["Folio"].ToString()),
                    Estado = dr["Estado"].ToString().Trim(),
                    CodCliente = dr["CodCliente"].ToString().Trim(),
                    RazonSocial = dr["RazonSocial"].ToString().Trim(),
                    Contacto = dr["Contacto"].ToString().Trim(),
                    Telefono = dr["Telefono"].ToString().Trim(),
                    Direccion = dr["Direccion"].ToString().Trim(),
                    Ciudad = dr["Ciudad"].ToString().Trim(),
                    Comuna = dr["Comuna"].ToString().Trim(),
                    FechaEntrega = dr["FechaEntrega"].ToString().Trim(),
                    FechaRetiro = dr["FechaRetiro"].ToString().Trim(),
                    Entregado = dr["Entregado"].ToString().Trim(),
                    Devuelto = dr["Devuelto"].ToString().Trim(),
                    PorRecibir = dr["Por Recibir"].ToString().Trim(),
                    M3 = dr["M3"].ToString().Trim(),
                    UnidadxRack = dr["UnidxRack"].ToString().Trim(),
                    M3Rack = dr["M3Rack"].ToString().Trim(),
                    NroRacks = dr["NroRacks"].ToString().Trim(),
                    Flete = dr["Flete"].ToString().Trim(),
                    Horario = dr["Horario"].ToString().Trim(),
                    Hora = dr["Hora"].ToString().Trim(),
                    Cli1 = dr["Cli1"].ToString().Trim(),
                    Cli2 = dr["Cli2"].ToString().Trim(),
                    Dir1 = dr["Dir1"].ToString().Trim(),
                    Dir2 = dr["Dir2"].ToString().Trim(),
                    Patente = dr["Patente"].ToString().Trim(),
                    EstId = dr["EST_Id"].ToString().Trim(),
                    EstadoWop = dr["EstadoWop"].ToString().Trim(),
                    Observaciones = dr["Observaciones"].ToString().Trim(),
                    Thumbnail = thumb //new JavaScriptSerializer().Serialize(thumb)
                });
            }

            return listado.ToList();
        }

        public List<MovimientosContrato> GetMovimientos(string tipo, int folio, int cliente, string fechad, string fechah,
            string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop,
            string tipoarrvta, string solofletes)
        {
            var ds = DbGeneral.WPL_POW_EntregaRetiro(tipo, folio, cliente, fechad, fechah, sku, nombrefoto, movid, cadena, usrid, patente, estwop, tipoarrvta, solofletes);

            return (from DataRow dr in ds.Tables[0].Rows
                select new MovimientosContrato
                {
                    NroMov = int.Parse(dr["Nro Mov"].ToString()), Fecha = dr["Fecha"].ToString(), Estado = dr["Estado"].ToString(), Usuario = dr["Usuario"].ToString(), UsrId = int.Parse(dr["USR_Id"].ToString()), EstId = int.Parse(dr["EST_Id"].ToString()), FlagFoto = int.Parse(dr["FlagFoto"].ToString()), FlagFirma = int.Parse(dr["FlagFirma"].ToString()), EstId1 = int.Parse(dr["EST_Id1"].ToString()), Estado1 = dr["Estado1"].ToString(), MovRef = dr["MovRef"].ToString(), FolioRef = int.Parse(dr["FolioRef"].ToString())
                }).ToList();
        }

        public List<NuevoMovimiento> NewMovimiento(string tipo, int folio, int cliente, string fechad, string fechah,
            string sku, string nombrefoto, int movid, string cadena, int usrid, string patente, string estwop,
            string tipoarrvta, string solofletes)
        {
            var ds = DbGeneral.WPL_POW_EntregaRetiro(tipo, folio, cliente, fechad, fechah, sku, nombrefoto, movid, cadena, usrid, patente, estwop, tipoarrvta, solofletes);

            return (from DataRow dr in ds.Tables[0].Rows
                select new NuevoMovimiento
                {
                    Sku = dr["SKU"].ToString(), Descripcion = dr["Descripcion"].ToString(), Total = int.Parse(dr["Total"].ToString()), Recibido = int.Parse(dr["Recibido"].ToString()), ARecibir = int.Parse(dr["A Recibir"].ToString()), NombreFoto = dr["NombreFoto"].ToString(), Id = int.Parse(dr["Id"].ToString()), Sku1 = dr["Sku1"].ToString(), Sku2 = dr["Sku2"].ToString()
                }).ToList();
        }
    }
}
