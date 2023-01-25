using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.User
{
    public interface IBookingServiceAdminUserGateway
    {
        Task<HttpResponseMessage> GetByUsername(string username);
    }
}
