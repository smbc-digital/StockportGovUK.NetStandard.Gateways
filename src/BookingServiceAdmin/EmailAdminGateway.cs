using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string EmailEndpoint = "api/v1/Email";

    public async Task<HttpResponseMessage> ProcessConfirmationEmails(ProcessEmailsRequest request) =>
        await PostAsync($"{EmailEndpoint}/confirmation", request);

    public async Task<HttpResponseMessage> ProcessReminderEmail(ProcessEmailsRequest request) =>
        await PostAsync($"{EmailEndpoint}/reminder", request);

    public async Task<HttpResponseMessage> ProcessCancellationEmails(ProcessEmailsRequest request) =>
        await PostAsync($"{EmailEndpoint}/cancellation", request);

    public async Task<HttpResponseMessage> ProcessRescheduleEmails(ProcessEmailsRequest request) =>
        await PostAsync($"{EmailEndpoint}/reschedule", request);
}
