using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.WasteDataService
{
    public class BaseBinType
    {
        public string Code { get; set; }
        public int? FrequencyDays { get; set; }
        public DateTime Previous { get; set; }
        public DateTime Next { get; set; }
        public string CollectionPoint { get; set; }
        public List<Bin> Bins { get; set; }
        public string CrewNote { get; set; }
    }
}