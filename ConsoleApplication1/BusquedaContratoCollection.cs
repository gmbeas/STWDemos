﻿using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable()]
    public class TablaContrato
    {
        [XmlElement("Tipo")]
        public string Tipo { get; set; }

        [XmlElement("Folio")]
        public string Folio { get; set; }

        [XmlElement("Estado")]
        public string Estado { get; set; }

        [XmlElement("CodCliente")]
        public string CodCliente { get; set; }

        [XmlElement("RazonSocial")]
        public string RazonSocial { get; set; }

        [XmlElement("Contacto")]
        public string Contacto { get; set; }

        [XmlElement("Patente")]
        public string Patente { get; set; }

        [XmlElement("EstadoWop")]
        public string EstadoWop { get; set; }

        [XmlElement("EST_Id")]
        public string EstId { get; set; }

        [XmlElement("Direccion")]
        public string Direccion { get; set; }

        [XmlElement("Ciudad")]
        public string Ciudad { get; set; }

        [XmlElement("Comuna")]
        public string Comuna { get; set; }

        [XmlElement("Dir1")]
        public string Dir1 { get; set; }

    }

    [Serializable()]
    [XmlRoot("NewDataSet", Namespace = "")]
    public class BusquedaContrato
    {
        [XmlElement("Table", typeof(TablaContrato))]
        public TablaContrato[] TablaContrato { get; set; }
    }
}
