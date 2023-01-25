using System.Net.Http;
using System.Threading.Tasks;
using System;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Suspension
{
    public interface IBookingServiceAdminSuspensionGateway
    {
        Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request);
    }
}
