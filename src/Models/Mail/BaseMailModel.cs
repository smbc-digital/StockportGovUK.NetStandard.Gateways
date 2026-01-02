using System.Collections.Generic;
using StockportGovUK.NetStandard.Gateways.Models.FileManagement;

namespace StockportGovUK.NetStandard.Gateways.Models.Mail
{
    public class BaseMailModel
    {
        public string RecipientAddress { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public List<MailAttachement> AttachmentsList { get; set; }

        public List<File> Files { get; set; }

        public virtual string TemplateName => "BaseTemplate.html";
    }

    public class MailAttachement
    {
        public string Name { get; set; }

        public string Content { get; set; }
    }
}
