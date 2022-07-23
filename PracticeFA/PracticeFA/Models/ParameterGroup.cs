using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticeFA.Models
{
    /// <summary>
    /// The ParameterGroup
    /// </summary>
    [XmlRoot(ElementName = "ParameterGroup")]

    public class ParameterGroup
    {
        /// <summary>
        /// The Parameter
        /// </summary>
        [XmlElement(ElementName = "Parameter")]
        public List<Parameter> Parameter { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
