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
            Case c = new();

            Assert.NotEqual(Guid.Empty, c.ID);
            Assert.NotNull(c.IntegrationFormFields);
            Assert.NotNull(c.CaseFormFields);
            Assert.NotNull(c.CustomAttributes);
            Assert.NotNull(c.NotesWithAttachments);
            Assert.Equal(string.Empty, c.CaseReference);
            Assert.Equal(RaisedByBehaviourEnum.Individual, c.RaisedByBehaviour);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(123, true)]
        public void HasEventCode_ShouldReturnExpected(int code, bool expected)
        {
            Case c = new() { EventCode = code };
            
            Assert.Equal(expected, c.HasEventCode);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnExplicitValue_WhenSet()
        {
            Case c = new() { AssociatedWithBehaviour = AssociatedWithBehaviourEnum.Property };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Property, c.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnStreet_WhenStreetReferenceExists()
        {
            Case c = new() { Street = new Street { Reference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Street, c.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnProperty_WhenPropertyReferenceExists()
        {
            Case c = new() { Property = new Address { Reference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Property, c.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnOrganisation_WhenOrganisationReferenceExists()
        {
            Case c = new() { Organisation = new Organisation { Reference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Organisation, c.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnIndividual_WhenCustomerReferenceExists()
        {
            Case c = new() { Customer = new Customer { CustomerReference = "123456" } };
            
            Assert.Equal(AssociatedWithBehaviourEnum.Individual, c.AssociatedWithBehaviour);
        }

        [Fact]
        public void AssociatedWithBehaviour_ShouldReturnNon_WhenNoReferencesExist()
        {
            Case c = new();
            
            Assert.Equal(AssociatedWithBehaviourEnum.Non, c.AssociatedWithBehaviour);
        }

        [Fact]
        public void SearchForIntegrationFormField_ShouldReturnField_WhenExists()
        {
            Case c = new();

            c.IntegrationFormFields.Add(new CustomField("Field1", "Value1"));

            CustomField result = c.SearchForIntegrationFormField("Field1");

            Assert.NotNull(result);
            Assert.Equal("Value1", result.Value);
        }

        [Fact]
        public void SearchForIntegrationFormField_ShouldReturnNull_WhenNotFound()
        {
            Case c = new();
            CustomField result = c.SearchForIntegrationFormField("Missing");
            
            Assert.Null(result);
        }

        [Fact]
        public void SearchForCaseFormFields_ShouldReturnField_WhenExists()
        {
            Case c = new();
            c.CaseFormFields.Add(new CustomField("Field1", "Value1"));

            CustomField result = c.SearchForCaseFormFields("Field1");

            Assert.NotNull(result);
            Assert.Equal("Value1", result.Value);
        }

        [Fact]
        public void SetCustomFieldValue_ShouldUpdateValue_WhenFieldExists()
        {
            Case c = new();
            c.CaseFormFields.Add(new CustomField("Key1", "OldValue"));

            c.SetCustomFieldValue("Key1", "NewValue");

            Assert.Equal("NewValue", c.CaseFormFields[0].Value);
        }

        [Fact]
        public void SetCustomFieldValue_ShouldDoNothing_WhenFieldNotFound()
        {
            Case c = new();
            c.CaseFormFields.Add(new CustomField("Key1", "OldValue"));

            c.SetCustomFieldValue("OtherKey", "NewValue");

            Assert.Equal("OldValue", c.CaseFormFields[0].Value);
        }

        [Fact]
        public void AddCaseFormFieldIfNotNullOrEmpty_ShouldAddField_WhenValueIsNotEmpty()
        {
            Case c = new();
            c.AddCaseFormFieldIfNotNullOrEmpty("Key1", "Value1");

            Assert.Single(c.CaseFormFields);
            Assert.Equal("Value1", c.CaseFormFields[0].Value);
        }

        [Fact]
        public void AddCaseFormFieldIfNotNullOrEmpty_ShouldNotAddField_WhenValueIsEmpty()
        {
            Case c = new();
            c.AddCaseFormFieldIfNotNullOrEmpty("Key1", string.Empty);

            Assert.Empty(c.CaseFormFields);
        }

        [Fact]
        public void CustomAttributeValue_ShouldReturnValue_WhenAttributeExists()
        {
            Case c = new();
            c.CustomAttributes.Add(new CustomField("Attr1", "Val1"));

            string result = c.CustomAttributeValue("Attr1");

            Assert.Equal("Val1", result);
        }

        [Fact]
        public void CustomAttributeValue_ShouldReturnNull_WhenAttributeNotFound()
        {
            Case c = new();

            string result = c.CustomAttributeValue("Missing");
            
            Assert.Null(result);
        }

        [Fact]
        public void SetCustomAttribute_ShouldReplaceExistingAttribute()
        {
            Case c = new();
            c.CustomAttributes.Add(new CustomField("Attr1", "Value"));

            c.SetCustomAttribute("Attr1", "NewValue");

            Assert.Single(c.CustomAttributes);
            Assert.Equal("NewValue", c.CustomAttributes[0].Value);
        }

        [Fact]
        public void SetCustomAttribute_ShouldAddNewAttribute_WhenNotExists()
        {
            Case c = new();
            c.SetCustomAttribute("Attr1", "Value");

            Assert.Single(c.CustomAttributes);
            Assert.Equal("Value", c.CustomAttributes[0].Value);
        }
    }
}
