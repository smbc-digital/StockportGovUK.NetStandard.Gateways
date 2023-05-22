using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class BaseRequest
    {
        public BaseRequest() => NumberOfConsecutiveAppointmentsRequired = 1;

        public BaseRequest(Guid appointmentId)
          => (AppointmentId, NumberOfConsecutiveAppointmentsRequired) = (appointmentId, 1);

        public BaseRequest(Guid appointmentId, List<BookingResource> optionalResources)
          => (AppointmentId, OptionalResources, NumberOfConsecutiveAppointmentsRequired) = (appointmentId, optionalResources, 1);

        [Required]
        public Guid AppointmentId { get; set; }

        public int NumberOfConsecutiveAppointmentsRequired { get; set; } = 1;

        public List<BookingResource> OptionalResources { get; set; }

    }
}
