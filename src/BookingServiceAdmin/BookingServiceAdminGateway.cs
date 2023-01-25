using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string HomeEndpoint = "api/v1/Home";

        public BookingServiceAdminGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetVersionNumber() =>
            await GetAsync($"{HomeEndpoint}/version-number");

        #region Query String Generators

        private string GetByDateQueryString(GetByDateRequest request) =>
            $"?{nameof(request.Id)}={request.Id}&{nameof(request.Date)}={request.Date:s}";

        #endregion
    }
}
