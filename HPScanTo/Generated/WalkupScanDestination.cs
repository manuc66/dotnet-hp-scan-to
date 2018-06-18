using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [XmlRoot(ElementName="WalkupScanDestination", Namespace="http://www.hp.com/schemas/imaging/con/rest/walkupscan/2009/09/21")]
    public class WalkupScanDestination {
        [XmlElement(ElementName="ResourceURI", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public string ResourceURI { get; set; }
        [XmlElement(ElementName="Name", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public string Name { get; set; }
        [XmlElement(ElementName="Hostname", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/2009/04/06")]
        public string Hostname { get; set; }
        [XmlElement(ElementName="LinkType", Namespace="http://www.hp.com/schemas/imaging/con/rest/walkupscan/2009/09/21")]
        public string LinkType { get; set; }
    }
}