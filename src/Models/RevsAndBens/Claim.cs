using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    public class Claim
    {
        public ClaimDetails Details { get; set; }

        public List<BenefitsDocument> Documents { get; set; }

        public List<Payment> HousingBenefitPaymentHistory { get; set; }

        public List<Payment> CouncilTaxPaymentHistory { get; set; }

        public BenefitsSummary BenefitsSummary { get; set; }
    }

    public class ClaimDetails
    {
        public string PersonName { get; set; }

        public string Number { get; set; }

        public string Status { get; set; }

        public string Address { get; set; }

        public ClaimNextPayment NextPayment { get; set; }

        public CurrentEntitlement CurrentEntitlement { get; set; }

        public BenefitsCombinationEnum BenefitsCombination { get; set; }
    }

    public class ClaimNextPayment
    {
        public string DueDate { get; set; }

        public DateTime DueDateTime
        {
            get
            {
                DateTime dt;
                DateTime.TryParse(DueDate, new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
                return dt;
            }
        }

        public string Amount { get; set; }

        public string Payee { get; set; }

        public string PaidUpToAmount { get; set; }

        public string Schedule { get; set; }

        public string Method { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPaymentStatus Status { get; set; }
    }

    public enum BenefitsCombinationEnum
    {
        AllBenefits = 0,
        HousingBenefitOnly = 1,
        CouncilTaxSupportOnly = 2
    }

    public class BenefitsSummary
    {
        public int TaxYear { get; set; }

        public string AccountReference { get; set; }

        public string TotalBill { get; set; }

        public string TotalBenefits { get; set; }

        public string BalanceOutstanding { get; set; }
    }

    public class BenefitsDocument
    {
        public string Name { get; set; }

        public string DateCreated { get; set; }

        public string Downloaded { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string AccountReference { get; set; }
    }

    public class Payment
    {
        public string DatePaid { get; set; }

        public DateTime DateTimePaid
        {
            get
            {
                DateTime dt;
                DateTime.TryParse(DatePaid, new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
                return dt;
            }
        }

        public string Amount { get; set; }

        public string PeriodStart { get; set; }

        public string PeriodEnd { get; set; }

        public string Type { get; set; }

        public string Payee { get; set; }

        public string OnAct { get; set; }

        public string CouncilTaxReference { get; set; }
    }
}
