using System.Collections.Generic;
using System.Linq;
using WcfCambioUbicacion.Content;

namespace WcfCambioUbicacion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSTW : IServiceSTW
    {
        public UsuarioRolModel Autenficacion(string usuario, string passwd)
        {
            var dato = DBGeneral.ValidaUsuario(usuario, passwd);
            var c = dato.FirstOrDefault();
            var lst = new UsuarioRolModel();
            if (c == '-')
            {
                lst.Mensaje = dato.Replace("-", "");
                lst.Estado = 2;
            }
            else
            {
                var info = dato.Split('.');
                lst.Estado = 1;
                lst.Id = int.Parse(info[0].Trim());
                lst.Nombre = info[1].Trim();
            }
            
            return lst;
        }

        public RolModel ValidaRol(string usuario, int rolPerfil)
        {
            var dato = DBGeneral.ValidaRol(usuario, rolPerfil);
            var lst = new RolModel {EsRol = dato};
            return lst;
        }

        public List<BodegasModel> WPL_ListaBodegas()
        {
            var ds = DBGeneral.WPL_ListaBodegas("STE");
            var lst = ds.Tables[0].ToList<BodegasModel>();
            return lst;
        }

        public List<OkValorModel> CambioDeUbicacionPaso1(string bodega, string origen)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("VO", "STE", bodega, origen, "", "", "", 0);
            var lst = ds.Tables[0].ToList<OkValorModel>();
            return lst;
        }

        public List<NombreTablaModel> CambioDeUbicacionPaso2(string usuario)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("T", usuario, "", "", "", "", "", 0);
            var lst = ds.Tables[0].ToList<NombreTablaModel>();
            return lst;
        }

        public List<OkValorModel> CambioDeUbicacionPaso3(string sku)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("VR", "STE", sku, "", "", "", "", 0);
            var lst = ds.Tables[0].ToList<OkValorModel>();
            return lst;
        }

        public List<OkValorModel> CambioDeUbicacionPaso4(string sku)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("VS", "STE", sku, "", "", "", "", 0);
            var lst = ds.Tables[0].ToList<OkValorModel>();
            return lst;
        }

        public List<OkValorModel> CambioDeUbicacionPaso5(string bodega, string origen, string sku)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("VU", "STE", bodega, origen, sku, "", "", 0);
            var lst = ds.Tables[0].ToList<OkValorModel>();
            return lst;
        }

        public List<OkMensajeStockConteoCantidadModel> CambioDeUbicacionPaso6(string tabla, string bodega, string origen, string sku)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("VK", tabla, "STE", bodega, origen, "",sku, 0);
            var lst = ds.Tables[0].ToList<OkMensajeStockConteoCantidadModel>();
            return lst;
        }

        public List<OkMensajeStockConteoCantidadModel> CambioDeUbicacionPaso7(string tabla, string bodega, string origen, string sku, int cantidad)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("S", tabla, "STE", bodega, origen, "", sku, cantidad);
            var lst = new List<OkMensajeStockConteoCantidadModel>();
            return lst;
        }

        public List<OkValorModel> CambioDeUbicacionPaso8(string bodega, string origen)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("VO", "STE", bodega, origen, "", "", "", 0);
            var lst = ds.Tables[0].ToList<OkValorModel>();
            return lst;
        }

        public List<BodegasModel> CambioDeUbicacionPaso9(string tabla, string bodega, string destino)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("AD", tabla, "STE", bodega, destino, "", "", 0);
            var lst = new List<BodegasModel>();
            return lst;
        }

        public List<FlagFinal> CambioDeUbicacionPaso10(string tabla, string bodega, string origen, string destino, string usuario)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("C", tabla, "STE", bodega, origen, destino, usuario, 0);
            var lst = ds.Tables[0].ToList<FlagFinal>();
            return lst;
        }

        public List<StockBodegaUbi> StockBodegaUbicacion(string bodega, string sku)
        {
            var ds = DBGeneral.WPL_StockBodegaUbicacion("STE", bodega, sku);
            var lst = ds.Tables[0].ToList<StockBodegaUbi>();
            return lst;
        }

        public List<PrecioModel> PrecioSku(string sku)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("P500A", sku, "","","","","",0);
            var info = ds.Tables[0].ToList<PrecioModel>();
            return info;
        }

        public List<SkuUbicacionModel> SkuUbicacion(string bodega, string ubicacion)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("STOCK", bodega, ubicacion, "", "", "", "", 0);
            var lst = ds.Tables[0].ToList<SkuUbicacionModel>();
            return lst;
        }

        public List<UbicacionesModel> Ubicaciones(string bodega)
        {
            var ds = DBGeneral.WPA_CambioDeUbicacion("UBIC", bodega, "", "", "", "", "", 0);
            var lst = ds.Tables[0].ToList<UbicacionesModel>();
            return lst;
        }
    }
}
