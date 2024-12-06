using System.ComponentModel.DataAnnotations;

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

    // This should be formatted as yyyy-mm-dd
    public string ExpiryDate {get; set;}

    public int Quantity {get; set;}
}