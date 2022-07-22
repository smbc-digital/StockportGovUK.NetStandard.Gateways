using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("CtaxActDetails")]
    public class CouncilTaxAccountDetails
    {
        [XmlElement("CtaxActAddress")]
        public string Address { get; set; }
        [XmlAttribute("AccountStatus")]
        public string Status { get; set; }
        [XmlAttribute("CtaxActRef")]
        public string Reference { get; set; }
        [XmlAttribute("CtaxBalance")]
        public string Balance { get; set; }
    }
}