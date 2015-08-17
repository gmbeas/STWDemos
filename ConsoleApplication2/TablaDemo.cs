using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication2
{

    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {

        private rootTable tableField;

        /// <remarks/>
        public rootTable table
        {
            get
            {
                return this.tableField;
            }
            set
            {
                this.tableField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootTable
    {

        private rootTableTR[] tbodyField;

        /// <remarks/>
        [XmlArrayItemAttribute("tr", IsNullable = false)]
        public rootTableTR[] tbody
        {
            get
            {
                return this.tbodyField;
            }
            set
            {
                this.tbodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootTableTR
    {

        private rootTableTRTD[] tdField;

        private rootTableTRTH[] thField;

        private string classField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("td")]
        public rootTableTRTD[] td
        {
            get
            {
                return this.tdField;
            }
            set
            {
                this.tdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("th")]
        public rootTableTRTH[] th
        {
            get
            {
                return this.thField;
            }
            set
            {
                this.thField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootTableTRTD
    {

        private string textField;

        private rootTableTRTDA aField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public rootTableTRTDA a
        {
            get
            {
                return this.aField;
            }
            set
            {
                this.aField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootTableTRTDA
    {

        private string textField;

        private string hrefField;

        private string targetField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootTableTRTH
    {

        private string textField;

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }


}
