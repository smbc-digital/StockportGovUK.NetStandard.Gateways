using System.IO;
using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Notifications
{
    [XmlRoot(ElementName = "NotificationMessage", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
    public class NotificationMessage
    {

        [XmlElement(ElementName = "BasketReference", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string BasketReference { get; set; }

        [XmlElement(ElementName = "CallingApplicationTransReference", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string CallingApplicationTransReference { get; set; }

        [XmlElement(ElementName = "ListItems", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public ListItems ListItems { get; set; }

        [XmlElement(ElementName = "NotificationUrl", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string NotificationUrl { get; set; }

        [XmlElement(ElementName = "RequestDateTime", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string RequestDateTime { get; set; }

        [XmlElement(ElementName = "RequestStatus", Namespace = "http://schemas.datacontract.org/2004/07/epPaymentNotification")]
        public string RequestStatus { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlAttribute(AttributeName = "i", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string I { get; set; }

        public static NotificationMessage DeserializeFromXml(string message)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(NotificationMessage));
            NotificationMessage notification;
            using (TextReader reader = new StringReader(message))
            {
                notification = (NotificationMessage)serializer.Deserialize(reader);
            }

            return notification;
        }
    }



}