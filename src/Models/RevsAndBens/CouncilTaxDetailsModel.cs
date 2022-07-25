using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Models.Civica.CouncilTax;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    public class CouncilTaxDetailsModel
    {
        public string PersonName { get; set; }
        public IEnumerable<CouncilTaxAccountDetails> Accounts { get; set; }
        public IEnumerable<CouncilTaxDocument> Documents { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsDirectDebitCustomer { get; set; }
        public decimal AmountOwing { get; set; }
        public IEnumerable<YearTotalResponse> YearTotals { get; set; }
        public string Reference { get; set; }
        public PaymentSummaryResponse PaymentSummary { get; set; }
        public bool? IsFinalNotice { get; set; }
        public bool? IsClosed { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string LiabilityPeriodStart { get; set; }
        public string LiabilityPeriodEnd { get; set; }
        public List<InstallmentModel> UpcomingPayments { get; set; }
        public List<TransactionModel> PreviousPayments { get; set; }
        public List<TransactionModel> TransactionHistory { get; set; }
        public bool HasBenefits { get; set; }
        public string TaxBand { get; set; }
        public string Property { get; set; }
        public string LatestBillId { get; set; }
        public bool HasSpar { get; set; }
    }

    public class InstallmentModel
    {
        [DataType("Date")]
        public DateTime Date { get; set; }

        [DataType("Currency")]
        public decimal Amount { get; set; }

        public bool IsDirectDebit { get; set; }

        public string Description => IsDirectDebit ? "Direct Debit" : "Non Direct Debit";
    }
}
