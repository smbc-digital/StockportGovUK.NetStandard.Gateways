using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models.Addresses
{
    public class AddressSearchResultTests
    {
        [Fact]
        public void Name_ShouldReturnName_WhenSet()
        {
            AddressSearchResult result = new()
            {
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                AddressLine3 = "AddressLine3",
                Postcode = "SK1 1AA",
                Name = "Name"
            };

            Assert.Equal("Name", result.Name);
        }

        [Fact]
        public void Name_ShouldReturnConcatenatedAddress_WhenNameIsNullOrEmpty()
        {
            AddressSearchResult result = new()
            {
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                AddressLine3 = "AddressLine3",
                Postcode = "SK1 1AA",
                Name = null
            };

            Assert.Equal("AddressLine1, AddressLine2, AddressLine3, SK1 1AA", result.Name);
        }

        [Fact]
        public void Name_ShouldReturnConcatenatedAddress_WhenNameIsEmptyString()
        {
            AddressSearchResult result = new()
            {
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                AddressLine3 = "AddressLine3",
                Postcode = "SK1 1AA",
                Name = string.Empty
            };

            Assert.Equal("AddressLine1, AddressLine2, AddressLine3, SK1 1AA", result.Name);
        }
    }
}