namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.Application
{
    public class FosteringCaseReferenceUpdateModel
    {
        public string CaseReference { get; set; }

        public ReferenceDetails FamilyReference { get; set; }

        public ReferenceDetails FirstPersonalReference { get; set; }

        public ReferenceDetails SecondPersonalReference { get; set; }
    }
}
