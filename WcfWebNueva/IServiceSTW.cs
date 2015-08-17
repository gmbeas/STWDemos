using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WcfWebNueva
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceSTW
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "DemoNivelesJSON?tieid={tieid}&arbol={arbol}&nivel={nivel}"
            )]
        List<DemoNivelModel> DemoNiveles(int tieid, string arbol, string nivel);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetArbolCompletoV2JSON?tipo={tipo}&tieId={tieId}"
            )]
        List<ServiceSTW.ArbolPrefijoNivelv2> ArbolCompletoV2(string tipo, int tieid);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetArbolCompletoJSON?tipo={tipo}&tieId={tieId}"
            )]
        List<ArbolNivelCompleto> ArbolCompleto(string tipo, int tieid);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetArbolCeroJSON?tipo={tipo}&tieId={tieId}&arbol={arbol}&nivel={nivel}&codCliente={codCliente}&sku={sku}&subTipo={subTipo}&codPromo={codPromo}")]
        List<Arbol0Web> WPL_POW_Arbol(string tipo, int tieId, string arbol, int nivel, string codCliente, string sku, string subTipo, string codPromo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetAtributosJSON?tipo={tipo}&stock={stock}&disponible={disponible}&empresa={empresa}&prefijo={prefijo}&nroskus={nroskus}&tieId={tieId}&arbol={arbol}&arbolNivel={arbolNivel}&mbArtNom={mbArtNom}&mbFamCod={mbFamCod}&mbClaCod={mbClaCod}&mbMerCod={mbMerCod}&mbGrpCod={mbGrpCod}&prfId={prfId}&bodega={bodega}&busquedaExacta={busquedaExacta}&skuActivo={skuActivo}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&idAtrCliente={idAtrCliente}&codPromo={codPromo}")]
        List<ArbolAtributos> WPL_Sku_Atributos(string tipo, char stock, char disponible, string empresa, string prefijo,
            float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod,
            string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetAtributosNewJSON?tipo={tipo}&stock={stock}&disponible={disponible}&empresa={empresa}&prefijo={prefijo}&nroskus={nroskus}&tieId={tieId}&arbol={arbol}&arbolNivel={arbolNivel}&mbArtNom={mbArtNom}&mbFamCod={mbFamCod}&mbClaCod={mbClaCod}&mbMerCod={mbMerCod}&mbGrpCod={mbGrpCod}&prfId={prfId}&bodega={bodega}&busquedaExacta={busquedaExacta}&skuActivo={skuActivo}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&idAtrCliente={idAtrCliente}&codPromo={codPromo}")]
        List<ArbolAtributosNew> WPL_Sku_AtributosNew(string tipo, char stock, char disponible, string empresa, string prefijo,
            float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod,
            string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetProductosJSON?tipo={tipo}&stock={stock}&disponible={disponible}&empresa={empresa}&prefijo={prefijo}&nroskus={nroskus}&tieId={tieId}&arbol={arbol}&arbolNivel={arbolNivel}&mbArtNom={mbArtNom}&mbFamCod={mbFamCod}&mbClaCod={mbClaCod}&mbMerCod={mbMerCod}&mbGrpCod={mbGrpCod}&prfId={prfId}&bodega={bodega}&busquedaExacta={busquedaExacta}&skuActivo={skuActivo}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&idAtrCliente={idAtrCliente}&codPromo={codPromo}")]
        List<ArbolProductos> WPL_Sku_Atributos_Productos(string tipo, char stock, char disponible, string empresa,
            string prefijo, float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod,
            string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetFichaJSON?prefijo={prefijo}&tieId={tieId}&codPromo={codPromo}")]
        List<FichaProducto> WPL_Sku_Atributos_Ficha(string prefijo, int tieId, string codPromo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetMasCompradosJSON?tipo={tipo}&stock={stock}&disponible={disponible}&empresa={empresa}&prefijo={prefijo}&nroskus={nroskus}&tieId={tieId}&arbol={arbol}&arbolNivel={arbolNivel}&mbArtNom={mbArtNom}&mbFamCod={mbFamCod}&mbClaCod={mbClaCod}&mbMerCod={mbMerCod}&mbGrpCod={mbGrpCod}&prfId={prfId}&bodega={bodega}&busquedaExacta={busquedaExacta}&skuActivo={skuActivo}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&idAtrCliente={idAtrCliente}&codPromo={codPromo}")]
        List<ArbolMasComprados> WPL_Sku_Atributos_MasComprados(string tipo, char stock, char disponible, string empresa,
            string prefijo, float nroskus, int tieId, string arbol,
            int arbolNivel, string mbArtNom, string mbFamCod, string mbClaCod, string mbMerCod, string mbGrpCod,
            string prfId, string bodega, string busquedaExacta,
            int skuActivo, string fechaDesde, string fechaHasta, int idAtrCliente, string codPromo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "BusquedaJSON?busqueda={busqueda}&tieId={tieId}")]
        BusquedaModel WPL_Sku_Atributos_Busqueda(string busqueda, int tieId);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "AutentificaJSON?tipo={tipo}&rut={rut}&dv={dv}&clave={clave}&prfId={prfId}&rutDep={rutDep}&rutAdmin={rutAdmin}&nombre={nombre}&apeP={apeP}&apeM={apeM}&fantasia={fantasia}&eMail={eMail}&telefono={telefono}&celular={celular}&fax={fax}&sitioWeb={sitioWeb}&esEmpresa={esEmpresa}&esFactura={esFactura}&activo={activo}&usrId={usrId}")]
        Autentificacion Autentifica(string tipo, string rut, string dv, string clave, int prfId, string rutDep, string rutAdmin, string nombre, string apeP, string apeM, string fantasia,
            string eMail, string telefono, string celular, string fax, string sitioWeb, string esEmpresa, string esFactura, int activo, int usrId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetUsuarioWebJSON?tipo={tipo}&rut={rut}&dv={dv}&clave={clave}&prfId={prfId}&rutDep={rutDep}&rutAdmin={rutAdmin}&nombre={nombre}&apeP={apeP}&apeM={apeM}&fantasia={fantasia}&eMail={eMail}&telefono={telefono}&celular={celular}&fax={fax}&sitioWeb={sitioWeb}&esEmpresa={esEmpresa}&esFactura={esFactura}&activo={activo}&usrId={usrId}")]
        UsuarioWeb GetUsuarioWeb(string tipo, string rut, string dv, string clave, int prfId, string rutDep, string rutAdmin, string nombre, string apeP, string apeM, string fantasia,
            string eMail, string telefono, string celular, string fax, string sitioWeb, string esEmpresa, string esFactura, int activo, int usrId);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "RegistraUsuarioNaturalJSON?rut={rut}&dv={dv}&clave={clave}&nombre={nombre}&apeP={apeP}&apeM={apeM}&eMail={eMail}&telefono={telefono}&celular={celular}&fax={fax}&sitioWeb={sitioWeb}"
            )]
        RegistroUserModel RegistraUsuarioNatural(string rut, string dv, string clave, string nombre, string apeP, string apeM, string eMail, string telefono, string celular, string fax, string sitioWeb);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "RegistraContactoJSON?rut={rut}&nomcontacto={nomcontacto}&fono={fono}&email={email}"
            )]
        RegistroUserModel RegistraContacto(string rut, string nomcontacto, string fono, string email);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "RegistraDireccionJSON?rut={rut}&direccion={direccion}&codregion={codregion}&codciudad={codciudad}&codcomuna={codcomuna}"
            )]
        RegistroUserModel RegistraDireccion(string rut, string direccion, string codregion, string codciudad, string codcomuna);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "FichaClienteJSON?rut={rut}"
            )]
        FichaUsuarioModel FichaCliente(string rut);


        
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "CalculoTotalesJSON?prefijos={prefijos}&arbolId={arbolId}&idRegion={idRegion}&idCIudad={idCIudad}&rutCliente={rutCliente}&codPromo={codPromo}"
            )]
        FichaTotales CalculoTotales(string prefijos, string arbolId, string idRegion, string idCIudad, string rutCliente, string codPromo);


        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Xml,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    UriTemplate =
        //        "GeneralVentaXmlJSON?rutCliente={rutCliente}&skuValidos={skuValidos}&idDespacho={idDespacho}&idFacturacion={idFacturacion}&arbolId={arbolId}&idRegion={idRegion}&idCiudad={idCiudad}&codPromo={codPromo}"
        //    )]
        //XmlElement GeneralVentaXml(string rutCliente, string skuValidos, string idDespacho, string idFacturacion, string arbolId, string idRegion, string idCiudad, string codPromo);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GeneralVentaNotaPedidoJSON?rutCliente={rutCliente}&skuValidos={skuValidos}&arbolId={arbolId}&idRegion={idRegion}&idCiudad={idCiudad}"
            )]
        NotaVentaModel GeneralVentaNotaPedido(string rutCliente, string skuValidos, string arbolId, string idRegion, string idCiudad);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "FinalizaVentaJSON?nVenta={nVenta}&rutCliente={rutCliente}&skuValidos={skuValidos}&idDespacho={idDespacho}&idFacturacion={idFacturacion}&arbolId={arbolId}&idRegion={idRegion}&idCiudad={idCiudad}&codPromo={codPromo}&tbkAutorizacion={tbkAutorizacion}&tbkTarjeta={tbkTarjeta}&tbkTipoPago={tbkTipoPago}&tbkCuotas={tbkCuotas}"
            )]
        NotaVentaModel FinalizaVenta(string nVenta, string rutCliente, string skuValidos, string idDespacho, string idFacturacion, string arbolId, string idRegion, string idCiudad, string codPromo,
            string tbkAutorizacion, string tbkTarjeta, string tbkTipoPago, string tbkCuotas);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "TraeGruposJSON?tieId={tieId}&arbol={arbol}&prfId={prfId}"
            )]
        List<GruposModel> TraeGrupos(int tieId, string arbol, string prfId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "TraeAtributosJSON?tieId={tieId}&arbol={arbol}&prfId={prfId}&grpId={grpId}"
            )]
        List<AtributosModel> TraeAtributos(int tieId, string arbol, string prfId, string grpId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "ValidaSkuJSON?tieId={tieId}&sku={sku}"
            )]
        ValidaStockModel ValidaSku(int tieId, string sku);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "TraeGrupoAtributoJSON?tieId={tieId}&arbol={arbol}&prfId={prfId}"
            )]
        List<GrupoListModel> TraeGrupoAtributo(int tieId, string arbol, string prfId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "TraeSubCategoriaJSON?tieId={tieId}&arbol={arbol}"
            )]
        FinalCategoriaModel TraeSubCategoria(int tieId, string arbol);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate =
                "GetBannersJSON"
            )]
        BannerModel GetBanners();

    }

    [DataContract]
    public class DemoNivelModel
    {
         [DataMember]
        public string Nombre { get; set; }

         [DataMember]
        public int Niv_Id { get; set; }

         [DataMember]
        public int Nivel { get; set; }

         [DataMember]
        public string Arbol { get; set; }

         [DataMember]
        public int Prf_Id { get; set; }

         [DataMember]
        public int Tie_Id { get; set; }

         [DataMember]
        public int Tipo { get; set; }
    }



    [DataContract]
    public class BannerModel
    {
        [DataMember]
        public List<BannerGrandeModel> BannerGrande = new List<BannerGrandeModel>();

        [DataMember]
        public List<BannerChicoModel> BannerChico = new List<BannerChicoModel>();
    }

    [DataContract]
    public class BannerGrandeModel
    {
        [DataMember]
        public string Imagen { get; set; }

        [DataMember]
        public string Link { get; set; }
    }

    [DataContract]
    public class BannerChicoModel
    {
        [DataMember]
        public string Imagen { get; set; }

        [DataMember]
        public string Link { get; set; }
    }


    [DataContract]
    public class FinalCategoriaModel
    {
        [DataMember]
        public List<SubCateModel> Categoria = new List<SubCateModel>();

        [DataMember]
        public List<SubCategoriaModel> Subcategoria = new List<SubCategoriaModel>();
    }

    [DataContract]
    public class SubCateModel
    {
        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string PrfId { get; set; }
    }

    [DataContract]
    public class SubCategoriaModel
    {
        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string PrfId { get; set; }
    }


    [DataContract]
    public class GrupoListModel
    {
        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public string Grp_Id { get; set; }

        [DataMember]

        public List<AtributosModel> Atributos = new List<AtributosModel>();
    }


    [DataContract]
    public class ValidaStockModel
    {
        [DataMember]
        public string Flag { get; set; }

        [DataMember]
        public string Unidades { get; set; }

        [DataMember]
        public string UnidadesTotales { get; set; }

        [DataMember]
        public string StockDisponible { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }

    [DataContract]
    public class AtributosModel
    {
        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public string Grp_Id { get; set; }

        [DataMember]
        public string Atributo { get; set; }
    }

    [DataContract]
    public class GruposModel
    {
        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public string Grp_Id { get; set; }
    }


    [DataContract]
    public class NotaVentaModel
    {
        [DataMember]
        public string Ok { get; set; }

        [DataMember]
        public string Glosa { get; set; }
    }

    [DataContract]
    public class FichaTotales
    {
        [DataMember]

        public Totales Totales = new Totales();

        [DataMember]

        public List<Detalle> DetalleSku = new List<Detalle>();

    }


    [DataContract]
    public class Totales
    {
        [DataMember]
        public string Unidades { get; set; }

        [DataMember]
        public string Precio { get; set; }

        [DataMember]
        public string PrecioNeto { get; set; }

        [DataMember]
        public string TotalCompra { get; set; }

        [DataMember]
        public string PrecioBruto { get; set; }

        [DataMember]
        public string Iva { get; set; }

        [DataMember]
        public string IvaDespacho { get; set; }

        [DataMember]
        public string IvaFlete { get; set; }

        [DataMember]
        public string Flete { get; set; }

        [DataMember]
        public string FleteBruto { get; set; }
        
        [DataMember]
        public string Lista { get; set; }
    }

    [DataContract]
    public class Detalle
    {
        [DataMember]
        public string SkuId { get; set; }

        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string NombreSku { get; set; }

        [DataMember]
        public string NombreSkuCorto { get; set; }

        [DataMember]
        public string Stock { get; set; }

        [DataMember]
        public string Disponible { get; set; }

        [DataMember]
        public string Lista { get; set; }

        [DataMember]
        public string PrecioUnidad { get; set; }

        [DataMember]
        public string PrecioUnidadBruto { get; set; }

        [DataMember]
        public string Um { get; set; }

        [DataMember]
        public string FactorUm { get; set; }

        [DataMember]
        public string PrecioUm { get; set; }

        [DataMember]
        public string PrecioUMBruto { get; set; }

        [DataMember]
        public string Unidades { get; set; }

        [DataMember]
        public string UnidadesLisa { get; set; }

        [DataMember]
        public string Precio { get; set; }

        [DataMember]
        public string PrecioNeto { get; set; }

        [DataMember]
        public string TotalCompra { get; set; }

        [DataMember]
        public string PrecioBruto { get; set; }

        [DataMember]
        public string Iva { get; set; }

        [DataMember]
        public string Foto { get; set; }


    }


    #region FichaUsuarioModel
    [DataContract]
    public class FichaUsuarioModel
    {
        [DataMember]
        public string  MbAuxCod { get; set; }

        [DataMember]
        public string MbAuxDv { get; set; }

        [DataMember]
        public string MbAuxRaz { get; set; }

        [DataMember]
        public string MbGirDes { get; set; }

        [DataMember]
        public string GcCliBod { get; set; }

        [DataMember]

        public UsuarioWeb UsuarioWeb = new UsuarioWeb();

        [DataMember]

        public List<FichaUsuarioDireccion>  Direcciones = new List<FichaUsuarioDireccion>();

        [DataMember]

        public List<FichaUsuarioContacto> Contactos = new List<FichaUsuarioContacto>();
    }

    [DataContract]
    public class FichaUsuarioDireccion
    {
        [DataMember]
        public string MbAuxCod { get; set; }

        [DataMember]
        public string MbDirCod { get; set; }

        [DataMember]
        public string MbDirDes { get; set; }

        [DataMember]
        public string MbDirReg { get; set; }

        [DataMember]
        public string MbDirCiu { get; set; }

        [DataMember]
        public string MbDirCom { get; set; }

        [DataMember]
        public string MbRegNom { get; set; }

        [DataMember]
        public string MbCiuNom { get; set; }

        [DataMember]
        public string MbZonNom { get; set; }
    }

    [DataContract]
    public class FichaUsuarioContacto
    {
        [DataMember]
        public string MbAuxCod { get; set; }

        [DataMember]
        public string MbAuxCtoLi { get; set; }

        [DataMember]
        public string MbAuxCtoNo { get; set; }

        [DataMember]
        public string MbAuxCtoTe { get; set; }

        [DataMember]
        public string MbAuxCtoMa { get; set; }
    }
    #endregion

    #region RegistroUserModel
    [DataContract]
    public class RegistroUserModel
    {
        [DataMember]
        public string Flag { get; set; }

        [DataMember]
        public int Usr_Id { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
    #endregion


    [DataContract]
    public class BusquedaModel
    {
        [DataMember]
        public List<BusquedaProductosModel> Productos = new List<BusquedaProductosModel>();

        [DataMember]
        public List<ListPrefijo> Prefijos = new List<ListPrefijo>();

        [DataMember]
        public List<LineaUno> LineaProductos = new List<LineaUno>();
    }

     [DataContract]
    public class ListPrefijo
    {
          [DataMember]
        public string Prefijo { get; set; }
          [DataMember]
        public string PrefId { get; set; }
          [DataMember]
        public string Nivel { get; set; }

          [DataMember]
        public List<ListGrupo> Grupo = new List<ListGrupo>();
    }

    [DataContract]
     public class LineaUno
     {
        [DataMember]
         public string Atributo { get; set; }
        [DataMember]
         public string AtdId { get; set; }
     }

    [DataContract]
     public class ListGrupo
     {
        [DataMember]
         public string Grupo { get; set; }
        [DataMember]

         public List<ListAtributo> Atributo = new List<ListAtributo>();
     }


    [DataContract]
     public class ListAtributo
     {
        [DataMember]
         public string Atributo { get; set; }
        [DataMember]
         public string AtdId { get; set; }
     }

    #region BusquedaProductosModel
    [DataContract]
    public class BusquedaProductosModel
    {
        [DataMember]
        public string SkuId { get; set; }

        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string NombreSku { get; set; }

        [DataMember]
        public string NombreWeb { get; set; }

        [DataMember]
        public string Stock { get; set; }

        [DataMember]
        public string Disponible { get; set; }

        [DataMember]
        public string Lista { get; set; }

        [DataMember]
        public string PrecioUnidad { get; set; }

        [DataMember]
        public string PrecioUnidadNeto { get; set; }

        [DataMember]
        public string Um { get; set; }

        [DataMember]
        public string FactorUm { get; set; }

        [DataMember]
        public string Precio { get; set; }

        [DataMember]
        public string PrecioNeto { get; set; }

        [DataMember]
        public string Foto { get; set; }

        [DataMember]
        public string IndStock { get; set; }

        [DataMember]
        public string PrfId { get; set; }

        
    }
    #endregion

    #region UsuarioWeb
    [DataContract]
    public class UsuarioWeb
    {
        [DataMember]
        public string Flag { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Rut { get; set; }

        [DataMember]
        public string Dv { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string Fantasia { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string ApeP { get; set; }

        [DataMember]
        public string ApeM { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string SitioWeb { get; set; }

        [DataMember]
        public string EsEmpresa { get; set; }

        [DataMember]
        public string EsFactura { get; set; }
    }
    #endregion

    #region Autentificacion
    [DataContract]
    public class Autentificacion
    {
        [DataMember]
        public string Flag { get; set; }

        [DataMember]
        public string UsrId { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
    #endregion

    #region FichaProducto
    [DataContract]
    public class FichaProducto
    {
        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string Texto { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public string Atributo { get; set; }

        [DataMember]
        public int Flag { get; set; }

        [DataMember]
        public string Mensaje { get; set; }    

        [DataMember]
        public string SkuId { get; set; }
    }
    #endregion

    #region ArbolCompleto
    [DataContract]
    public class ArbolCompleto
    {
        [DataMember]
        public string Orden { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string NavId { get; set; }

        [DataMember]
        public string Nivel { get; set; }

        [DataMember]
        public string Arbol { get; set; }

        [DataMember]
        public string ArbolRama { get; set; }

        [DataMember]
        public string ArbId { get; set; }

        [DataMember]

        public string PrfId { get; set; }
        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string FotoArbol { get; set; }

        [DataMember]
        public string TieId { get; set; }

        [DataMember]
        public string Tipo { get; set; }
    }
    #endregion

    #region ArbolNivelCompleto
    [DataContract]
    public class ArbolNivelCompleto
    {
        [DataMember]
        public string Arbol { get; set; }

        [DataMember]
        public string ArbolId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<ArbolNivel3> Nivel = new List<ArbolNivel3>();
    }
    #endregion

    [DataContract]
    public class ArbolNivelPrefijo
    {
        [DataMember]
        public string Arbol { get; set; }

        [DataMember]
        public string ArbolId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<ArbolNivelPrefijoNivel> Nivel = new List<ArbolNivelPrefijoNivel>();

        [DataMember]
        public List<Prefijo> Prefjo = new List<Prefijo>();
    }

    [DataContract]
    public class ArbolNivelPrefijoNivel
    {
        [DataMember]
        public string Arbol { get; set; }

        [DataMember]
        public string ArbolId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<Prefijo> Prefjo = new List<Prefijo>();
    }

    [DataContract]
    public class Prefijo
    {
        [DataMember]
        public string Arbol { get; set; }
       
        [DataMember]
        public string Nombre { get; set; }
    }


    [DataContract]
    public class ArbolNivel
    {
        [DataMember]
        public string Arbol { get; set; }

        [DataMember]
        public string ArbolId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string NavId { get; set; }
    }

    [DataContract]
    public class ArbolNivel3
    {
        [DataMember]
        public string Arbol { get; set; }

        [DataMember]
        public string ArbolId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<ArbolNivel> Nivel = new List<ArbolNivel>();
    }

    #region ArbolAtributosNew
    [DataContract]
    public class ArbolAtributosNew
    {
        [DataMember]
        public int Ok { get; set; }

        [DataMember]
        public string PrefId { get; set; }

        [DataMember]
        public int Nivel { get; set; }

        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public int AtdId { get; set; }

        [DataMember]
        public int GrpId { get; set; }

        [DataMember]
        public string Atributo { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public int Disponible { get; set; }

        [DataMember]
        public string EsLinea { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public string FotoPrefijo { get; set; }

        [DataMember]
        public string FotoArbol { get; set; }

        [DataMember]
        public int Tipo { get; set; }
    }
    #endregion

    #region ArbolAtributos
    [DataContract]
    public class ArbolAtributos
    {
        [DataMember]
        public int Ok { get; set; }

        [DataMember]
        public string PrefId { get; set; }

        [DataMember]
        public int Nivel { get; set; }

        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public int AtdId { get; set; }

        [DataMember]
        public string Atributo { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public int Disponible { get; set; }

        [DataMember]
        public string EsLinea { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public string FotoPrefijo { get; set; }

        [DataMember]
        public string FotoArbol { get; set; }

        [DataMember]
        public int Tipo { get; set; }
    }
    #endregion

    #region ArbolProductos
    [DataContract]
    public class ArbolProductos
    {
        [DataMember]
        public int Activo { get; set; }

        [DataMember]
        public int SkuId { get; set; }

        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string NombreSku { get; set; }

        [DataMember]
        public string NombreWeb { get; set; }

        [DataMember]
        public string Stock { get; set; }

        [DataMember]
        public int Disponible { get; set; }

        [DataMember]
        public int Lista { get; set; }

        [DataMember]
        public double PrecioUnidad { get; set; }

        [DataMember]
        public double PrecioUnidadBruto { get; set; }

        [DataMember]
        public int FactorUm { get; set; }

        [DataMember]
        public string Um { get; set; }

        [DataMember]
        public int Unidades { get; set; }

        [DataMember]
        public double Precio { get; set; }

        [DataMember]
        public double PrecioBruto { get; set; }

        [DataMember]
        public double Iva { get; set; }

        [DataMember]
        public string Foto { get; set; }

        [DataMember]
        public int TotalProductos { get; set; }
    }
    #endregion      

    #region Arbol0Web
    [DataContract]
    public class Arbol0Web
    {
        [DataMember]
        public int Arbol { get; set; }

        [DataMember]
        public int Nivel { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string FotoArbol { get; set; }

        [DataMember]
        public int TieId { get; set; }

        [DataMember]
        public int NivId { get; set; }
    }
    #endregion

    #region ArbolMasComprados
    [DataContract]
    public class ArbolMasComprados
    {
        [DataMember]
        public int SkuId { get; set; }

        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string NombreSku { get; set; }

        [DataMember]
        public string Stock { get; set; }

        [DataMember]
        public int Lista { get; set; }

        [DataMember]
        public double PrecioUnidad { get; set; }

        [DataMember]
        public string Um { get; set; }

        [DataMember]
        public string FactorUm { get; set; }

        [DataMember]
        public double Precio { get; set; }

        [DataMember]
        public string Foto { get; set; }      
    }
    #endregion
    
}
