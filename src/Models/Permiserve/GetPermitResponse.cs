using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserve;
public class GetPermitResponse : PermiserveResponse
{
    [JsonPropertyName("Num Rows")]
    [JsonProperty("Num Rows")]
    public int NumberOfResults { get; set; }

    [JsonPropertyName("Result")]
    [JsonProperty("Result")]
    public List<Permit> Permits { get; set; }
}

public class Permit
{
    [JsonPropertyName("permitId")]
    [JsonProperty("permitId")]
    public long PermitId { get; set; }

    [JsonPropertyName("permitAddress")]
    [JsonProperty("permitAddress")]
    public string PermitAddress { get; set; }

    [JsonPropertyName("deliveryAddress")]
    [JsonProperty("deliveryAddress")]
    public string DeliveryAddress { get; set; }

    [JsonPropertyName("uprn")]
    [JsonProperty("uprn")]
    public string Uprn { get; set; }

    [JsonPropertyName("councilJobNumber")]
    [JsonProperty("councilJobNumber")]
    public string CouncilJobNumber { get; set; }

    [JsonPropertyName("permitType")]
    [JsonProperty("permitType")]
    public string PermitType { get; set; }

    [JsonPropertyName("state")]
    [JsonProperty("state")]
    public string State { get; set; }

    [JsonPropertyName("dateCreated")]
    [JsonProperty("dateCreated")]
    public string DateCreated { get; set; }

    [JsonPropertyName("dateDispatched")]
    [JsonProperty("dateDispatched")]
    public string DateDispatched { get; set; }

    [JsonPropertyName("expiryDate")]
    [JsonProperty("expiryDate")]
    public string ExpiryDate { get; set; }

    [JsonPropertyName("cancelled")]
    [JsonProperty("cancelled")]
    public int Cancelled { get; set; }
}

