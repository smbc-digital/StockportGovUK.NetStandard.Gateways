using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking
{
    public class AvailableAppointment
    {
        public Guid Id { get; set; }

        public Guid? AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public Guid? TimePeriodPolicyId { get; set; }

        public TimePeriodPolicy TimePeriodPolicy { get; set; }

        public int? MaxOfType { get; set; }
    }
}
