using System;
using System.Collections.Generic;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Confirmed { get; set; }
        public bool Cancelled { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateConfirmed { get; set; }
        public DateTime DateModified { get; set; }
        public string AdditionalInformation { get; set; }
        public TimeSpan Duration { get; set; }
        public int ParallelQuantity { get; set; }
        public int ConsecutiveQuantity { get; set; }
        public Guid GroupId { get; set; }
        public Guid? AppointmentId { get; set; }
        public string AppointmentName { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid? StatusId { get; set; }
        public string StatusName { get; set; }
        public decimal? FeePaid { get; set; }
        public Guid ContextId { get; set; }
        public DateTime? LatestCancellationDate { get; set; }
        public DateTime? LatestRescheduleDate { get; set; }
        public DateTime? ArrivedTime { get; set; }
        public DateTime? SeenTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public bool? UnplannedAppointment { get; set; }
        public string SeenBy { get; set; }
        public Guid? TicketId { get; set; }
        public string TicketNumber { get; set; }
        public string BookingOfficer { get; set; }
        public bool DidNotAttend { get; set; }
        public DateTime? EmailReminderSentDateTime { get; set; }
        
        public IEnumerable<BookingResource> BookingResources { get; set; }
        public IEnumerable<ForeignReference> ForeignReferences { get; set; }
        public IEnumerable<MetaDataValue> MetaDataValues { get; set; }
        public IEnumerable<Note> Notes { get; set; }

        // These already existed and are used by Formbuilder and Services so leaving in until we plan in a refactor
        public string HashedId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
