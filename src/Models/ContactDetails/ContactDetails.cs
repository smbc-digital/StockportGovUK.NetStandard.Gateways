using StockportGovUK.NetStandard.Gateways.Models.Addresses;

namespace StockportGovUK.NetStandard.Gateways.Models.ContactDetails
{
    public class ContactDetails
    {
        public Address Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}