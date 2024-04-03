using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;
public class RoundIncident
{
    public string RoundCode { get; set; }
    public string ScheduleName { get; set; }
    public string ServiceName { get; set; }
    public string RoundAreaName { get; set; }
    public DateTime RoundIncidentDate { get; set; }
    public string RoundIncidentNotes { get; set; }
}
