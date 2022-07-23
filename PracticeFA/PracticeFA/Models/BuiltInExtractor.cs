using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticeFA.Models
{
    /// <summary>
    /// The class for Built In Extractors
    /// </summary>
    public class BuiltInExtractor
    {
        /// <summary>
        /// ParameterGroup for BuiltInExtractor
        /// </summary>
        [XmlElement(ElementName = "ParameterGroup")]
        public List<ParameterGroup> ParameterGroup { get; set; }

        /// <summary>
        /// The Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The Description
        /// </summary>
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }
    }
}
