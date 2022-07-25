using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.BaseHtmlTemplate
{
    public class BaseHtmlTemplateMailModel : BaseMailModel
    {
        new public string Content { get; set; }
    }
}
