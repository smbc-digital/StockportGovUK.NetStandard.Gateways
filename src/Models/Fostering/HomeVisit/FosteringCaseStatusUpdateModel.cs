using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.HomeVisit
{
    public class FosteringCaseStatusUpdateModel
    {
        public string CaseId { get; set; }

        public ETaskStatus Status { get; set; }

        public EFosteringHomeVisitForm Form { get; set; }
    }
}
