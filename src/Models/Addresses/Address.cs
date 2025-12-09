namespace StockportGovUK.NetStandard.Gateways.Models.Addresses
{
    public class Address
    {
        public string SelectedAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string Postcode { get; set; }

        public string PlaceRef { get; set; }

        public bool IsAutomaticallyFound => SelectedAddress != null;

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(PlaceRef))
                return $"{SelectedAddress},({PlaceRef})";
            
            return $"{AddressLine1}, {AddressLine2}, {Town}, {Postcode}";
        }

        public string ToStringWithoutPlaceRef()
        {
            if (IsAutomaticallyFound)
                return SelectedAddress;

            if (string.IsNullOrEmpty(AddressLine2))
                return $"{AddressLine1}, {Town}, {Postcode}";

            return $"{AddressLine1}, {AddressLine2}, {Town}, {Postcode}";
        }
    }
}