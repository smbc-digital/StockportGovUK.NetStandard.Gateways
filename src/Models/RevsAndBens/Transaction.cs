using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("Transaction")]
    public class Transaction
    {
        [XmlElement("Date")]
        public Date Date { get; set; }
        [XmlElement("Amount")]
        public string Amount { get; set; }
        [XmlElement("Claim")]
        public string Claim { get; set; }
        [XmlElement("Period")]
        public Period Period { get; set; }
        [XmlElement("PlaceDetail")]
        public PlaceDetail PlaceDetail { get; set; }
        [XmlAttribute("Number")]
        public string Number { get; set; }
        [XmlAttribute("TranType")]
        public string TranType { get; set; }
        [XmlAttribute("Year")]
        public string Year { get; set; }
        [XmlElement("ChargeType")]
        public string ChargeType { get; set; }
        [XmlElement("SubCode")]
        public string SubCode { get; set; }
    }

    [XmlRoot("Date")]
    public class Date
    {
        [XmlAttribute("NumericEquiv")]
        public string NumericEquiv { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot("Period")]
    public class Period
    {
        [XmlAttribute("End")]
        public string End { get; set; }
        [XmlAttribute("Start")]
        public string Start { get; set; }
    }

    [XmlRoot("PlaceDetail")]
    public class PlaceDetail
    {
        [XmlElement("Valid")]
        public string Valid { get; set; }
        [XmlElement("PlaceRef")]
        public string PlaceRef { get; set; }
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
    }
}