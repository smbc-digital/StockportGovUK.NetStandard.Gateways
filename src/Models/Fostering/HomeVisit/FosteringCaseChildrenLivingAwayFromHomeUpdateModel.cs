using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.HomeVisit
{
    public class FosteringCaseChildrenLivingAwayFromHomeUpdateModel
    {
        public string CaseReference { get; set; }

        public FosteringCaseChildrenLivingAwayFromHomeApplicantUpdateModel FirstApplicant { get; set; }

        public FosteringCaseChildrenLivingAwayFromHomeApplicantUpdateModel SecondApplicant { get; set; }

    }

    public class FosteringCaseChildrenLivingAwayFromHomeApplicantUpdateModel
    {
        public bool? AnyChildrenUnderSixteen { get; set; }

        public List<OtherPerson> ChildrenUnderSixteenLivingAwayFromHome { get; set; }

        public bool? AnyChildrenOverSixteen { get; set; }

        public List<OtherPerson> ChildrenOverSixteenLivingAwayFromHome { get; set; }
    }
}
