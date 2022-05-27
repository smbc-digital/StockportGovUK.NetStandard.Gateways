using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public interface IWiredPlusGateway
    {
        Task<HttpResponse<NewsletterSignupResponse>> CreateContact(NewletterSignUpReqest request);
    }
}
