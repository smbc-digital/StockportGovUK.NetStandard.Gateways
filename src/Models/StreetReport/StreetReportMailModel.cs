using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.StreetReport
{
    public class StreetReportMailModel : BaseMailModel
    {
        public FormType FormType { get; set; }

        public string Reference { get; set; }

        public string ConcerningDescription { get; set; }

        public string StreetInput { get; set; }

        public bool ShowCovidMessage { get; set; } = false;
    }

    public enum FormType
    {
        enquiry,
        report,
        request,
    }
}
