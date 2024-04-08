namespace StockportGovUK.NetStandard.Gateways.Models.Uniform;
public class CloseUniformServiceRequest
{
    public string UniformReference { get; set; }
    public string ClosingActionCode { get; set; }
    public string ClosingComments { get; set; }
}
