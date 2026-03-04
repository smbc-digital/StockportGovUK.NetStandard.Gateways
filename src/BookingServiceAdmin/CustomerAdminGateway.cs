using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string CustomerEndpoint = "api/v1/Customer";

    public async Task<HttpResponseMessage> UpdateCustomerDetails(Customer request) =>
        await PatchAsync($"{CustomerEndpoint}/update-customer-details", request);

    public async Task<HttpResponse<List<Customer>>> SearchCustomers(string customerName, string customerPostcode, string customerEmail, string customerPhone) =>
        await GetAsync<List<Customer>>($"{CustomerEndpoint}/search?{nameof(customerName)}={customerName}&{nameof(customerPostcode)}={customerPostcode}&{nameof(customerEmail)}={customerEmail}&{nameof(customerPhone)}={customerPhone}");
}
