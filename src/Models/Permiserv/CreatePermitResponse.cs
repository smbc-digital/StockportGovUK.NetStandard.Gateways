using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockportGovUk.NetStandard.Gateways.Models.Permiserv;

public class CreatePermitResponse : PermiservResponse
{
    [JsonPropertyName("Total Permits")]
    [JsonProperty("Total Permits")]
    public int TotalPermits { get; set; }

    [JsonPropertyName("Quarantined Permits")]
    [JsonProperty("Quarantined Permits")]
    public int TotalQuarantinedPermits { get; set; }

    [JsonPropertyName("Created Permit Ids")]
    [JsonProperty("Created Permit Ids")]
    public IEnumerable<int> CreatedPermitIds { get; set; }
}