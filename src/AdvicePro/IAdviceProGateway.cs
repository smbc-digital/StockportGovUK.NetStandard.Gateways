using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.AdvicePro;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.AdvicePro;

public interface IAdviceProGateway
{
    Task<HttpResponse<GetResponse>> GetContract(string apiKey, string contractKey);
    Task<HttpResponse<PostResponse>> CreateReferral(object request);
}
