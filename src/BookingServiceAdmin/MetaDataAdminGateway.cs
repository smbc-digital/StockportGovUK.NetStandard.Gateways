using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;
public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string MetaDataEndpoint = "api/v1/MetaData";

    public async Task<HttpResponse<IEnumerable<MetaDataField>>> GetAppointmentMetaDataFields(Guid appointmentId) =>
        await GetAsync<IEnumerable<MetaDataField>>($"{MetaDataEndpoint}/{appointmentId}/fields");

    public async Task<HttpResponseMessage> AddAppointmentMetaDataField(MetaDataField model) =>
        await PostAsync($"{MetaDataEndpoint}/field", model);

    public async Task<HttpResponseMessage> UpdateAppointmentMetaDataField(MetaDataField model) =>
        await PatchAsync($"{AppointmentEndpoint}/field/edit", model);

    public async Task<HttpResponse<IEnumerable<MetaDataDropdown>>> GetMetaDataFieldDropdowns(Guid metaDataFieldId) =>
        await GetAsync<IEnumerable<MetaDataDropdown>>($"{MetaDataEndpoint}/{metaDataFieldId}/dropdowns");

    public async Task<HttpResponseMessage> AddMetaDataFieldDropdown(MetaDataDropdown model) =>
        await PostAsync($"{MetaDataEndpoint}/dropdown", model);

    public async Task<HttpResponseMessage> UpdateMetaDataFieldDropdown(MetaDataDropdown model) =>
        await PatchAsync($"{AppointmentEndpoint}/dropdown/edit", model);
}
