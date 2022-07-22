using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.WasteDataService.Response
{
    public class PropertyWasteData
    {
        public long Uprn { get; set; }
        public string AddressLabel { get; set; }
        public BinRounds Rounds { get; set; } = new BinRounds();
        public bool UnsuitableForWheeledBins { get; set; }
        public string CollectionPoint { get; set; }
        public AssistedCollection AssistedCollection { get; set; }
        public int Contains { get; set; }
        public ContainedBy ContainedBy { get; set; }
        public List<History> History { get; set; }

        public bool IsAssisted
        {
            get
            {
                return
                    (AssistedCollection.Start != DateTime.MinValue
                    && AssistedCollection.Start <= DateTime.Now)
                    &&
                    (AssistedCollection.Stop == DateTime.MinValue
                    || AssistedCollection.Stop >= DateTime.Now);
            }
        }

        public string PropertyCentralAssetId { get; set; }
    }
}
