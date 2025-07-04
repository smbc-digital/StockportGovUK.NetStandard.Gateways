using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class EmailTemplate
{
    public bool IsDefaultTemplate { get; set; }
    public Guid ContextId { get; set; }
    public Guid? TemplateId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public Guid? AppointmentId { get; set; }
    public Guid? EmailTypeId { get; set; }
    public string EmailTypeName { get; set; }
}
