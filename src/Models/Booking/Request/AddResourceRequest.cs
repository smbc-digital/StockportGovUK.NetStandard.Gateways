﻿using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class AddResourceRequest
    {
        public Guid UserId { get; set; }

        public Resource Resource { get; set; }
    }

    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? BookingContextId { get; set; }
        public int DisplayIndex { get; set; }
        public string AdditionalInformation { get; set; }
        public string ResourceAdjustmentHeader { get; set; }
        public string ResourceAdjustmentHelpText { get; set; }
    }
}
