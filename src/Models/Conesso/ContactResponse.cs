using System;
using System.Collections.Generic;
using System.Text;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ContactResponse
    {
        public int Id {  get; set; }
        public string Uid { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PreferredName { get; set; }
        public string Gender {  get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Address {  get; set; }
        public string Address2 {  get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode {  get; set; }
        public string Country {  get; set; }
        public string CountryCode {  get; set; }
        public string[] Tags {  get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }

    }
}
