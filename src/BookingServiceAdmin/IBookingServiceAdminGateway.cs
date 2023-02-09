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
        Task<HttpResponse<Appointment>> GetAppointment(Guid contextId);
        Task<HttpResponse<Appointment>> GetAppointment(Guid appointmentId, int subLevels);
        Task<HttpResponse<Appointment>> AddAppointment(AppointmentRequest model);
        Task<HttpResponse<Appointment>> UpdateAppointment(AppointmentRequest model);
        Task<HttpResponse<Appointment>> UpdateAppointmentResources(AppointmentRequest model);

        #endregion

        #region Booking

        Task<HttpResponse<int>> GetDayBookingCountForContext(GetByDateRequest request);
        
        Task<HttpResponse<IEnumerable<Booking>>> GetNewAndConfirmedBookings(Guid contextId);

        Task<HttpResponse<Booking>> GetBooking(Guid bookingId);

        #endregion

        #region Context

        Task<HttpResponse<IEnumerable<BasicContext>>> GetActiveContexts();
        Task<HttpResponse<IEnumerable<BasicContext>>> GetContexts(bool showDisabled);
        Task<HttpResponse<Context>> GetContext(Guid contextId);
        Task<HttpResponse<Context>> UpdateContext(ContextRequest request);
        Task<HttpResponse<Context>> AddContext(ContextRequest request);
        Task<HttpResponseMessage> SetContextAvailability(ContextAvailabilityRequest request);

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
