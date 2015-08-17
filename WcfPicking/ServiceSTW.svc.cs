using System.Collections.Generic;
using System.Data;
using System.Linq;
using WcfPicking.Content;

namespace WcfPicking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSTW : IServiceSTW
    {
       
        public List<NotaPedido>  WPA_NotasPedido(string tipo, int folio, char actividad, string cadenainsert, string cadenaupdate, string codcliente, string fechad, string fechah,
            string fechaev, string ordencompra, string estado, string sku, string bodega)
            {
                var ds = DbGeneral.WPA_NotasPedido(tipo, folio, actividad, cadenainsert, cadenaupdate, codcliente, fechad, fechah, fechaev, ordencompra, estado, sku, bodega);
                var listado = (from DataRow dr in ds.Tables[0].Rows
                               select new NotaPedido
                               {
                                   Selec = int.Parse(dr["Selec"].ToString().Trim()),
                                   Fecauto = dr["FEC/AUTO"].ToString(),
                                   Nronv = dr["NRO NV"].ToString().Trim(),
                                   MontoNeto = double.Parse(dr["MONTO NETO"].ToString().Trim()),
                                   Estado = dr["ESTADO"].ToString().Trim(),
                                   Bodega = int.Parse(dr["BODEGA"].ToString().Trim()),
                                   Cliente = dr["CLIENTE"].ToString().Trim(),
                                   RazonSocial = dr["RAZON SOCIAL"].ToString().Trim(),
                                   NombreFantasia = dr["NOMB/FANTASIA"].ToString().Trim(),
                                   Dias = dr["DIAS"].ToString().Trim() == "" ? 0 : int.Parse(dr["DIAS"].ToString().Trim()),
                                   Vendedor = dr["VENDEDOR"].ToString().Trim(),
                                   Sede = dr["SEDE"].ToString().Trim(),
                                   EnvioFact = int.Parse(dr["ENVIO FACT"].ToString().Trim()),
                                   Fact = int.Parse(dr["FACT"].ToString().Trim()),
                                   OrdenCompra = dr["ORDEN COMPRA"].ToString().Trim()
                               }).ToList();

                return listado.ToList();
            }

        public List<LPar> WPA_LPAR(string tipo)
        {
            var ds = DbGeneral.WPA_NotasPedido(tipo, 0, 'A', "", "", "", "", "", "", "", "", "", "");
            return (from DataRow dr in ds.Tables[0].Rows
                select new LPar
                {
                    Valor = dr["Valor"].ToString()
                }).ToList();
        }

        public List<LBod> WPA_LBOD(string tipo)
        {
            var ds = DbGeneral.WPA_NotasPedido(tipo, 0, 'A', "", "", "", "", "", "", "", "", "", "");
            return (from DataRow dr in ds.Tables[0].Rows
                select new LBod
                {
                    Bodega = dr["Bodega"].ToString().Trim()
                }).ToList();
        }

        public List<LEmp> WPA_LEMP(string tipo)
        {
            var ds = DbGeneral.WPA_NotasPedido(tipo, 0, 'A', "", "", "", "", "", "", "", "", "", "");
             return (from DataRow dr in ds.Tables[0].Rows
                select new LEmp
                {
                    MbEprCod = dr["MbEprCod"].ToString(),
                    Nombre = dr["Nombre"].ToString()
                }).ToList();
        }

        public List<LSedLVen> WPA_LSED_LVEN(string tipo)
        {
            var ds = DbGeneral.WPA_NotasPedido(tipo, 0, 'A', "", "", "", "", "", "", "", "", "", "");
            return (from DataRow dr in ds.Tables[0].Rows
                select new LSedLVen
                {
                    Id = dr["Id"].ToString(),
                    Nombre = dr["Nombre"].ToString()
                }).ToList();
        }

        public Prueba WPL_GeneraPicking(string tipo, string listaNv)
        {
            var ds = DbGeneral.WPL_GeneraPicking(tipo, listaNv);

            var tabla1 = ds.Tables[0];
            var tabla2 = ds.Tables[1];
            var tabla3 = ds.Tables[2];


            var li = new Prueba();
            foreach (DataRow dr in tabla1.Rows)
            {
                 li.Dato1.Add(new Tabla1()
                 {
                     DatoTabla1 = "ctm"
                 });
            }

            foreach (DataRow dr in tabla2.Rows)
            {
                li.Dato2.Add(new Tabla2
                {
                    DatoTabla2 = "ctm"
                });
            }

            foreach (DataRow dr in tabla3.Rows)
            {
                li.Dato3.Add(new Tabla3
                {
                    DatoTabla3 ="ctm"
                });
            }


            return li;
        }
    }
}
