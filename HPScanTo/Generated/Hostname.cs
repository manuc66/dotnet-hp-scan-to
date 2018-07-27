using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [XmlRoot(ElementName = "Hostname", Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/2009/04/06")]
    public class Hostname
    {
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}