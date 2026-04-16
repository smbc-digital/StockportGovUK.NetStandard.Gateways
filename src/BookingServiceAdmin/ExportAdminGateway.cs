using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string ExportsEndpoint = "api/v1/Exports";

    public async Task<HttpResponse<IEnumerable<Export>>> GetExportsForContext(Guid contextId) =>
        await GetAsync<IEnumerable<Export>>($"{ExportsEndpoint}/context/{contextId}");

    public async Task<HttpResponse<Export>> GetExport(GetByDateRequest request) =>
        await GetAsync<Export>($"{ExportsEndpoint}/{GetByDateRangeQueryString(request)}");

    public async Task<HttpResponse<Export>> GetDefaultExport(GetByDateRequest request) =>
        await GetAsync<Export>($"{ExportsEndpoint}/default/{GetByDateRangeQueryString(request)}");

    public async Task<HttpResponseMessage> AddExport(Export request) =>
        await PostAsync($"{ExportsEndpoint}", request);
}
