using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticeFA.Models
{
    /// <summary>
    /// The Extractor Parameter.
    /// </summary>
    [XmlRoot(ElementName = "Parameter")]

    public class Parameter
    {
        /// <summary>
        /// The Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The Template
        /// </summary>
        [XmlAttribute(AttributeName = "template")]
        public Template Template { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The Description
        /// </summary>
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The Value
        /// </summary>
        [XmlElement(ElementName = "Value")]
        public List<string> AllowedValues { get; set; }

        /// <summary>
        /// The Default
        /// </summary>
        [XmlAttribute(AttributeName = "default")]
        public string Default { get; set; }

        /// <summary>
        /// The MinValue
        /// </summary>
        [XmlAttribute(AttributeName = "minValue")]
        public string MinValue { get; set; }

        /// <summary>
        /// The MaxValue
        /// </summary>
        [XmlAttribute(AttributeName = "maxValue")]
        public string MaxValue { get; set; }
    }
}
