using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string ExportsEndpoint = "api/v1/Exports";

    public async Task<HttpResponse<List<Export>>> GetExportsForContext(Guid contextId) =>
        await GetAsync<List<Export>>($"{ExportsEndpoint}/context/{contextId}");

    public async Task<HttpResponse<Export>> GetExport(Guid exportId) =>
        await GetAsync<Export>($"{ExportsEndpoint}/{exportId}");
}
