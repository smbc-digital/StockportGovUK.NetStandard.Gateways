using System;
using System.Collections.Generic;
using System.Linq;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Response
{
    public class AvailabilityDayResponse
    {
        public DateTime Date { get; set; }
        public List<AppointmentTime> AppointmentTimes { get; set; } = new List<AppointmentTime>();
        public bool HasAvailableAppointment => AppointmentTimes.Any();
        public bool IsFullDayAppointment => AppointmentTimes.Count == 1 &&
            AppointmentTimes.First().Duration.Hours >= 6 &&
            AppointmentTimes.First().StartTime.Hours < 12 &&
            AppointmentTimes.First().EndTime.Hours > 12;
    }

    public class AppointmentTime
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
    }
}
