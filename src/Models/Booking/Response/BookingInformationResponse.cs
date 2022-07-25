using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Response
{
    public class BookingInformationResponse
    {
        public Guid Id { get; set; }
        public string AppointmentName { get; set; }
        public bool CanCustomerCancel { get; set; }
        public bool CanAdminCancel { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
        public bool IsFullDay => Duration.Hours >= 6 &&
            StartTime.Hours < 12 &&
            EndTime.Hours > 12;
        public string Location { get; set; }

        public bool IsCancelled { get; set; }
    }
}
