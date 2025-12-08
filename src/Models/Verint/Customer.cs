using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint
{
    public class Customer
    {
        public string Title { get; set; }

        public string Forename { get; set; }

        public string Initials { get; set; }

        public string Surname { get; set; }

        public string Telephone { get; set; }

        public string AlternativeTelephone { get; set; }

        public string Mobile { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public Address AlternativeCorrespondenceAddress { get; set; }

        public string CustomerReference { get; set; }

        public string FullName
        {
            get
            {
                string fullName = Surname;

                if (!string.IsNullOrWhiteSpace(Forename))
                {
                    fullName = $"{Forename} {fullName}".TrimEnd();
                }

                if (!string.IsNullOrWhiteSpace(Initials))
                {
                    fullName = $"{Initials} {fullName}".TrimEnd();
                }

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    fullName = $"{Title} {fullName}".TrimEnd();
                }

                return fullName?.Trim();
            }
        }

        public string NationalInsuranceNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public ICollection<Customer> PreviousNames { get; set; }

        public SocialContact[] SocialContacts { get; set; }
    }
}
