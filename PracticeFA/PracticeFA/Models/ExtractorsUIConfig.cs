using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticeFA.Models
{
    /// <summary>
    /// The Extractors.
    /// </summary>
    [XmlRoot(ElementName = "Extractors")]

    public class ExtractorsUIConfig
    {
        /// <summary>
        /// The TextFeatureExtractor
        /// </summary>
        [XmlElement(ElementName = "TextFeatureExtractor")]
        public List<FeatureExtractor> TextFeatureExtractor { get; set; }

        /// <summary>
        /// The Numeric Feature Extractor
        /// </summary>
        [XmlElement(ElementName = "NumericFeatureExtractor")]
        public List<FeatureExtractor> NumericFeatureExtractor { get; set; }

        /// <summary>
        /// The Object Extractor
        /// </summary>
        [XmlElement(ElementName = "ObjectExtractor")]
        public List<FeatureExtractor> ObjectExtractor { get; set; }

        /// <summary>
        /// The Object Extractor
        /// </summary>
        [XmlElement(ElementName = "TextProcessor")]
        public List<FeatureExtractor> TextProcessor { get; set; }

        /// <summary>
        /// The Object Extractor
        /// </summary>
        [XmlElement(ElementName = "FunctionalProcessor")]
        public List<FeatureExtractor> FunctionalProcessor { get; set; }

        /// <summary>
        /// The BuiltInExtractor for Text
        /// </summary>
        [XmlElement(ElementName = "BuiltInTextFeatureExtractor")]
        public List<BuiltInExtractor> BuiltInTextFeatureExtractor { get; set; }

        /// <summary>
        /// The BuiltInExtractor for Numeric
        /// </summary>
        [XmlElement(ElementName = "BuiltInNumericExtractor")]
        public List<BuiltInExtractor> BuiltInNumericExtractor { get; set; }
    }
}
