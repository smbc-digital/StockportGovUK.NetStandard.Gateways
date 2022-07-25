using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.FileManagement
{
    public class FilePack
    {
        public string Name { get; set; }

        public IDictionary<string, dynamic> Files { get; set; }
    }
}
