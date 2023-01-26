using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string AppointmentEndpoint = "api/v1/Appointment";

        public async Task<HttpResponseMessage> GetAppointments(Guid contextId, int subLevels) =>
            await GetAsync($"{AppointmentEndpoint}/all-appointments/{contextId}/{subLevels}");

        public async Task<HttpResponseMessage> GetAppointment(Guid appointmentId, int subLevels) =>
            await GetAsync($"{AppointmentEndpoint}/appointment-details/{appointmentId}/{subLevels}");

        public async Task<HttpResponseMessage> GetAppointment(Guid contextId) =>
            await GetAsync($"{AppointmentEndpoint}/full-appointment-details/{contextId}");
    }
}
