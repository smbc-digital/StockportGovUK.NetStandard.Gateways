using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserve;
public class GetPermitResponse : PermiserveResponse
{
    [JsonPropertyName("NumRows")]
    [JsonProperty("NumRows")]
    public int NumberOfResults { get; set; }

    [JsonPropertyName("Result")]
    [JsonProperty("Result")]
    public IEnumerable<Permit> Permits { get; set; }
}

public class Permit
{
    public long PermitId { get; set; }
    public string PermitAddress { get; set; }
    public string DeliveryAddress { get; set; }
    public string Uprn { get; set; }
    public string CouncilJobNumber { get; set; }
    public string PermitType { get; set; }
    public string State { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateDispatched { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Cancelled { get; set; }
}

