using System;
using System.Collections.Generic;
using System.Linq;

namespace StockportGovUK.NetStandard.Gateways.Models.BinCollection.Response
{
    public class BinCollectionResponse
    {
        public string Address { get; set; }

        public BinCollectionResponse()
        {
            Collections = Enumerable.Empty<BinContainerModel>();
            FutureCollectionContainers = Enumerable.Empty<BinContainerModel>();
            NextCollectionContainers = Enumerable.Empty<BinContainerModel>();
        }

        public DateTime? NextCollectionDate { get; set; }

        public IEnumerable<BinContainerModel> Collections { get; set; }

        public IEnumerable<BinContainerModel> FutureCollectionContainers { get; set; }

        public IEnumerable<BinContainerModel> NextCollectionContainers { get; set; }

        public string BinCollectionCalendarUrl { get; set; }

    }


    public class BinContainerModel
    {
        public DateTime? CollectionDate { get; set; }

        public string Container { get; set; }
    }

}
