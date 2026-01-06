using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models.Addresses
{
    public class AddressTests
    {
        [Theory]
        [InlineData("1 Test Street", true)]
        [InlineData(null, false)]
        public void IsAutomaticallyFound_ShouldMatchSelectedAddress(string selected, bool expected)
        {
            Address address = new() { SelectedAddress = selected };
            
            Assert.Equal(expected, address.IsAutomaticallyFound);
        }

        [Fact]
        public void ToString_ReturnsSelectedAddressWithPlaceRef_WhenPlaceRefExists()
        {
            Address address = new() { SelectedAddress = "1 Test Street", PlaceRef = "123" };
            
            Assert.Equal("1 Test Street,(123)", address.ToString());
        }

        [Fact]
        public void ToString_ReturnsFullAddress_WhenNoPlaceRef()
        {
            Address address = new() { AddressLine1 = "AddressLine1", AddressLine2 = "AddressLine2", Town = "Town", Postcode = "SK1 1AA" };
            
            Assert.Equal("AddressLine1, AddressLine2, Town, SK1 1AA", address.ToString());
        }

        [Theory]
        [InlineData("1 Test Street", "XYZ", "1 Test Street")]
        [InlineData("AddressLine1", "", "AddressLine1, Town, SK1 1AA")]
        [InlineData("AddressLine1", "AddressLine2", "AddressLine1, AddressLine2, Town, SK1 1AA")]
        public void ToStringWithoutPlaceRef_CoversAllBranches(string line1OrSelected, string line2, string expected)
        {
            Address address = new()
            {
                SelectedAddress = expected.Equals("1 Test Street") ? line1OrSelected : null,
                AddressLine1 = line1OrSelected,
                AddressLine2 = line2,
                Town = "Town",
                Postcode = "SK1 1AA"
            };

            Assert.Equal(expected, address.ToStringWithoutPlaceRef());
        }
    }
}