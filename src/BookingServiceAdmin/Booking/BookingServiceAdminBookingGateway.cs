using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Booking
{
    public class BookingServiceAdminBookingGateway : Gateway, IBookingServiceAdminBookingGateway
    {
        private const string BookingEndpoint = "api/v1/Booking";

        public BookingServiceAdminBookingGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetDayBookingCountForContext(GetByDateRequest request) =>
            await GetAsync($"{BookingEndpoint}/day-count/context/{QueryStringGenerator.GetByDateQueryString(request)}");
    }
}
