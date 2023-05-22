using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string ResourceEndpoint = "api/v1/Resource";

        public async Task<HttpResponse<IEnumerable<Resource>>> GetResources(Guid contextId) =>
            await GetAsync<IEnumerable<Resource>>($"{ResourceEndpoint}/{contextId}");

        public async Task<HttpResponse<Resource>> GetResource(Guid resourceId) =>
            await GetAsync<Resource>($"{ResourceEndpoint}/resource-details/{resourceId}");

        public async Task<HttpResponse<Resource>> AddResource(ResourceRequest request) =>
            await PostAsync<Resource>($"{ResourceEndpoint}", request);

        public async Task<HttpResponse<Resource>> UpdateResource(ResourceRequest request) =>
            await PatchAsync<Resource>($"{ResourceEndpoint}", request);
    }
}
