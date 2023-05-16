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
        private const string AppointmentEndpoint = "api/v1/Appointment";

        public async Task<HttpResponse<List<Appointment>>> GetAppointments(Guid contextId, int subLevels) =>
            await GetAsync<List<Appointment>>($"{AppointmentEndpoint}/all-appointments/{contextId}/{subLevels}");

        public async Task<HttpResponse<Appointment>> GetAppointment(Guid contextId) =>
            await GetAsync<Appointment>($"{AppointmentEndpoint}/full-appointment-details/{contextId}");

        public async Task<HttpResponse<Appointment>> GetAppointment(Guid appointmentId, int subLevels) =>
            await GetAsync<Appointment>($"{AppointmentEndpoint}/appointment-details/{appointmentId}/{subLevels}");

        public async Task<HttpResponse<IEnumerable<AppointmentResource>>> GetAppointmentResources(Guid appointmentId) =>
            await GetAsync<IEnumerable<AppointmentResource>>($"{AppointmentEndpoint}/resources/{appointmentId}");

        public async Task<HttpResponse<Appointment>> AddAppointment(AppointmentRequest model) =>
            await PostAsync<Appointment>(AppointmentEndpoint, model);

        public async Task<HttpResponse<Appointment>> UpdateAppointment(AppointmentRequest model) =>
            await PatchAsync<Appointment>(AppointmentEndpoint, model);

        public async Task<HttpResponse<Appointment>> UpdateAppointmentResources(AppointmentRequest model) =>
            await PatchAsync<Appointment>($"{AppointmentEndpoint}/appointment-resources", model);
    }
}
