using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class ReserveAndConfirmBookingRequest : BookingRequest
    {
        public ReserveAndConfirmBookingRequest() : base() { }

        public ReserveAndConfirmBookingRequest(Customer customer, DateTime startDateTime, Guid appointmentId, DateTime appointmentSearchEndDateTime)
            : base(customer, startDateTime, appointmentId) => AppointmentSearchEndDateTime = appointmentSearchEndDateTime;

        [Required]
        public DateTime AppointmentSearchEndDateTime { get; set; } = DateTime.Today.AddMonths(3);
    }
}
