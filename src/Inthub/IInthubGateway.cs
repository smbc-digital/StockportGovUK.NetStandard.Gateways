using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Inthub
{
    public interface IInthubGateway
    {
        Task<HttpResponseMessage> UnmatchFosteringCase(string reference);
    }
}
