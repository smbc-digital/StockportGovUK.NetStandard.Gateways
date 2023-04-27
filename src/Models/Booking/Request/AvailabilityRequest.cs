using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class AvailabilityRequest : BaseRequest
    {
        public AvailabilityRequest() : base() { }

        public AvailabilityRequest(DateTime startDate, DateTime endDate, Guid appointmentId)
          : base(appointmentId) => (StartDate, EndDate) = (startDate, endDate);

        public AvailabilityRequest(DateTime startDate, DateTime endDate, Guid appointmentId, List<BookingResource> optionalResources)
          : base(appointmentId, optionalResources) => (StartDate, EndDate) = (startDate, endDate);

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Specifies whether this request should return appointments that could be overidden by admins but would otherwise note be availble.
        /// </summary>
        /// <value></value>
        public bool AdminOverride {get; set;} = false;
    }
}
