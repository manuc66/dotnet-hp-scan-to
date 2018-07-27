using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [XmlRoot(ElementName = "WalkupScanDestination",
        Namespace = "http://www.hp.com/schemas/imaging/con/cnx/walkupscan/2009/09/21")]
    public class WalkupScanDestinationPost
    {
        [XmlElement(ElementName = "Hostname",
            Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/2009/04/06")]
        public Hostname Hostname { get; set; }

        [XmlElement(ElementName = "Name", Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public Name Name { get; set; }

        [XmlElement(ElementName = "LinkType",
            Namespace = "http://www.hp.com/schemas/imaging/con/cnx/walkupscan/2009/09/21")]
        public string LinkType { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }

        public static WalkupScanDestinationPost CreateFrom(string hostname, string name)
        {
            var walkupScanDestinationPost = new WalkupScanDestinationPost
            {
                Hostname = new Hostname {Text = hostname},
                Name = new Name {Text = name},
                LinkType = "Network"
            };
            return walkupScanDestinationPost;
        }

        public string SerializeToXml()
        {
            var serializer = new XmlSerializer(typeof(WalkupScanDestinationPost));
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, this);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}