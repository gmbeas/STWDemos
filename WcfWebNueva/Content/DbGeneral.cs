using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfWebNueva.Content
{
    public static class DbGeneral
    {
        public static DataSet WPL_LeeParametrosAdminWeb(string tipo, string llave1, string llave2, string llave3, string valor, int tipoPromo)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@Llave1", llave1),
                new SqlParameter("@Llave2", llave2),
                new SqlParameter("@Llave3", llave3),
                new SqlParameter("@Valor", valor),
                new SqlParameter("@TipoPromo", tipoPromo),

            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_LeeParametrosAdminWeb", commandParameters);
            return results;
        }

        public static string GetSkuId(string codigo)
        {
            var sqlStr = "  Select Id From WTE_Sku Where SKU = '"+ codigo +"'";
            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.Text, sqlStr);
            if (results.Tables[0].Rows.Count > 0)
            {
                var dr = results.Tables[0].Rows[0];
                return dr["Id"].ToString();
            }
            else
            {
                return "";
            }
               
        }


        public static DataSet WS_CONSULTA_CLIENTE(string MbEprCod, string MbAuxRut, int Tipo)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@MbEprCod", MbEprCod),
                new SqlParameter("@MbAuxRut", MbAuxRut),
                new SqlParameter("@Tipo", Tipo)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WS_CONSULTA_CLIENTE", commandParameters);
            return results;
        }


        public static DataSet WS_AGREGA_DIRECCION(string MbEprCod, string MbAuxCod, string MbDirDes, string MbDirReg, string MbDirCiu, string MbDirCom,
           string RequiereDirFact)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@MbEprCod", MbEprCod),
                new SqlParameter("@MbAuxCod", MbAuxCod),
                new SqlParameter("@MbDirDes", MbDirDes),
                new SqlParameter("@MbDirReg", MbDirReg),
                new SqlParameter("@MbDirCiu", MbDirCiu),
                new SqlParameter("@MbDirCom", MbDirCom),
                new SqlParameter("@RequiereDirFact", RequiereDirFact)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WS_AGREGA_DIRECCION", commandParameters);
            return results;
        }


        public static DataSet WS_AGREGA_CONTACTO(string MBEPRCOD, string MBAUXCOD, string MBAUXCTONO, string MBAUXCTOTI, string MBAUXCTOTE, string MBAUXCTOFA,
            string MBAUXCTOMA, string MBAUXCTOCI, string MBAUXCTOTP, string MBAUXCTODI)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@MBEPRCOD", MBEPRCOD),
                new SqlParameter("@MBAUXCOD", MBAUXCOD),
                new SqlParameter("@MBAUXCTONO", MBAUXCTONO),
                new SqlParameter("@MBAUXCTOTI", MBAUXCTOTI),
                new SqlParameter("@MBAUXCTOTE", MBAUXCTOTE),
                new SqlParameter("@MBAUXCTOFA", MBAUXCTOFA),
                new SqlParameter("@MBAUXCTOMA", MBAUXCTOMA),
                new SqlParameter("@MBAUXCTOCI", MBAUXCTOCI),
                new SqlParameter("@MBAUXCTOTP", MBAUXCTOTP),
                new SqlParameter("@MBAUXCTODI", MBAUXCTODI)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WS_AGREGA_CONTACTO", commandParameters);
            return results;
        }


        public static DataSet WS_AGREGA_CLIENTE(string MbEprCod, string MbAuxRut, string MbAuxrdv, string MbAuxRaz, string MbAuxFan, int MbGirCod, 
            int GcCliLpr, int MbCliLprAr, int MbCliLprRe, int MbCliVenOf, string TipoCliente)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@MbEprCod", MbEprCod),
                new SqlParameter("@MbAuxRut", MbAuxRut),
                new SqlParameter("@MbAuxrdv", MbAuxrdv),
                new SqlParameter("@MbAuxRaz", MbAuxRaz),
                new SqlParameter("@MbAuxFan", MbAuxFan),
                new SqlParameter("@MbGirCod", MbGirCod),
                new SqlParameter("@GcCliLpr", GcCliLpr),
                new SqlParameter("@MbCliLprAr", MbCliLprAr),
                new SqlParameter("@MbCliLprRe", MbCliLprRe),
                new SqlParameter("@MbCliVenOf", MbCliVenOf),
                new SqlParameter("@TipoCliente", TipoCliente)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionAlpha(), CommandType.StoredProcedure, "WS_AGREGA_CLIENTE", commandParameters);
            return results;
        }

        public static DataSet WPL_POW_Usuarios(string tipo, string rut, string dv, string clave, int prfId, string rutDep, string rutAdmin, string nombre, string apeP, string apeM, string fantasia,
            string eMail, string telefono, string celular, string fax, string sitioWeb, string esEmpresa, string esFactura, int activo, int usrId)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@RUT", rut),
                new SqlParameter("@DV", dv),
                new SqlParameter("@Clave", clave),
                new SqlParameter("@PRF_Id", prfId),
                new SqlParameter("@RUT_Dep", rutDep),
                new SqlParameter("@RUT_Admin", rutAdmin),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@ApeP", apeP),
                new SqlParameter("@ApeM", apeM),
                new SqlParameter("@Fantasia", fantasia),
                new SqlParameter("@EMail", eMail),
                new SqlParameter("@Telefono", telefono),
                new SqlParameter("@Celular", celular),
                new SqlParameter("@Fax", fax),
                new SqlParameter("@SitioWeb", sitioWeb),
                new SqlParameter("@EsEmpresa", esEmpresa),
                new SqlParameter("@EsFactura", esFactura),
                new SqlParameter("@Activo", activo),
                new SqlParameter("@USR_Id", usrId)     
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_POW_Usuarios", commandParameters);
            return results;
        }

    


        //http://localhost:14059/ServiceSTW.svc/GetArbolCeroJSON?tipo=NV0&tieId=24&arbol=&nivel=0&codCliente=&sku=&subTipo=&codPromo=
        public static DataSet WPL_POW_Arbol(string Tipo_, int TIE_Id_, string Arbol_, int Nivel_, string CodCliente_, string SKU_, string SubTipo_, string CodPromo_)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo_", Tipo_),
                new SqlParameter("@TIE_Id_", TIE_Id_),
                new SqlParameter("@Arbol_", Arbol_),
                new SqlParameter("@Nivel_", Nivel_),
                new SqlParameter("@CodCliente_", CodCliente_),
                new SqlParameter("@SKU_", SKU_),
                new SqlParameter("@SubTipo_", SubTipo_),
                new SqlParameter("@CodPromo_", CodPromo_)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_POW_Arbol", commandParameters);
            return results;
        }

        public static DataSet WPL_Sku_Atributos(string Tipo_, char Stock_, char Disponible_, string empresa_, string prefijo_,
            float nroskus_, int TIE_Id_, string Arbol_, int ArbolNivel_, string MbArtNom_, string MbFamCod_, string MbClaCod_, string MbMerCod_, string MbGrpCod_, string PRF_Id_, string Bodega_,
            string BusquedaExacta_, int SKUActivo_, string FechaDesde_, string FechaHasta_, int IdAtrCliente_, string CodPromo_)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo_", Tipo_),
                new SqlParameter("@Stock_", Stock_),
                new SqlParameter("@Disponible_", Disponible_),
                new SqlParameter("@empresa_", empresa_),
                new SqlParameter("@prefijo_", prefijo_),
                new SqlParameter("@nroskus_", nroskus_),
                new SqlParameter("@TIE_Id_", TIE_Id_),
                new SqlParameter("@Arbol_", Arbol_),
                new SqlParameter("@ArbolNivel_", ArbolNivel_),
                new SqlParameter("@MbArtNom_", MbArtNom_),
                new SqlParameter("@MbFamCod_", MbFamCod_),
                new SqlParameter("@MbClaCod_", MbClaCod_),
                new SqlParameter("@MbMerCod_", MbMerCod_),
                new SqlParameter("@MbGrpCod_", MbGrpCod_),
                new SqlParameter("@PRF_Id_", PRF_Id_),
                new SqlParameter("@Bodega_", Bodega_),
                new SqlParameter("@BusquedaExacta_", BusquedaExacta_),
                new SqlParameter("@SKUActivo_", SKUActivo_),
                new SqlParameter("@FechaDesde_", FechaDesde_),
                new SqlParameter("@FechaHasta_", FechaHasta_),
                new SqlParameter("@IdAtrCliente_", IdAtrCliente_),
                new SqlParameter("@CodPromo_", CodPromo_)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_Sku_Atributos", commandParameters);
            return results;
        }


        public static DataSet ArbolCompleto(string Tipo_, int TIE_Id_, string Arbol_, int Nivel_, string CodCliente_, string SKU_, string SubTipo_, string CodPromo_)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo_", Tipo_),
                new SqlParameter("@TIE_Id_", TIE_Id_),
                new SqlParameter("@Arbol_", Arbol_),
                new SqlParameter("@Nivel_", Nivel_),
                new SqlParameter("@CodCliente_", CodCliente_),
                new SqlParameter("@SKU_", SKU_),
                new SqlParameter("@SubTipo_", SubTipo_),
                new SqlParameter("@CodPromo_", CodPromo_)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "WPL_POW_Arbol", commandParameters);
            return results;
        }


        public static DataSet POS_ActualizaCabecera(string Tipo, string Empresa, string BodegaLisa, string CajaLisa, string TipoDocLisa, string Folio, string Fecha_Emi, string CodVendedor, string CodCliente,
            string ListaPrecio, string EST_Id, string USE_Id, string MND_Id, string Descuento1, string Descuento2, string Descuento3, string Donacion, string TDCREF_Id, string FolioRef,
            string Observaciones, string UsuarioUlt, string generada, string PreVenta, string CodPromo, string DIR_Desp, string DIR_Fact, string CC_Id, string ADM_Id, string CLI_Id, string OrdenCompra, string Enlace)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Empresa", Empresa),
                new SqlParameter("@BodegaLisa", BodegaLisa),
                new SqlParameter("@CajaLisa", CajaLisa),
                new SqlParameter("@TipoDocLisa", TipoDocLisa),
                new SqlParameter("@Folio", Folio),
                new SqlParameter("@Fecha_Emi", Fecha_Emi),
                new SqlParameter("@CodVendedor", CodVendedor),
                new SqlParameter("@CodCliente", CodCliente),
                new SqlParameter("@ListaPrecio", ListaPrecio),
                new SqlParameter("@EST_Id", EST_Id),
                new SqlParameter("@USE_Id", USE_Id),
                new SqlParameter("@MND_Id", MND_Id),
                new SqlParameter("@Descuento1", Descuento1),
                new SqlParameter("@Descuento2", Descuento2),
                new SqlParameter("@Descuento3", Descuento3),
                new SqlParameter("@Donacion", Donacion),
                new SqlParameter("@TDCREF_Id", TDCREF_Id),
                new SqlParameter("@FolioRef", FolioRef),
                new SqlParameter("@Observaciones", Observaciones),
                new SqlParameter("@UsuarioUlt", UsuarioUlt),
                new SqlParameter("@generada", generada),
                new SqlParameter("@PreVenta", PreVenta),
                new SqlParameter("@CodPromo", CodPromo),
                new SqlParameter("@DIR_Desp", DIR_Desp),
                new SqlParameter("@DIR_Fact", DIR_Fact),
                new SqlParameter("@CC_Id", CC_Id),
                new SqlParameter("@ADM_Id", ADM_Id),
                new SqlParameter("@CLI_Id", CLI_Id),
                new SqlParameter("@OrdenCompra", OrdenCompra),
                new SqlParameter("@Enlace", Enlace)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "POS_ActualizaCabecera", commandParameters);
            return results;
        }


        public static DataSet POS_ActualizaDetalle(string Tipo, string Empresa, string BodegaLisa, string CajaLisa, string TipoDocLisa, string Folio, string SKU, string UM, string Cantidad,
           string Descuento1, string Descuento2, string Descuento3, string precio, string CodPromo)
        {
            var commandParameters = new SqlParameter[]
            {
                new SqlParameter("@Tipo", Tipo),
                new SqlParameter("@Empresa", Empresa),
                new SqlParameter("@BodegaLisa", BodegaLisa),
                new SqlParameter("@CajaLisa", CajaLisa),
                new SqlParameter("@TipoDocLisa", TipoDocLisa),
                new SqlParameter("@Folio", Folio),
                new SqlParameter("@SKU", SKU),
                new SqlParameter("@UM", UM),
                new SqlParameter("@Cantidad", Cantidad),
                new SqlParameter("@Descuento1", Descuento1),
                new SqlParameter("@Descuento2", Descuento2),
                new SqlParameter("@Descuento3", Descuento3),
                new SqlParameter("@precio", precio),
                new SqlParameter("@CodPromo", CodPromo)
            };

            var results = SqlHelper.ExecuteDataset(Conexion.CadenaConexionDelta(), CommandType.StoredProcedure, "POS_ActualizaDetalle", commandParameters);
            return results;
        }


    }
}