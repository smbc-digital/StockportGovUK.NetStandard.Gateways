using StockportGovUK.NetStandard.Gateways.Models.Verint;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models.Verint
{
    public class CustomerTests
    {
        [Fact]
        public void FullName_ShouldReturnSurname_WhenOnlySurnameIsSet()
        {
            Customer customer = new() { Surname = "Surname" };
            
            Assert.Equal("Surname", customer.FullName);
        }

        [Fact]
        public void FullName_ShouldReturnForenameAndSurname_WhenForenameIsSet()
        {
            Customer customer = new() { Forename = "Forename", Surname = "Surname" };
            
            Assert.Equal("Forename Surname", customer.FullName);
        }

        [Fact]
        public void FullName_ShouldIncludeInitials_WhenInitialsAreSet()
        {
            Customer customer = new() { Initials = "I.", Forename = "Forename", Surname = "Surname" };
            
            Assert.Equal("I. Forename Surname", customer.FullName);
        }

        [Fact]
        public void FullName_ShouldIncludeTitle_WhenTitleIsSet()
        {
            Customer customer = new() { Title = "Mx", Initials = "I.", Forename = "Forename", Surname = "Surname" };
            
            Assert.Equal("Mx I. Forename Surname", customer.FullName);
        }

        [Fact]
        public void FullName_ShouldReturnSurname_WhenOtherFieldsAreEmpty()
        {
            Customer customer = new() { Forename = "", Initials = "", Title = "", Surname = "Surname" };
            
            Assert.Equal("Surname", customer.FullName);
        }
    }
}