using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserv;

public class BasePermitRequest 
{
    private string _returnType;

    public string ApiKey {get; set;}
    
    public string ReturnType {
        get => string.IsNullOrEmpty(_returnType) ? "json" : _returnType;
        set => _returnType = value;
    }
}