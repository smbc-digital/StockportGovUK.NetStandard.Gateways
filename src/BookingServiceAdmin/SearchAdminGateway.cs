using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string SearchEndpoint = "api/v1/Search";

    public async Task<HttpResponse<IEnumerable<BookingSearchResult>>> SearchBookings(string contextId, string searchTerm) =>
        await GetAsync<IEnumerable<BookingSearchResult>>($"{SearchEndpoint}/{contextId}/{searchTerm}");
}
