using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserve;

public class BasePermitRequest {

    private string _returnType;

    [Required]
    public string ApiKey {get; set;}
    
    public string ReturnType {
        get => string.IsNullOrEmpty(_returnType) ? "json" : _returnType;
        set => _returnType = value;
    }
}