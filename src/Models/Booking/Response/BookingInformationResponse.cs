using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Response
{
    public class BookingInformationResponse
    {
        public Guid Id { get; set; }
        public string AppointmentName { get; set; }
        public Guid AppointmentId { get; set; }
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
        public string TicketNumber { get; set; }
        public decimal? FeePaid { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public Customer Customer { get; set; }
        public Guid? StatusId { get; set; }
        public IEnumerable<BookingResource> BookingResources { get; set; }

    }
}
