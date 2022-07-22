using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Notifications
{
    [XmlRoot(ElementName = "ListItem", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
    public class ListItem
    {
        [XmlElement(ElementName = "Amount", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string Amount { get; set; }

        [XmlElement(ElementName = "FundCode", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string FundCode { get; set; }

        [XmlElement(ElementName = "Reference", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string Reference { get; set; }

        [XmlElement(ElementName = "TrueAccountReference", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string TrueAccountReference { get; set; }
    }

}