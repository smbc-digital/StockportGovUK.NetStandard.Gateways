using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.InthubGateway
{
    public interface IInthubGateway
    {
        Task<HttpResponseMessage> UnmatchFosteringCase(string reference);
    }
}
