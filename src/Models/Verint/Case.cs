using System;
using System.Collections.Generic;
using System.Linq;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Eforms;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint
{
    public class Case
    {

        private AssociatedWithBehaviourEnum? _AssociatedWithBehaviour;

        public Case()
        {
            this.ID = Guid.NewGuid();
            this.IntegrationFormFields = new List<CustomField>();
            this.CaseFormFields = new List<CustomField>();
            this.CustomAttributes = new List<CustomField>();
            this.CaseReference = string.Empty;
            this.RaisedByBehaviour = RaisedByBehaviourEnum.Individual;
            this.NotesWithAttachments = new List<NoteWithAttachments>();

        }

        public Guid ID { get; set; }

        public bool AnonymousSubmission { get; set; }

        public Customer Customer { get; set; }

        public Organisation Organisation { get; set; }

        public string DefinitionName { get; set; }

        public string IntegrationFormName { get; set; }

        public List<CustomField> IntegrationFormFields { get; set; }

        public List<CustomField> CaseFormFields { get; set; }

        public List<Note> Notes { get; set; }

        public List<NoteWithAttachments> NotesWithAttachments { get; set; }

        public bool UploadNotesWithAttachmentsAfterCaseCreation { get; set; }

        public string FormName { get; set; }

        public string EventTitle { get; set; }

        public int EventCode { get; set; }

        public string EventId { get; set; }

        public string Status { get; set; }

        public DateTime EventDate { get; set; }

        public bool HasEventCode
        {
            get
            {
                return this.EventCode != 0;
            }
        }

        public string EventFurtherInformation { get; set; }

        public Street Street { get; set; }

        public Address Property { get; set; }

        public string FurtherLocationInformation { get; set; }

        public string Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string CaseReference { get; set; }

        public long InteractionReference { get; set; }

        public string Queue { get; set; }

        public string Classification { get; set; }

        public string EnquirySubject { get; set; }

        public string EnquiryReason { get; set; }

        public string EnquiryType { get; set; }

        public List<CustomField> CustomAttributes { get; set; }

        public bool IsSMBCEmployee { get; set; }

        public string SMBCChannel { get; set; }

        public string CaseTitle { get; set; }

        public BaseEform Eform { get; set; }

        public DestinationSystem DestinationSystem { get; set; }

        public Guid BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public string BookingTime { get; set; }

        public decimal Price { get; set; }

        public string PaymentRef { get; set; }

        public List<string> LinkCases { get; set; }

        public RaisedByBehaviourEnum RaisedByBehaviour { get; set; }

        public AssociatedWithBehaviourEnum AssociatedWithBehaviour
        {
            get
            {
                if (_AssociatedWithBehaviour != null)
                {
                    return _AssociatedWithBehaviour.Value;
                }

                // TODO: If all else fails match to the RaisedBy Behaviour

                if (Street != null && Street.Reference != null)
                {
                    return AssociatedWithBehaviourEnum.Street;
                }

                if (Property != null && Property.Reference != null)
                {
                    return AssociatedWithBehaviourEnum.Property;
                }

                if (Organisation != null && Organisation.Reference != null)
                {
                    return AssociatedWithBehaviourEnum.Organisation;
                }

                if (Customer != null && Customer.CustomerReference != null)
                {
                    return AssociatedWithBehaviourEnum.Individual;
                }

                return AssociatedWithBehaviourEnum.Non;
            }
            set
            {
                _AssociatedWithBehaviour = value;
            }
        }

        public CustomField SearchForIntegrationFormField(string fieldName)
        {
            CustomField result = IntegrationFormFields.Find(
                                delegate (CustomField cf)
                                {
                                    return cf.Name == fieldName;
                                });

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public CustomField SearchForCaseFormFields(string fieldName)
        {
            CustomField result = CaseFormFields.Find(
                                delegate (CustomField cf)
                                {
                                    return cf.Name == fieldName;
                                });

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public void SetCustomFieldValue(string key, string value)
        {
            var customField = SearchForCaseFormFields(key);
            if (customField != null)
            {
                customField.Value = value;
            }
        }

        public string CustomAttributeValue(string customAttributeName)
        {
            return this.CustomAttributes.Where(x => x.Name.Equals(customAttributeName)).Select(x => x.Value).SingleOrDefault();
        }

        public void SetCustomAttribute(string customAttributeName, string customAttributeValue)
        {
            var existingAttribute = this.CustomAttributes.Where(x => x.Name.Equals(customAttributeName)).SingleOrDefault();

            if (existingAttribute != null)
                this.CustomAttributes.Remove(existingAttribute);

            this.CustomAttributes.Add(new CustomField(customAttributeName, customAttributeValue));
        }

    }
}
