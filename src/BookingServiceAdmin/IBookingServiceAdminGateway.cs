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
        Task<HttpResponse<IEnumerable<AppointmentResource>>> GetAppointmentResources(Guid appointmentId);
        Task<HttpResponse<Appointment>> AddAppointment(AppointmentRequest model);
        Task<HttpResponse<Appointment>> UpdateAppointment(AppointmentRequest model);
        Task<HttpResponse<Appointment>> UpdateAppointmentResources(AppointmentRequest model);

        #endregion

        #region Booking

        Task<HttpResponse<int>> GetDayBookingCountForContext(GetByDateRequest request);
        Task<HttpResponse<IEnumerable<Booking>>> GetNewAndConfirmedBookings(Guid contextId);
        Task<HttpResponse<Booking>> GetBooking(Guid bookingId);
        Task<HttpResponse<Booking>> CancelBooking(CancelBookingRequest request);
        Task<HttpResponse<IEnumerable<Note>>> AddNote(AddNoteRequest request);
        Task<HttpResponse<IEnumerable<Status>>> GetStatuses();
        Task<HttpResponse<Booking>> UpdateStatus(UpdateBookingStatusRequest request);
        Task<HttpResponseMessage> UpdateCustomerForBooking(UpdateCustomerForBookingRequest request);

        #endregion

        #region Context

        Task<HttpResponse<IEnumerable<BasicContext>>> GetActiveContexts();
        Task<HttpResponse<IEnumerable<BasicContext>>> GetContexts(bool showDisabled);
        Task<HttpResponse<Context>> GetContext(Guid contextId);
        Task<HttpResponse<Context>> UpdateContext(ContextRequest request);
        Task<HttpResponse<Context>> AddContext(ContextRequest request);
        Task<HttpResponseMessage> SetContextAvailability(ContextAvailabilityRequest request);

        #endregion

        #region DailyPolicy

        Task<HttpResponse<IEnumerable<DailyPolicy>>> GetDailyPolicies(Guid contextId);
        Task<HttpResponse<DailyPolicy>> GetDailyPolicy(Guid policyId);
        Task<HttpResponse<DailyPolicy>> AddDailyPolicy(DailyPolicyRequest request);

        #endregion

        #region Email

        Task<HttpResponseMessage> ProcessConfirmationEmails(ProcessEmailsRequest request);
        Task<HttpResponseMessage> ProcessReminderEmails(ProcessEmailsRequest request);
        Task<HttpResponseMessage> ProcessCancellationEmails(ProcessEmailsRequest request);
        Task<HttpResponseMessage> ProcessRescheduleEmails(ProcessEmailsRequest request);

        #endregion

        #region Policy

        Task<HttpResponse<IEnumerable<Policy>>> GetPolicies(Guid contextId);
        Task<HttpResponse<Policy>> GetPolicy(Guid policyId);
        Task<HttpResponse<Policy>> AddPolicy(PolicyRequest request);

        #endregion

        #region Resource

        Task<HttpResponse<IEnumerable<Resource>>> GetResources(Guid contextId);
        Task<HttpResponse<Resource>> GetResource(Guid resourceId);
        Task<HttpResponse<Resource>> AddResource(ResourceRequest request);
        Task<HttpResponse<Resource>> UpdateResource(ResourceRequest request);

        #endregion

        #region ResourceModifier

        Task<HttpResponse<IEnumerable<ResourceModifier>>> GetResourceModifiersForContext(Guid contextId);
        Task<HttpResponse<IEnumerable<ResourceModifier>>> GetActiveAndFutureResourceModifiersForContext(Guid contextId);
        Task<HttpResponse<int>> GetActiveResourceModifierCountForContext(GetByDateRequest request);

        #endregion

        #region Search

        Task<HttpResponse<IEnumerable<BookingSearchResult>>> SearchBookings(string contextId, string searchTerm);

        #endregion

        #region Suspension

        Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId);
        Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId);
        Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request);

        #endregion

        #region TimePeriodPolicy

        Task<HttpResponse<IEnumerable<TimePeriodPolicy>>> GetTimePeriodPolicies(Guid contextId);
        Task<HttpResponse<TimePeriodPolicy>> GetTimePeriodPolicy(Guid policyId);
        Task<HttpResponse<TimePeriodPolicy>> AddTimePeriodPolicy(TimePeriodPolicyRequest request);

        #endregion

        #region User

        Task<HttpResponseMessage> GetByUsername(string username);

        #endregion
    }
}
