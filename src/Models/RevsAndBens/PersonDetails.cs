using System.Collections.Generic;
using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("PersonalDetails")]
    public class PersonalDetails
    {
        [XmlElement("NINo")]
        public string NINo { get; set; }
        [XmlElement("TelephoneNumber")]
        public List<TelephoneNumber> TelephoneNumber { get; set; }
        [XmlElement("MobileNumber")]
        public MobileNumber MobileNumber { get; set; }
        [XmlElement("contact_types")]
        public Contact_types Contact_types { get; set; }
    }

    [XmlRoot("TelephoneNumber")]
    public class TelephoneNumber
    {
        [XmlAttribute("Priority")]
        public string Priority { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot("MobileNumber")]
    public class MobileNumber
    {
        [XmlAttribute("Priority")]
        public string Priority { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot("contact_types")]
    public class Contact_types
    {
        [XmlElement("contact_type")]
        public List<Contact_type> Contact_type { get; set; }
    }

    [XmlRoot("contact_type")]
    public class Contact_type
    {
        [XmlAttribute("contact_type")]
        public string _contact_type { get; set; }
        [XmlAttribute("details")]
        public string Details { get; set; }
        [XmlAttribute("priority")]
        public string Priority { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}