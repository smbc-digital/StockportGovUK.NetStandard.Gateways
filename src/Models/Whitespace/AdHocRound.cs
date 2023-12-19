using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;

public class AdHocRound
{
    public int Id { get; set; }
    public int RoundAreaId { get; set; }
    public int ServiceId { get; set; }
    public int ScheduleId { get; set; }
    public string AdHocRoundCode { get; set; }
    public string RoundAreaName { get; set; }
    public string ServiceName { get; set; }
    public string ScheduleName { get; set; }
    public string AdHocRoundNotes { get; set; }
    public DateTime AdHocRoundDate { get; set; }
    public DateTime? AdHocRoundCompletedDate { get; set; }
    public int SlotsFree { get; set; }
    public int SlotsTaken { get; set; }
}
