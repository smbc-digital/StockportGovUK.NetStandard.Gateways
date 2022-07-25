using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using StockportGovUK.NetStandard.Gateways.Attributes;

namespace StockportGovUK.NetStandard.Gateways.Models.Fostering.Application
{
    public class FosteringCaseCouncillorsUpdateModel
    {
        [Required]
        public string CaseReference { get; set; }

        [Required]
        public FosteringCaseCouncillorsApplicantUpdateModel FirstApplicant { get; set; }

        public FosteringCaseCouncillorsApplicantUpdateModel SecondApplicant { get; set; }
    }

    public class FosteringCaseCouncillorsApplicantUpdateModel
    {
        [Required]
        public bool HasContactWithCouncillor { get; set; }

        private List<CouncillorRelationshipDetailsUpdateModel> _councillorRelationshipDetails;

        [RequiredIf("HasContactWithCouncillor", "The HasContactWithCouncillor field is required.")]
        public List<CouncillorRelationshipDetailsUpdateModel> CouncillorRelationshipDetails
        {
            get => _councillorRelationshipDetails;

            set
            {
                _councillorRelationshipDetails = new List<CouncillorRelationshipDetailsUpdateModel>();
                value.ForEach(_ => _councillorRelationshipDetails.Add(new CouncillorRelationshipDetailsUpdateModel
                {
                    CouncillorName = _.CouncillorName,
                    Relationship = _.Relationship,
                    IsRequired = HasContactWithCouncillor
                }));
            }
        }
    }


    public class CouncillorRelationshipDetailsUpdateModel
    {
        [IgnoreDataMember]
        public bool IsRequired { get; set; }

        [RequiredIf("IsRequired", "The CouncillorName field is required.")]
        public string CouncillorName { get; set; }

        [RequiredIf("IsRequired", "The Relationship field is required.")]
        public string Relationship { get; set; }
    }
}
