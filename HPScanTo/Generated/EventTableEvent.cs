using System;
using System.Xml.Serialization;

namespace HPScanTo.Generated
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.hp.com/schemas/imaging/con/ledm/events/2007/09/16")]
    public class EventTableEvent
    {

        [XmlElement(Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public string UnqualifiedEventCategory { get; set; }

        [XmlElement(Namespace = "http://www.hp.com/schemas/imaging/con/dictionaries/1.0/")]
        public string AgingStamp { get; set; }
    }
}