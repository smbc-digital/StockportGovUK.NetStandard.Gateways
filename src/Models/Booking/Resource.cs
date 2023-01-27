using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Resource
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? BookingContextId { get; set; }
    public int DisplayIndex { get; set; }
    public string AdditionalInformation { get; set; }
    public string ResourceAdjustmentHeader { get; set; }
    public string ResourceAdjustmentHelpText { get; set; }
    public List<ResourceModifier> ResourceModifiers { get; set; }
}