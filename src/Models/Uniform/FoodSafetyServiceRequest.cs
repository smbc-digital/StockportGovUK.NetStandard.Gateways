using StockportGovUK.NetStandard.Gateways.Models.Verint;
using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Uniform;

public class FoodSafetyServiceRequest
{
    public string ComplaintType { get; set; }
    public string Description { get; set; }
    public string BusinessName { get; set; }
    public Address BusinessAddress { get; set; }
    public Address CustomerAddress { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime IncidentDate { get; set; }
    public string IncidentTime { get; set; }
}