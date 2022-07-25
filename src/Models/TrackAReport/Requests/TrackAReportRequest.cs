using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.TrackAReport.Requests
{
    public class TrackAReportRequest
    {
        [Required]
        [MaxLength(24)]
        public string ReferenceNumber { get; set; }

        [Required]
        public EAssetType AssetType { get; set; }

        [Required]
        public string AssetId { get; set; }
    }
}
