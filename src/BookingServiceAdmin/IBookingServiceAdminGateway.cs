using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public interface IBookingServiceAdminGateway
    {
        Task<HttpResponseMessage> GetVersionNumber();

        Task<HttpResponseMessage> GetContexts();

        Task<HttpResponseMessage> GetByUsername(string username);
    }
}
