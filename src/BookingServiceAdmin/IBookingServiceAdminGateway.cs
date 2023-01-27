using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public interface IBookingServiceAdminGateway
    {
        #region Home

        Task<HttpResponseMessage> GetVersionNumber();

        #endregion

        #region Appointment

        Task<HttpResponse<List<Appointment>>> GetAppointments(Guid contextId, int subLevels);

        Task<HttpResponse<Appointment>> GetAppointment(Guid appointmentId, int subLevels);

        Task<HttpResponse<Appointment>> GetAppointment(Guid contextId);

        Task<HttpResponse<Appointment>> Reserve(AppointmentRequest model);

        #endregion

        #region Booking

        Task<HttpResponseMessage> GetDayBookingCountForContext(GetByDateRequest request);
        
        Task<HttpResponseMessage> GetNewAndConfirmedBookings(Guid contextId);

        #endregion

        #region Context

        Task<HttpResponseMessage> GetContext(Guid contextId);

        Task<HttpResponseMessage> GetContexts();

        #endregion

        #region Resource

        Task<HttpResponse<List<ResourceModifier>>> GetResourceModifiersForContext(Guid contextId);

        Task<HttpResponse<List<ResourceModifier>>> GetActiveAndFutureResourceModifiersForContext(Guid contextId);

        Task<HttpResponse<int>> GetActiveResourceModifierCountForContext(GetByDateRequest request);

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
