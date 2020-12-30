using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Booking.Request;
using StockportGovUK.NetStandard.Models.Booking.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingService
{
    public class BookingServiceGateway : Gateway, IBookingServiceGateway
    {
        private const string AvailabilityEndpoint = "api/v1/Availability";
        private const string ConfirmationEndpoint = "api/v1/Confirmation";
        private const string ReservationEndpoint = "api/v1/Reservation";
        private const string LocationEndpoint = "api/v1/Location";
        private const string NextAvailabilityAction = "/next-availability";

        public BookingServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<List<AvailabilityDayResponse>>> GetAvailability(AvailabilityRequest model) => 
            await GetAsync<List<AvailabilityDayResponse>>($"{AvailabilityEndpoint}{availabilityQueryString(model)}");

        public async Task<HttpResponse<AvailabilityDayResponse>> NextAvailability(AvailabilityRequest model) => 
            await GetAsync<AvailabilityDayResponse>($"{AvailabilityEndpoint}{NextAvailabilityAction}{availabilityQueryString(model)}");

        public async Task<HttpResponse<Guid>> Reserve(BookingRequest model) =>
            await PostAsync<Guid>(ReservationEndpoint, model);

        public async Task<HttpResponseMessage> Confirmation(ConfirmationRequest model) =>
            await PatchAsync(ConfirmationEndpoint, model);

        public async Task<HttpResponse<string>> GetLocation(LocationRequest model) =>
            await GetAsync<string>($"{LocationEndpoint}{locationQueryString(model)}");

        private string availabilityQueryString(AvailabilityRequest model) =>
            $"?{nameof(model.AppointmentId)}={model.AppointmentId}&{nameof(model.StartDate)}={model.StartDate:s}&{nameof(model.EndDate)}={model.EndDate:s}{OptionalResourcesQueryString(model.OptionalResources, nameof(model.OptionalResources))}";

        private string locationQueryString(LocationRequest model) =>
            $"?{nameof(model.AppointmentId)}={model.AppointmentId}{OptionalResourcesQueryString(model.OptionalResources, nameof(model.OptionalResources))}";

        private string OptionalResourcesQueryString(List<BookingResource> optionalResources, string listOfType) =>
            optionalResources == null
                ? string.Empty
                : optionalResources
                    .Select((_, index) => $"&{listOfType}[{index}].{nameof(BookingResource.Quantity)}={_.Quantity}&{listOfType}[{index}].{nameof(BookingResource.ResourceId)}={_.ResourceId}")
                    .Aggregate("", (acc, _) => $"{acc}{_}");
    }
}
