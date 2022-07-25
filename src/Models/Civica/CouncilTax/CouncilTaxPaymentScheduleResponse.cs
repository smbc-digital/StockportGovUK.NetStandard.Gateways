using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.CouncilTax
{
    [XmlRoot("IRInstalments")]
    public class CouncilTaxPaymentScheduleResponse
    {
        [XmlElement("InstalmentList")]
        public List<Installment> InstallmentList { get; set; }

        public string PaymentMethod { get; set; }
    }

    [XmlRoot("Instalment")]
    public class Installment
    {
        private decimal _amountDue;

        [XmlAttribute("DateDue")]
        public string DateDue { get; set; }

        [XmlAttribute("AmountDue")]
        public decimal AmountDue
        {
            get { return 0 - _amountDue; }
            set { _amountDue = value; }
        }

        [XmlAttribute("DDInd")]
        public string IsDirectDebit { get; set; }

        public DateTime PaymentDateDue
        {
            get { return DateTime.Parse(DateDue); }
        }
    }
}
