using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Models.FileManagement;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint
{
    public class NoteWithAttachments : NoteRequest
    {
        [Required]
        public List<File> Attachments { get; set; }

        public string AttachmentsDescription { get; set; } = string.Empty;

    }
}
