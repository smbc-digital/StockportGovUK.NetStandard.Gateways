using System.Text;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string strReference, string strDescription)
        {
            this.Reference = strReference;
            this.Description = strDescription;
        }

        public Address(Addresses.Address address)
        {
            if (string.IsNullOrEmpty(address.PlaceRef))
            {
                AddressLine1 = address.AddressLine1;
                AddressLine2 = address.AddressLine2;
                AddressLine3 = address.Town;
                Postcode = address.Postcode;
            }
            else
            {
                UPRN = address.PlaceRef;
                Reference = address.PlaceRef;
                Description = address.SelectedAddress;
                Postcode = address.Postcode;
            }
        }

        public string Reference { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }

        public string UPRN { get; set; }

        public string USRN { get; set; }

        public string PropertyId { get; set; }

        public string BusinessName { get; set; }

        public bool? FromCookie { get; set; }

        public string Easting { get; set; }

        public string Northing { get; set; }

        public bool IsFullyResolved
        {
            get
            {
                return !string.IsNullOrEmpty(Number) &&
                       !string.IsNullOrEmpty(AddressLine1) &&
                       !string.IsNullOrEmpty(City) &&
                       !string.IsNullOrEmpty(Postcode);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            AppendString(Number, sb);
            AppendString(BusinessName, sb);
            AppendString(AddressLine1, sb);
            AppendString(AddressLine2, sb);
            AppendString(AddressLine3, sb);
            AppendString(City, sb);
            AppendString(Postcode, sb);
            string s = sb.ToString();
            s = s.Trim();
            s = s.TrimEnd(new char[] { ',' });
            return s;
        }

        private StringBuilder AppendString(string s, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(s))
                sb.Append(s + ", ");

            return sb;
        }
    }
}
