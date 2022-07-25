using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.ComplimentsComplaints
{
    public class ComplaintsMailModel : BaseMailModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Reference { get; set; }
    }
}
