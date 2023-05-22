using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Note
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    [Required(ErrorMessage ="Note is required")]
    public string Text { get; set; }
    public Guid? BookingId { get; set; }
    public Guid? CreatedById { get; set; }
    public string CreatedBy { get; set; }
    public bool? SystemGenerated { get; set; }
}