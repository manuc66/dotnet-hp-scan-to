using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [XmlRoot(ElementName = "Name", Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
    public class Name
    {
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}