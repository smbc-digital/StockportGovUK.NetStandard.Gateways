using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserve;

public class CreatePermitRequest : BasePermitRequest
{                    
    [Required]
    public string PermitAddress {get; set;}
    
    [Required]
    public string Uprn  {get; set;}
    
    [Required]
    public string CouncilJobNumber {get; set;}

    public string NotificationEmail {get; set;}

    public string NotificationTelephone {get; set;}
}