using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("PersonName")]
    public class PersonName
    {
        [XmlElement("PersonReference")]
        public string PersonReference { get; set; }
        [XmlElement("PersonTitle")]
        public string PersonTitle { get; set; }
        [XmlElement("Initials")]
        public string Initials { get; set; }
        [XmlElement("Forenames")]
        public string Forenames { get; set; }
        [XmlElement("Surname")]
        public string Surname { get; set; }
        [XmlElement("NINo")]
        public string NINo { get; set; }
    }
}