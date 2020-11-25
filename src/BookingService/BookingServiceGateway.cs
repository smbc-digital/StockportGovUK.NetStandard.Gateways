using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Booking.Request;
using StockportGovUK.NetStandard.Models.Booking.Response;
using System.Web;
using System.Linq;

namespace StockportGovUK.NetStandard.Gateways.BookingService
{
    public class BookingServiceGateway : Gateway, IBookingServiceGateway
    {
        private const string AvailabilityEndpoint = "api/v1/Availability";
        private const string ConfirmationEndpoint = "api/v1/Confirmation";
        private const string ReservationEndpoint = "api/v1/Reservation";

        public BookingServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<List<AvailabilityDayResponse>>> GetAvailability(AvailabilityRequest model) => 
            await GetAsync<List<AvailabilityDayResponse>>($"{AvailabilityEndpoint}?AppointmentId={HttpUtility.UrlEncode(model.AppointmentId.ToString())}&StartDate={model.StartDate.ToString("s")}&EndDate={model.EndDate.ToString("s")}{OptionalResourcesQueryString(model.OptionalResources)}");

        public async Task<HttpResponse<AvailabilityDayResponse>> NextAvailability(AvailabilityRequest model) => 
            await GetAsync<AvailabilityDayResponse>($"{AvailabilityEndpoint}/next-availability?AppointmentId={HttpUtility.UrlEncode(model.AppointmentId.ToString())}&StartDate={HttpUtility.UrlEncode(model.StartDate.ToString("s"))}&EndDate={HttpUtility.UrlEncode(model.EndDate.ToString("s"))}{OptionalResourcesQueryString(model.OptionalResources)}");

        public async Task<HttpResponse<Guid>> Reserve(BookingRequest model)
            => await PostAsync<Guid>(ReservationEndpoint, model);

        public async Task<HttpResponseMessage> Confirmation(ConfirmationRequest model)
            => await PostAsync(ConfirmationEndpoint, model);

        private string OptionalResourcesQueryString(List<BookingResource> optionalResources) => 
            optionalResources == null 
                ? string.Empty
                : optionalResources
                    .Select((_, index) => $"&OptionalResources[{index}].Quantity={HttpUtility.UrlEncode(_.Quantity.ToString())}&OptionalResources[{index}].ResourceId={HttpUtility.UrlEncode(_.ResourceId.ToString())}")
                    .Aggregate("", (acc, _) => $"{acc}{_}");
    }
}