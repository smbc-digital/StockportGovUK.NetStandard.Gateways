using StockportGovUK.NetStandard.Gateways.Models.Verint;
using System;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models.Verint
{
    public class CaseTests
    {
        [Fact]
        public void Constructor_ShouldInitialiseCollectionsAndDefaults()
        {
            Case crmCase = new();

            Assert.NotEqual(Guid.Empty, crmCase.ID);
            Assert.NotNull(crmCase.IntegrationFormFields);
            Assert.NotNull(crmCase.CaseFormFields);
            Assert.NotNull(crmCase.CustomAttributes);
            Assert.NotNull(crmCase.NotesWithAttachments);
            Assert.Equal(string.Empty, crmCase.CaseReference);
            Assert.Equal(RaisedByBehaviourEnum.Individual, crmCase.RaisedByBehaviour);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(123, true)]
        public void HasEventCode_ShouldReturnExpected(int code, bool expected)
        {
            Case crmCase = new() { EventCode = code };
            
            Assert.Equal(expected, crmCase.HasEventCode);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnExplicitValue_WhenSet()
        {
            Case crmCase = new() { AssociatedWithBehaviour = AssociatedWithBehaviourEnum.Property };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Property, crmCase.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnStreet_WhenStreetReferenceExists()
        {
            Case crmCase = new() { Street = new Street { Reference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Street, crmCase.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnProperty_WhenPropertyReferenceExists()
        {
            Case crmCase = new() { Property = new Address { Reference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Property, crmCase.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnOrganisation_WhenOrganisationReferenceExists()
        {
            Case crmCase = new() { Organisation = new Organisation { Reference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Organisation, crmCase.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnIndividual_WhenCustomerReferenceExists()
        {
            Case crmCase = new() { Customer = new Customer { CustomerReference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Individual, crmCase.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnNon_WhenNoReferencesExist()
        {
            Case crmCase = new();
            
            Assert.Equal(AssociatedWithBehaviourEnum.Non, crmCase.AssociatedWithBehaviour);
        }

        [Fact]
        public void SearchForIntegrationFormField_ShouldReturnField_WhenExists()
        {
            Case crmCase = new();

            crmCase.IntegrationFormFields.Add(new CustomField("Field1", "Value1"));

            CustomField result = crmCase.SearchForIntegrationFormField("Field1");

            Assert.NotNull(result);
            Assert.Equal("Value1", result.Value);
        }

        [Fact]
        public void SearchForIntegrationFormField_ShouldReturnNull_WhenNotFound()
        {
            Case crmCase = new();
            CustomField result = crmCase.SearchForIntegrationFormField("Missing");
            
            Assert.Null(result);
        }

        [Fact]
        public void SearchForCaseFormFields_ShouldReturnField_WhenExists()
        {
            Case crmCase = new();
            crmCase.CaseFormFields.Add(new CustomField("Field1", "Value1"));

            CustomField result = crmCase.SearchForCaseFormFields("Field1");

            Assert.NotNull(result);
            Assert.Equal("Value1", result.Value);
        }

        [Fact]
        public void SetCustomFieldValue_ShouldUpdateValue_WhenFieldExists()
        {
            Case crmCase = new();
            crmCase.CaseFormFields.Add(new CustomField("Key1", "OldValue"));

            crmCase.SetCustomFieldValue("Key1", "NewValue");

            Assert.Equal("NewValue", crmCase.CaseFormFields[0].Value);
        }

        [Fact]
        public void SetCustomFieldValue_ShouldDoNothing_WhenFieldNotFound()
        {
            Case crmCase = new();
            crmCase.CaseFormFields.Add(new CustomField("Key1", "OldValue"));

            crmCase.SetCustomFieldValue("OtherKey", "NewValue");

            Assert.Equal("OldValue", crmCase.CaseFormFields[0].Value);
        }

        [Fact]
        public void AddCaseFormFieldIfNotNullOrEmpty_ShouldAddField_WhenValueIsNotEmpty()
        {
            Case crmCase = new();
            crmCase.AddCaseFormFieldIfNotNullOrEmpty("Key1", "Value1");

            Assert.Single(crmCase.CaseFormFields);
            Assert.Equal("Value1", crmCase.CaseFormFields[0].Value);
        }

        [Fact]
        public void AddCaseFormFieldIfNotNullOrEmpty_ShouldNotAddField_WhenValueIsEmpty()
        {
            Case crmCase = new();
            crmCase.AddCaseFormFieldIfNotNullOrEmpty("Key1", string.Empty);

            Assert.Empty(crmCase.CaseFormFields);
        }

        [Fact]
        public void CustomAttributeValue_ShouldReturnValue_WhenAttributeExists()
        {
            Case crmCase = new();
            crmCase.CustomAttributes.Add(new CustomField("Attr1", "Val1"));

            string result = crmCase.CustomAttributeValue("Attr1");

            Assert.Equal("Val1", result);
        }

        [Fact]
        public void CustomAttributeValue_ShouldReturnNull_WhenAttributeNotFound()
        {
            Case crmCase = new();

            string result = crmCase.CustomAttributeValue("Missing");
            
            Assert.Null(result);
        }

        [Fact]
        public void SetCustomAttribute_ShouldReplaceExistingAttribute()
        {
            Case crmCase = new();
            crmCase.CustomAttributes.Add(new CustomField("Attr1", "Value"));

            crmCase.SetCustomAttribute("Attr1", "NewValue");

            Assert.Single(crmCase.CustomAttributes);
            Assert.Equal("NewValue", crmCase.CustomAttributes[0].Value);
        }

        [Fact]
        public void SetCustomAttribute_ShouldAddNewAttribute_WhenNotExists()
        {
            Case crmCase = new();
            crmCase.SetCustomAttribute("Attr1", "Value");

            Assert.Single(crmCase.CustomAttributes);
            Assert.Equal("Value", crmCase.CustomAttributes[0].Value);
        }
    }
}
