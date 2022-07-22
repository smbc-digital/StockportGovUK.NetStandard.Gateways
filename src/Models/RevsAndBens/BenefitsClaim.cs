using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("HBClaimDetails")]
    public class BenefitsClaim
    {
        [XmlElement("PersonName")]
        public PersonName PersonName { get; set; }

        [XmlElement("Error")]
        public string Error { get; set; }

        [XmlElement("HBClaimRef")]
        public string Number { get; set; }

        [XmlElement("HBPlaceRef")]
        public string PlaceReference { get; set; }

        [XmlElement("HBClaimStatus")]
        public string Status { get; set; }

        [XmlElement("HBPersonType")]
        public string PersonType { get; set; }

        [XmlElement("HBClaimType")]
        public string Type { get; set; }

        [XmlElement("NextPayment")]
        public CivicaNextPayment NextPayment { get; set; }

        [XmlElement("BenefitEntitlement")]
        public BenefitEntitlement BenefitEntitlement { get; set; }

        [XmlElement("ClaimAddress1")]
        public string Address1 { get; set; }

        [XmlElement("ClaimAddress2")]
        public string Address2 { get; set; }

        [XmlElement("ClaimAddress3")]
        public string Address3 { get; set; }

        [XmlElement("ClaimAddress4")]
        public string Address4 { get; set; }

        [XmlElement("ClaimPostcode")]
        public string Postcode { get; set; }
    }

    [XmlRoot("NextPayment")]
    public class CivicaNextPayment
    {
        [XmlElement("Date")]
        public string PaymentDueDate { get; set; }

        [XmlElement("Amount")]
        public string Amount { get; set; }

        [XmlElement("Payee")]
        public string Payee { get; set; }

        [XmlElement("PaidUpToAmount")]
        public string PaidUpToAmount { get; set; }

        [XmlElement("PaymentSchedule")]
        public string Schedule { get; set; }

        [XmlElement("PaymentMethod")]
        public string Method { get; set; }

        public string Status { get; set; }
    }

    [XmlRoot("BenefitEntitlement")]
    public class BenefitEntitlement
    {
        [XmlElement("CTX")]
        public CouncilTaxEntitlement CouncilTax { get; set; }

        [XmlElement("PrivateRent")]
        public HousingBenefitEntitlement PrivateRent { get; set; }

        [XmlElement("CouncilRent")]
        public HousingBenefitEntitlement CouncilRent { get; set; }
    }

    [XmlRoot("CTX")]
    public class CouncilTaxEntitlement
    {
        [XmlAttribute("CtxActRef")]
        public string CouncilTaxReference { get; set; }

        [XmlAttribute("PeriodStart")]
        public string PeriodStart { get; set; }

        [XmlAttribute("PeriodEnd")]
        public string PeriodEnd { get; set; }

        [XmlAttribute("WeeklyBenefit")]
        public string WeeklyBenefit { get; set; }
    }

    [XmlRoot("PrivateRent")]
    public class HousingBenefitEntitlement
    {
        [XmlAttribute("PeriodStart")]
        public string PeriodStart { get; set; }

        [XmlAttribute("PeriodEnd")]
        public string PeriodEnd { get; set; }

        [XmlAttribute("WeeklyBenefit")]
        public string WeeklyBenefit { get; set; }
    }
}