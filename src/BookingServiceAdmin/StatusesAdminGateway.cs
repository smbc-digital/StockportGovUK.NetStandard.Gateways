using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;
public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string StatusesEndpoint = "api/v1/Statuses";

    public async Task<HttpResponse<IEnumerable<Status>>> GetSystemStatuses() =>
        await GetAsync<IEnumerable<Status>>($"{StatusesEndpoint}/system");
}
