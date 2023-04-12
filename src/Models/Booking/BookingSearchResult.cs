using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class BookingSearchResult
{
    public Guid BookingId { get; set; }
    public DateTime BookingDate { get; set; }
    public string AppointmentType { get; set; }
    public string CustomerName { get; set; }
    public DateTime DateCreated { get; set; }
    public string StatusName { get; set; }
    public bool Confirmed { get; set; }
    public bool Cancelled { get; set; }
    public bool IsTimedOut { get; set; }
}
