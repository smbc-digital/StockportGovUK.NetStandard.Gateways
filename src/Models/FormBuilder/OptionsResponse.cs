using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.FormBuilder
{
    public class OptionsResponse
    {
        public List<Option> Options { get; set; }

        public int SelectExactly { get; set; }
    }
}
