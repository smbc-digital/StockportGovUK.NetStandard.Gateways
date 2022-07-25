namespace StockportGovUK.NetStandard.Gateways.Models
{
    public class FosteringCaseYourFosteringHistoryUpdateModel
    {
        public string CaseReference { get; set; }

        public FosteringCaseYourFosteringHistoryApplicationUpdateModel FirstApplicant { get; set; }

        public FosteringCaseYourFosteringHistoryApplicationUpdateModel SecondApplicant { get; set; }
    }

    public class FosteringCaseYourFosteringHistoryApplicationUpdateModel
    {
        public bool? PreviouslyApplied { get; set; }
    }
}
