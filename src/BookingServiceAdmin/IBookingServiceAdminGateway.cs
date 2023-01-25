using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public interface IBookingServiceAdminGateway
    {
        #region Home

        Task<HttpResponseMessage> GetVersionNumber();

        #endregion

        #region Booking

        Task<HttpResponseMessage> GetDayBookingCountForContext(GetByDateRequest request);

        #endregion

        #region Context

        Task<HttpResponseMessage> GetContext(Guid contextId);

        Task<HttpResponseMessage> GetContexts();

        #endregion

        #region Resource

        Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(GetByDateRequest request);

        #endregion

        #region Suspension

        Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request);

        #endregion

        #region MyRegion

        Task<HttpResponseMessage> GetByUsername(string username);

        #endregion
    }
}
