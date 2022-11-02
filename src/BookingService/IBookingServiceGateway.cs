using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingService
{
    public interface IBookingServiceGateway
    {
        Task<HttpResponse<List<AvailabilityDayResponse>>> GetAvailability(AvailabilityRequest model);

        Task<HttpResponse<AvailabilityDayResponse>> NextAvailability(AvailabilityRequest model);

        Task<HttpResponse<Guid>> Reserve(BookingRequest model);

        Task<HttpResponseMessage> Confirmation(ConfirmationRequest model);

        Task<HttpResponseMessage> Cancel(string id);

        Task<HttpResponse<string>> GetLocation(LocationRequest model);

        Task<HttpResponse<BookingInformationResponse>> GetBooking(Guid id);

        Task<HttpResponse<List<BookingInformationResponse>>> GetBookingsByForeignReference(string foreignReference);

        Task<HttpResponseMessage> AddReference(AddReferenceRequest addReferenceRequest);

        Task<HttpResponseMessage> AddReferences(List<AddReferenceRequest> addReferenceRequests);

        Task<HttpResponseMessage> AddFee(AddFeeRequest addFeeRequest);

        Task<HttpResponseMessage> UpdateAdditionalInformationMetaDataValues(
            UpdateAdditionalInformationMetaDataValuesRequest updateAdditionalInformationMetaDataValuesRequest);
    }
}