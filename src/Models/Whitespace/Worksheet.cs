using System;
using StockportGovUK.NetStandard.Gateways.Enums.Whitespace;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;
public class Worksheet
{
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public int AssignedToId { get; set; }
    public int AssignedToTypeId { get; set; }
    public string AssignedToName { get; set; }
    public EWorksheetSubject? Subject { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
    public int ReportedByContactId { get; set; }
    public string ReportedByName { get; set; }
    public int ReportedByAddressId { get; set; }
    public string ReportedByAddress { get; set; }
    public int WorkLocationAddressId { get; set; }
    public string WorkLocationName { get; set; }
    public string WorkLocationAddress { get; set; }
    public string ChargeName { get; set; }
    public int ChargeAddressId { get; set; }
    public string ChargeAddress { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueByDate { get; set; }
    public DateTime EscalatedDate { get; set; }
    public DateTime CompletedDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public DateTime ApprovedDate { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentReference { get; set; }
    public int ImportanceId { get; set; }
    public string ImportanceName { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public string CompletionNotes { get; set; }
    public string Guid { get; set; }
    public string Ref { get; set; }
    public int ParentId { get; set; }
    public string WorkLocationText { get; set; }
    public int RecordPosition { get; set; }
    public string ImportationReference { get; set; }
    public double WorkLocationLatitude { get; set; }
    public double WorkLocationLongitude { get; set; }
    public double WorkLocationNorthing { get; set; }
    public double WorkLocationEasting { get; set; }
    public bool ForAction { get; set; }
    public string LastEventName { get; set; }
}
