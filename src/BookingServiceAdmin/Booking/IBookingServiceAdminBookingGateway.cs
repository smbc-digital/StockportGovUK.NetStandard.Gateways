using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Booking
{
    public interface IBookingServiceAdminBookingGateway
    {
        Task<HttpResponseMessage> GetDayBookingCountForContext(GetByDateRequest request);
    }
}
