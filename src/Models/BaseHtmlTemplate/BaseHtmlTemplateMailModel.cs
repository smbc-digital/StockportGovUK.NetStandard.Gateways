using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.BaseHtmlTemplate
{
    public class BaseHtmlTemplateMailModel : BaseMailModel
    {
        public override string TemplateName => "BaseHtmlTemplate.html";
    }
}
