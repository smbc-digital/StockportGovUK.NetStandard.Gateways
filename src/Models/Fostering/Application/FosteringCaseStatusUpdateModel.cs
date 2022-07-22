using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.Application
{
    public class FosteringCaseStatusUpdateModel
    {
        public string CaseId { get; set; }

        public ETaskStatus Status { get; set; }

        public EFosteringApplicationForm Form { get; set; }
    }
}
