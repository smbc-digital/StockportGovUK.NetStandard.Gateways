using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.HomeVisit
{
    public class FosteringCasePartnershipStatusUpdateModel
    {
        public string CaseReference { get; set; }

        public bool? MarriedOrInACivilPartnership { get; set; }

        public DateTime? DateOfMarriage { get; set; }

        public DateTime? DateMovedInTogether { get; set; }
    }
}
