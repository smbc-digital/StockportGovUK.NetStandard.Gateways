using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.AdvicePro;

public interface IAdviceProGateway
{
    Task<HttpResponseMessage> CreateReferral(object request);
}
