using System;
using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.GenericReport
{
    public class GenericReportMailModel : BaseMailModel
    {
        public override string TemplateName => "GenericReport.html";
        public string Reference { get; set; }
        public string Header { get; set; }
        public bool ShowRefNumber { get; set; } = false;
        public string[] FormText { get; set; }
        public bool HasFormText => FormText?.Length > 0 ? true : false;
        public string[] HappensNextContent { get; set; }
        public bool HasNext => HappensNextContent?.Length == 0 ? false : true;
        public string LeadingParagraph { get; set; }
        public bool HasLeadingParagraph => String.IsNullOrEmpty(LeadingParagraph) ? false : true;
    }
}
