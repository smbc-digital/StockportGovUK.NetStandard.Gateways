using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string CustomerEndpoint = "api/v1/Customer";

    public async Task<HttpResponseMessage> UpdateCustomerDetails(Customer request) =>
        await PatchAsync($"{CustomerEndpoint}/update-customer-details", request);
}
