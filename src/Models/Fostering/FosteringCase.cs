using System;
using System.Collections.Generic;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Fostering
{
    public class FosteringCase
    {
        public FosteringCaseStatuses Statuses { get; set; }

        public FosteringApplicant FirstApplicant { get; set; }

        public FosteringApplicant SecondApplicant { get; set; }

        public bool? AnyOtherPeopleInYourHousehold { get; set; }

        public bool? DoYouHaveAnyPets { get; set; }

        public string PetsInformation { get; set; }

        public List<OtherPerson> OtherPeopleInYourHousehold { get; set; }

        public string WithPartner { get; set; }

        public string PrimaryLanguage { get; set; }

        public string OtherLanguages { get; set; }

        public bool? MarriedOrInACivilPartnership { get; set; }

        public DateTime? DateOfMarriage { get; set; }

        public DateTime? DateMovedInTogether { get; set; }

        public string ReasonsForFostering { get; set; }

        public List<string> TypesOfFostering { get; set; }

        public DateTime? HomeVisitDateTime { get; set; }

        public bool EnableAdditionalInformationSection { get; set; }

        public bool IsApplicationCompleted { get; set; }

        public ReferenceDetails FamilyReference { get; set; }

        public ReferenceDetails FirstPersonalReference { get; set; }

        public ReferenceDetails SecondPersonalReference { get; set; }
    }

    public class FosteringApplicant
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool? EverBeenKnownByAnotherName { get; set; }

        public string Nationality { get; set; }

        public string Ethnicity { get; set; }

        public string Gender { get; set; }

        public string AnotherName { get; set; }

        public string Religion { get; set; }

        public string PlaceOfBirth { get; set; }

        public bool? AreYouEmployed { get; set; }

        public string CurrentEmployer { get; set; }

        public string JobTitle { get; set; }

        public EHoursOfWork CurrentHoursOfWork { get; set; }

        public bool? PreviouslyApplied { get; set; }

        public bool? RegisteredDisabled { get; set; }

        public bool? Practitioner { get; set; }

        public bool? AnyChildrenUnderSixteen { get; set; }

        public List<OtherPerson> ChildrenUnderSixteenLivingAwayFromHome { get; set; }

        public bool? AnyChildrenOverSixteen { get; set; }

        public List<OtherPerson> ChildrenOverSixteenLivingAwayFromHome { get; set; }

        public string NameOfGp { get; set; }

        public string NameOfGpPractice { get; set; }

        public string GpPhoneNumber { get; set; }

        public Address GpAddress { get; set; }

        public bool? HasContactWithCouncillor { get; set; }

        public List<CouncillorRelationshipDetails> CouncillorRelationshipDetails { get; set; }

        public List<PreviousAddress> AddressHistory { get; set; }
    }

    public class FosteringCaseStatuses
    {
        public ETaskStatus TellUsAboutYourselfStatus { get; set; }

        public ETaskStatus YourEmploymentDetailsStatus { get; set; }

        public ETaskStatus LanguageSpokenInYourHomeStatus { get; set; }

        public ETaskStatus YourPartnershipStatus { get; set; }

        public ETaskStatus YourFosteringHistoryStatus { get; set; }

        public ETaskStatus YourHealthStatus { get; set; }

        public ETaskStatus TellUsAboutYourInterestInFosteringStatus { get; set; }

        public ETaskStatus YourHouseholdStatus { get; set; }

        public ETaskStatus ChildrenLivingAwayFromYourHomeStatus { get; set; }

        public ETaskStatus ReferencesStatus { get; set; }

        public ETaskStatus GpDetailsStatus { get; set; }

        public ETaskStatus CouncillorsOrEmployeesStatus { get; set; }

        public ETaskStatus AddressHistoryStatus { get; set; }
    }

    public class OtherPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string RelationshipToYou { get; set; }

        public Address Address { get; set; }
    }

    public class ReferenceDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RelationshipToYou { get; set; }

        public string NumberOfYearsKnown { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }

    public class PreviousAddress
    {
        public DateTime? DateFrom { get; set; }

        public InternationalAddress Address { get; set; }
    }

    public class InternationalAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        public string Postcode { get; set; }
    }

    public class Address
    {
        public string SelectedAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string Postcode { get; set; }

        public string PlaceRef { get; set; }
    }

    public class CouncillorRelationshipDetails
    {
        public string CouncillorName { get; set; }

        public string Relationship { get; set; }
    }
}