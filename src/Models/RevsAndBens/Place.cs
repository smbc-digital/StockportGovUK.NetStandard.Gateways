using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("Places")]
    public class Place
    {
        [XmlElement("PlaceRef")]
        public string PlaceReference { get; set; }
        [XmlElement("Address1")]
        public string Address1 { get; set; }
        [XmlElement("Address2")]
        public string Address2 { get; set; }
        [XmlElement("Address3")]
        public string Address3 { get; set; }
        [XmlElement("Address4")]
        public string Address4 { get; set; }
        [XmlElement("Address5")]
        public string Address5 { get; set; }
        [XmlElement("PostCode")]
        public string PostCode { get; set; }
        [XmlElement("Band")]
        public Band Band { get; set; }
        [XmlElement("FullYearCharge")]
        public string FullYearCharge { get; set; }
        [XmlElement("CurrentYrFullYearCharge")]
        public string CurrentYearFullYearCharge { get; set; }
        [XmlElement("PropertyStatus")]
        public string Status { get; set; }
    }

    [XmlRoot("Band")]
    public class Band
    {
        [XmlAttribute("BandType")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}