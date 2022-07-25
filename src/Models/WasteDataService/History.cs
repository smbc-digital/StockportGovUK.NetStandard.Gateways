using System;

namespace StockportGovUK.NetStandard.Gateways.Models.WasteDataService
{
    public class History
    {
        public string RoundType { get; set; }
        public DateTime When { get; set; }
        public string What { get; set; }
        public bool CrewReport { get; set; }
    }
}