using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlFileReadingAndWriting
{
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class LanguageLocaleMappings
    {
        [XmlElementAttribute("LanguageLocaleMapping")]
        public LanguageLocaleMappingsLanguageLocaleMapping[] LanguageLocaleMapping { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true)]
    public partial class LanguageLocaleMappingsLanguageLocaleMapping
    {
        private string defaultLocaleField;
        private string[] supportedLocalsField;
        private string iso6391LanguageCodeField;

        public string DefaultLocale
        {
            get
            {
                return (defaultLocaleField);
            }
            set
            {
                this.defaultLocaleField = value;
            }
        }

        [XmlArrayItemAttribute("Locale", IsNullable = false)]
        public string[] SupportedLocals
        {
            get
            {
                return this.supportedLocalsField;
            }
            set
            {
                this.supportedLocalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("iso639-1LanguageCode")]
        public string iso6391LanguageCode
        {
            get
            {
                return this.iso6391LanguageCodeField;
            }
            set
            {
                this.iso6391LanguageCodeField = value;
            }
        }
    }


}
