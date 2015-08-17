using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace prueba
{

    [Serializable()]
    public class Articulo
    {
        [XmlElement("ArticuloCod")]
        public string ArticuloCod { get; set; }

        [XmlElement("UsoEnvase")]
        public string UsoEnvase { get; set; }

        [XmlElement("Preciovta")]
        public string Preciovta { get; set; }

        [XmlElement("Dscto_Linea")]
        public string Dscto_Linea { get; set; }

        [XmlElement("Dscto_Linea1")]
        public string Dscto_Linea1 { get; set; }

        [XmlElement("Dscto_Linea2")]
        public string Dscto_Linea2 { get; set; }

        [XmlElement("Dscto_Linea3")]
        public string Dscto_Linea3 { get; set; }

        [XmlElement("Umevta_Cant")]
        public string Umevta_Cant { get; set; }

        [XmlElement("Umevta")]
        public string Umevta { get; set; }

        [XmlElement("Linea_OC_Cli")]
        public string Linea_OC_Cli { get; set; }

        [XmlElement("Comision")]
        public string Comision { get; set; }

        [XmlElement("Flete")]
        public string Flete { get; set; }
    }



    [Serializable()]
    [XmlRoot("NotaPedido", Namespace = "LisaWs70")]
    public class NotaPedido
    {
        [XmlElement("Empresa")]
        public string Empresa { get; set; }

        [XmlElement("Fecha_Emision")]
        public string Fecha_Emision { get; set; }

        [XmlElement("Fecha_Despacho")]
        public string Fecha_Despacho { get; set; }

        [XmlElement("Fecha_Orden")]
        public string Fecha_Orden { get; set; }

        [XmlElement("Usuario")]
        public string Usuario { get; set; }

        [XmlElement("VolumDscto_NP")]
        public string VolumDscto_NP { get; set; }

        [XmlElement("PorcDscto_Pago")]
        public string PorcDscto_Pago { get; set; }

        [XmlElement("PorcDscto_Especial")]
        public string PorcDscto_Especial { get; set; }

        [XmlElement("Recargo")]
        public string Recargo { get; set; }

        [XmlElement("FormaFacturar_NP")]
        public string FormaFacturar_NP { get; set; }

        [XmlElement("Indica_UsoTcambio")]
        public string Indica_UsoTcambio { get; set; }

        [XmlElement("Lprecio_Paridad")]
        public string Lprecio_Paridad { get; set; }

        [XmlElement("Paridad")]
        public string Paridad { get; set; }

        [XmlElement("Pagado")]
        public string Pagado { get; set; }

        [XmlElement("SucursalCliente")]
        public string SucursalCliente { get; set; }

        [XmlElement("Obs_NotaPedido")]
        public string Obs_NotaPedido { get; set; }

        [XmlElement("MontoNeto_NP")]
        public string MontoNeto_NP { get; set; }

        [XmlElement("MontoExento_NP")]
        public string MontoExento_NP { get; set; }

        [XmlElement("Sede")]
        public string Sede { get; set; }

        [XmlElement("CentroGestion_NP")]
        public string CentroGestion_NP { get; set; }

        [XmlElement("Vendedor")]
        public string Vendedor { get; set; }

        [XmlElement("Lprecio")]
        public string Lprecio { get; set; }

        [XmlElement("Auxiliar")]
        public string Auxiliar { get; set; }

        [XmlElement("Contacto")]
        public string Contacto { get; set; }

        [XmlElement("Dir_Despacho")]
        public string Dir_Despacho { get; set; }

        [XmlElement("Direccion_Factura")]
        public string Direccion_Factura { get; set; }

        [XmlElement("Bodega")]
        public string Bodega { get; set; }

        [XmlElement("Departamento")]
        public string Departamento { get; set; }

        [XmlElement("Moneda")]
        public string Moneda { get; set; }

        [XmlElement("Tipodespacho_NP")]
        public string Tipodespacho_NP { get; set; }

        [XmlElement("Tipo_transporte")]
        public string Tipo_transporte { get; set; }

        [XmlElement("Concepto_Venta")]
        public string Concepto_Venta { get; set; }

        [XmlElement("Termino_Pago")]
        public string Termino_Pago { get; set; }

        [XmlElement("OrdenCompra")]
        public string OrdenCompra { get; set; }


        [XmlArray("Articulos")]
        [XmlArrayItem("Articulo", typeof(Articulo))]
        public Articulo[] Articulo { get; set; }
    }

}
