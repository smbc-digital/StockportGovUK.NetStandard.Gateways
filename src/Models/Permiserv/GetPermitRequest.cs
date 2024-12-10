using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserv;

public class GetPermitRequest : BasePermitRequest
{                    
    public string PermitId { get; set; }
    public string PermitAddress { get; set; }
    public string Uprn { get; set; }
    public string CouncilJobNumber { get; set; }
    public bool Cancelled { get; set; }
    public string NotificationEmail { get; set; }
    public PermitType PermitType { get; set; }
    public PermitState PermitState { get; set; }    
}
