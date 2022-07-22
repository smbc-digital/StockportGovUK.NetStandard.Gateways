namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.HomeVisit
{
    public class FosteringCaseAboutYourselfUpdateModel
    {
        public string CaseReference { get; set; }

        public FosteringCaseAboutYourselfApplicantUpdateModel FirstApplicant { get; set; }

        public FosteringCaseAboutYourselfApplicantUpdateModel SecondApplicant { get; set; }
    }

    public class FosteringCaseAboutYourselfApplicantUpdateModel
    {
        public bool? EverBeenKnownByAnotherName { get; set; }

        public string Nationality { get; set; }

        public string Ethnicity { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Gender { get; set; }

        public string AnotherName { get; set; }

        public string Religion { get; set; }
    }
}
