using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class RelateBookingsRequest
{
    public Guid MainBookingId { get; set; }
    public List<Guid> RelatedBookingIds { get; set; }
}
