using System.Xml.Serialization;

namespace HPScanTo.Generated
{
	[XmlRoot(ElementName="Version", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
	public class Version {
		[XmlElement(ElementName="Revision", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
		public string Revision { get; set; }
		[XmlElement(ElementName="Date", Namespace="http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
		public string Date { get; set; }
	}
}