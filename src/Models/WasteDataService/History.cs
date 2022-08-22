using System;

namespace StockportGovUK.NetStandard.Gateways.Models.WasteDataService
{
    public class History
    {
        public string RoundType { get; set; }
        public DateTime When { get; set; }
        public string What { get; set; }
        public string FriendyWhat {
            get
            {
                if (What.ToLower().Equals("assisted confirm collection"))
                    return "your bin was recorded as collected. Call the contact centre on 0161 217 6111";

                return What;
            }
        } 
        public bool CrewReport { get; set; }
    }
}