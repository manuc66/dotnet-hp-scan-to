using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [XmlRoot(ElementName="WalkupScanDestinations", Namespace="http://www.hp.com/schemas/imaging/con/rest/walkupscan/2009/09/21")]
    public class WalkupScanDestinations {
        [XmlElement(ElementName="Version", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public Version Version { get; set; }
        [XmlElement(ElementName="MaxNetworkDestinations", Namespace="http://www.hp.com/schemas/imaging/con/rest/walkupscan/2009/09/21")]
        public string MaxNetworkDestinations { get; set; }
        [XmlElement(ElementName="WalkupScanDestination", Namespace="http://www.hp.com/schemas/imaging/con/rest/walkupscan/2009/09/21")]
        public List<WalkupScanDestination> WalkupScanDestination { get; set; }
        [XmlAttribute(AttributeName="schemaLocation", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName="dd", Namespace="http://www.w3.org/2000/xmlns/")]
        public string Dd { get; set; }
        [XmlAttribute(AttributeName="dd3", Namespace="http://www.w3.org/2000/xmlns/")]
        public string Dd3 { get; set; }
        [XmlAttribute(AttributeName="scantype", Namespace="http://www.w3.org/2000/xmlns/")]
        public string Scantype { get; set; }
        [XmlAttribute(AttributeName="wus", Namespace="http://www.w3.org/2000/xmlns/")]
        public string Wus { get; set; }
        [XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        
        public static WalkupScanDestinations CreateFromStream(Stream inStream)
        {
            var serializer = new XmlSerializer(typeof(WalkupScanDestinations));
            return (WalkupScanDestinations)serializer.Deserialize(inStream);

        }
    }
}