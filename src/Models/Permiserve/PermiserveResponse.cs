using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserve;
public class PermiserveResponse
{
    public string Success { get; set; }
    
    [JsonProperty("Call Type")]
    [JsonPropertyName("Call Type")]
    public string CallType { get; set; }

    [JsonProperty("ErrorCount")]
    [JsonPropertyName("ErrorCount")]
    public int ErrorCount { get; set; }

    public List<string> Errors { get; set; }

    public bool HasErrors { get => Success.Equals("false"); }
}