using System;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    public class TransactionModel
    {
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string Description { get; set; }

        public ETransactionType Type { get; set; }
    }

    public enum ETransactionType
    {
        Debit,
        Credit
    }
}
