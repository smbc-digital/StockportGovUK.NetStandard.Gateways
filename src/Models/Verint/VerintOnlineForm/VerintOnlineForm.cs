using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
public class VerintOnlineForm
{
    public Dictionary<string, string> FormData { get; set; }
    public Dictionary<string, object> FormDataAllTypes { get; set; }
    public Dictionary<string, string[]> FormDataCheckbox { get; set; }
}
