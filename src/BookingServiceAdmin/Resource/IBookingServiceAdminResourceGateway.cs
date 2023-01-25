using System.Net.Http;
using System.Threading.Tasks;
using System;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Resource
{
    public interface IBookingServiceAdminResourceGateway
    {
        Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(GetByDateRequest request);
    }
}
