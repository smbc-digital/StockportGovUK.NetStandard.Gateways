using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class Customer
    {
        public Customer() { }
        public Customer(string firstName, string lastName) =>
            (Firstname, Lastname) = (firstName, lastName);
        public Customer(string firstName, string lastName, string address) =>
            (Firstname, Lastname, Address) = (firstName, lastName, address);

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}