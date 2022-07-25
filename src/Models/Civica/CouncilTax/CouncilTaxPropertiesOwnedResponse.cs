using System.Collections.Generic;
using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.CouncilTax
{
    [XmlRoot(ElementName = "Band")]
    public class Band
    {
        [XmlAttribute(AttributeName = "BandType")]
        public string BandType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Places")]
    public class Places
    {
        [XmlElement(ElementName = "PlaceRef")]
        public string PlaceRef { get; set; }
        [XmlElement(ElementName = "Address1")]
        public string Address1 { get; set; }
        [XmlElement(ElementName = "Address2")]
        public string Address2 { get; set; }
        [XmlElement(ElementName = "Address3")]
        public string Address3 { get; set; }
        [XmlElement(ElementName = "Address4")]
        public string Address4 { get; set; }
        [XmlElement(ElementName = "Address5")]
        public string Address5 { get; set; }
        [XmlElement(ElementName = "PostCode")]
        public string PostCode { get; set; }
        [XmlElement(ElementName = "Band")]
        public Band Band { get; set; }
        [XmlElement(ElementName = "FullYearCharge")]
        public string FullYearCharge { get; set; }
        [XmlElement(ElementName = "CurrentYrFullYearCharge")]
        public string CurrentYrFullYearCharge { get; set; }
        [XmlElement(ElementName = "PropertyStatus")]
        public string PropertyStatus { get; set; }
        [XmlElement(ElementName = "ChargeDetails")]
        public ChargeDetailsResponse ChargeDetails { get; set; }
    }

    [XmlRoot(ElementName = "PropertyList")]
    public class PropertyList
    {
        [XmlElement(ElementName = "Places")]
        public List<Places> Places { get; set; }
    }

    [XmlRoot(ElementName = "CtaxPropDetails")]
    public class CtaxPropDetails
    {
        [XmlElement(ElementName = "CtxActRef")]
        public string CtxActRef { get; set; }
        [XmlElement(ElementName = "PersonName")]
        public PersonName PersonName { get; set; }
        [XmlElement(ElementName = "PersonalDetails")]
        public PersonalDetails PersonalDetails { get; set; }
        [XmlElement(ElementName = "ExternalAddresses")]
        public string ExternalAddresses { get; set; }
        [XmlElement(ElementName = "PropertyList")]
        public PropertyList PropertyList { get; set; }
        [XmlElement(ElementName = "StandardInfo")]
        public StandardInfo StandardInfo { get; set; }
    }

    [XmlRoot("ChargeDetails")]
    public class ChargeDetailsResponse
    {
        public ChargeDetailsDatesResponse Dates { get; set; }

        public decimal NetCharge { get; set; }

        public string RowID { get; set; }
    }

    public class ChargeDetailsDatesResponse
    {
        [XmlAttribute]
        public string Start { get; set; }

        [XmlAttribute]
        public string End { get; set; }

        [XmlAttribute]
        public ushort Days { get; set; }
    }
}
