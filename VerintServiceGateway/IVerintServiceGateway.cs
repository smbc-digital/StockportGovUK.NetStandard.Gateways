using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.VerintServiceGateway
{
    public interface IVerintServiceGateway
    {
        Task<HttpResponseMessage> GetCase(string caseRef);

        Task<HttpResponseMessage> UpdateCase(HttpContent content);
    }
}
