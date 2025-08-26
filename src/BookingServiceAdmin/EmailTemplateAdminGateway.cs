using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string EmailTemplateEndpoint = "api/v1/EmailTemplate";

    public async Task<HttpResponse<IEnumerable<EmailTemplate>>> GetDefaultCustomerEmailTemplatesForContext(Guid contextId) =>
        await GetAsync<IEnumerable<EmailTemplate>>($"{EmailTemplateEndpoint}/{contextId}/customer");

    public async Task<HttpResponse<IEnumerable<EmailTemplate>>> GetAppointmentCustomerEmailTemplates(Guid contextId, Guid appointmentId) =>
        await GetAsync<IEnumerable<EmailTemplate>>($"{EmailTemplateEndpoint}/{contextId}/customer/{appointmentId}");

    public async Task<HttpResponse<IEnumerable<EmailTemplate>>> GetDefaultAdminEmailTemplatesForContext(Guid contextId) =>
        await GetAsync<IEnumerable<EmailTemplate>>($"{EmailTemplateEndpoint}/{contextId}/admin");

    public async Task<HttpResponse<IEnumerable<EmailTemplate>>> GetAppointmentAdminEmailTemplates(Guid contextId, Guid appointmentId) =>
        await GetAsync<IEnumerable<EmailTemplate>>($"{EmailTemplateEndpoint}/{contextId}/admin/{appointmentId}");

    public async Task<HttpResponse<IEnumerable<EmailTemplateType>>> GetEmailTemplateTypes() =>
        await GetAsync<IEnumerable<EmailTemplateType>>($"{EmailTemplateEndpoint}/types");

    public async Task<HttpResponse<EmailTemplate>> AddAppointmentEmailTemplate(EmailTemplate template) =>
        await PostAsync<EmailTemplate>($"{EmailTemplateEndpoint}", template);

    public async Task<HttpResponse<EmailTemplate>> UpdateAppointmentEmailTemplate(EmailTemplate template) =>
        await PatchAsync<EmailTemplate>($"{EmailTemplateEndpoint}", template);

    public async Task<HttpResponseMessage> DeleteAppointmentEmailTemplate(Guid templateId) =>
        await DeleteAsync($"{EmailTemplateEndpoint}/{templateId}");
}
