using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("RecYrTotals")]
    public class ReceivedYearTotal
    {
        private string _totalCharge { get; set; }

        [XmlElement("TotalCharge")]
        public string TotalCharge
        {
            get => _totalCharge;

            set => _totalCharge = value.Trim();
        }

        private string _totalPayments { get; set; }

        [XmlElement("TotalPayments")]
        public string TotalPayments
        {
            get => _totalPayments;

            set => _totalPayments = value.Trim();
        }

        private string _totalBenefits { get; set; }

        [XmlElement("TotalBenefits")]
        public string TotalBenefits
        {
            get => _totalBenefits;

            set => _totalBenefits = value.Trim();
        }

        private string _balanceOutstanding { get; set; }

        [XmlElement("BalanceOutstanding")]
        public string BalanceOutstanding
        {
            get => _balanceOutstanding;

            set => _balanceOutstanding = value.Trim();
        }
    }
}