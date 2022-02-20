using System;
using System.IO;
using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.hp.com/schemas/imaging/con/ledm/events/2007/09/16")]
    [XmlRoot(Namespace = "http://www.hp.com/schemas/imaging/con/ledm/events/2007/09/16", IsNullable = false)]
    public class EventTable
    {
        [XmlElement(Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public Version Version { get; set; }

        [XmlElement("Event")]
        public EventTableEvent[] Event { get; set; }


        public static EventTable CreateFromStream(Stream inStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EventTable));
            return (EventTable)serializer.Deserialize(inStream);
        }
    }
}