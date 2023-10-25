using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingService
{
    public class BookingServiceGateway : Gateway, IBookingServiceGateway
    {
        private const string AvailabilityEndpoint = "api/v1/Availability";
        private const string ConfirmationEndpoint = "api/v1/Confirmation";
        private const string ReservationEndpoint = "api/v1/Reservation";
        private const string LocationEndpoint = "api/v1/Location";
        private const string CancellationEndpoint = "api/v1/Cancellation";
        private const string BookingEndpoint = "api/v1/Booking";
        private const string NextAvailabilityAction = "/next-availability";

        public BookingServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<List<AvailabilityDayResponse>>> GetAvailability(AvailabilityRequest model) =>
            await GetAsync<List<AvailabilityDayResponse>>($"{AvailabilityEndpoint}{AvailabilityQueryString(model)}");

        public async Task<HttpResponse<AvailabilityDayResponse>> NextAvailability(AvailabilityRequest model) =>
            await GetAsync<AvailabilityDayResponse>($"{AvailabilityEndpoint}{NextAvailabilityAction}{AvailabilityQueryString(model)}");

        public async Task<HttpResponse<Guid>> Reserve(BookingRequest model) =>
            await PostAsync<Guid>(ReservationEndpoint, model);

        public async Task<HttpResponse<Guid>> ReserveOverridden(BookingRequest model) =>
            await PostAsync<Guid>($"{ReservationEndpoint}/reserve-overridden", model);

        public async Task<HttpResponseMessage> Confirmation(ConfirmationRequest model) =>
            await PatchAsync(ConfirmationEndpoint, model);

        public async Task<HttpResponseMessage> Cancel(string id) =>
            await DeleteAsync($"{CancellationEndpoint}/{id}");

        public async Task<HttpResponseMessage> Cancel(Guid id) =>
            await DeleteAsync($"{CancellationEndpoint}/{id}");

        public async Task<HttpResponseMessage> AddReference(AddReferenceRequest addReferenceRequest) =>
            await PatchAsync($"{BookingEndpoint}/add-reference", addReferenceRequest);

        public async Task<HttpResponseMessage> AddFee(AddFeeRequest addFeeRequest) =>
            await PatchAsync($"{BookingEndpoint}/add-fee", addFeeRequest);

        public async Task<HttpResponseMessage> AddBookingDescription(AddBookingDescriptionRequest addBookingDescriptionRequest) =>
            await PatchAsync($"{BookingEndpoint}/add-booking-description", addBookingDescriptionRequest);

        public async Task<HttpResponseMessage> AddReferences(List<AddReferenceRequest> addReferenceRequests) =>
            await PatchAsync($"{BookingEndpoint}/add-references", addReferenceRequests);

        public async Task<HttpResponseMessage> UpdateAdditionalInformationMetaDataValues(UpdateAdditionalInformationMetaDataValuesRequest updateAdditionalInformationMetaDataValuesRequest) =>
            await PatchAsync($"{BookingEndpoint}/update-additional-information-meta-data-values", updateAdditionalInformationMetaDataValuesRequest);

        public async Task<HttpResponseMessage> RelateBookings(RelateBookingsRequest relateBookingsRequest) =>
            await PatchAsync($"{BookingEndpoint}/relate-bookings", relateBookingsRequest);

        public async Task<HttpResponse<string>> GetLocation(LocationRequest model) =>
            await GetAsync<string>($"{LocationEndpoint}{LocationQueryString(model)}");

        private string AvailabilityQueryString(AvailabilityRequest model) =>
            $"?{nameof(model.AppointmentId)}={model.AppointmentId}&{nameof(model.StartDate)}={model.StartDate:s}&{nameof(model.EndDate)}={model.EndDate:s}&{nameof(model.AdminOverride)}={model.AdminOverride}&{nameof(model.NumberOfConsecutiveAppointmentsRequired)}={model.NumberOfConsecutiveAppointmentsRequired}{OptionalResourcesQueryString(model.OptionalResources, nameof(model.OptionalResources))}";

        private string LocationQueryString(LocationRequest model) =>
            $"?{nameof(model.AppointmentId)}={model.AppointmentId}{OptionalResourcesQueryString(model.OptionalResources, nameof(model.OptionalResources))}";

        private string OptionalResourcesQueryString(List<BookingResource> optionalResources, string listOfType) =>
            optionalResources == null
                ? string.Empty
                : optionalResources
                    .Select((_, index) => $"&{listOfType}[{index}].{nameof(BookingResource.Quantity)}={_.Quantity}&{listOfType}[{index}].{nameof(BookingResource.ResourceId)}={_.ResourceId}")
                    .Aggregate("", (acc, _) => $"{acc}{_}");

        public async Task<HttpResponse<BookingInformationResponse>> GetBooking(Guid id) =>
            await GetAsync<BookingInformationResponse>($"{BookingEndpoint}/{id}");

        public async Task<HttpResponse<List<BookingInformationResponse>>> GetBookingsByForeignReference(string foreignReference) =>
            await GetAsync<List<BookingInformationResponse>>($"{BookingEndpoint}/{foreignReference}/bookings");
    }
}
