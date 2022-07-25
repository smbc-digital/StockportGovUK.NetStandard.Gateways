using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("PaymentDetails")]
    public class PaymentDetail
    {
        [XmlAttribute("DatePaid")]
        public string DatePaid { get; set; }

        [XmlAttribute("PayAmount")]
        public string PayAmount { get; set; }

        [XmlAttribute("PeriodStart")]
        public string PeriodStart { get; set; }

        [XmlAttribute("PeriodEnd")]
        public string PeriodEnd { get; set; }

        [XmlAttribute("Type")]
        public string PayType { get; set; }

        [XmlAttribute("Payee")]
        public string Payee { get; set; }

        [XmlAttribute("OnAct")]
        public string OnAct { get; set; }

        [XmlAttribute("CTXActRef")]
        public string CouncilTaxReference { get; set; }
    }
}