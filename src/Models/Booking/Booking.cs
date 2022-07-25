using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string HashedId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
