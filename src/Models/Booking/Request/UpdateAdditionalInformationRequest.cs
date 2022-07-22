using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class UpdateAdditionalInformationRequest
    {
        public Guid BookingId { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
