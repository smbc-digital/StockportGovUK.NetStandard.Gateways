namespace StockportGovUK.NetStandard.Gateways.Models.Addresses
{
    public class AddressSearchResult
    {
        private string _name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return $"{AddressLine1}, {AddressLine2}, {AddressLine3}, {Postcode}";
                }

                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string UniqueId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        public string USRN { get; set; }
    }
}