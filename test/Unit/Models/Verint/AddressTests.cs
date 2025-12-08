using StockportGovUK.NetStandard.Gateways.Models.Verint;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models.Verint
{
    public class AddressTests
    {
        [Fact]
        public void Address_WithReferenceAndDescription_ShouldSetProperties()
        {
            Address address = new("123456", "Test Description");

            Assert.Equal("123456", address.Reference);
            Assert.Equal("Test Description", address.Description);
        }

        [Fact]
        public void Address_ShouldMapFields_WhenPlaceRefIsNull()
        {
            Gateways.Models.Addresses.Address source = new()
            {
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                Town = "Town",
                Postcode = "SK1 1AA",
                PlaceRef = null
            };

            Address address = new(source);

            Assert.Equal("AddressLine1", address.AddressLine1);
            Assert.Equal("AddressLine2", address.AddressLine2);
            Assert.Equal("Town", address.AddressLine3);
            Assert.Equal("SK1 1AA", address.Postcode);
            Assert.Null(address.UPRN);
            Assert.Null(address.Reference);
            Assert.Null(address.Description);
        }

        [Fact]
        public void Address_ShouldMapFields_WhenPlaceRefIsNotNull()
        {
            Gateways.Models.Addresses.Address source = new()
            {
                SelectedAddress = "1 Test Street",
                Postcode = "SK1 1AA",
                PlaceRef = "123456"
            };

            Address address = new(source);

            Assert.Equal("123456", address.UPRN);
            Assert.Equal("123456", address.Reference);
            Assert.Equal("1 Test Street", address.Description);
            Assert.Equal("SK1 1AA", address.Postcode);
        }

        [Fact]
        public void IsFullyResolved_ShouldReturnTrue_WhenAllRequiredFieldsAreSet()
        {
            Address address = new()
            {
                Number = "1",
                AddressLine1 = "Test Street",
                City = "Stockport",
                Postcode = "SK1 1AA"
            };

            Assert.True(address.IsFullyResolved);
        }

        [Fact]
        public void IsFullyResolved_ShouldReturnFalse_WhenAnyRequiredFieldIsMissing()
        {
            Address address = new()
            {
                Number = "1",
                AddressLine1 = "Test Street",
                City = null,
                Postcode = "SK1 1AA"
            };

            Assert.False(address.IsFullyResolved);
        }

        [Fact]
        public void Address_ToString_ShouldReturnConcatenatedFields()
        {
            Address address = new()
            {
                Number = "1",
                BusinessName = "Shop",
                AddressLine1 = "Test Street",
                AddressLine2 = "AddressLine2",
                AddressLine3 = "AddressLine3",
                City = "Stockport",
                Postcode = "SK1 1AA"
            };

            string result = address.ToString();

            Assert.Equal("1, Shop, Test Street, AddressLine2, AddressLine3, Stockport, SK1 1AA", result);
        }
    }
}