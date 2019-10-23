using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StockportGovUK.AspNetCore.Gateways.RevsBensServiceGateway
{
    public class RevsBensServiceGateway : Gateway, IRevsBensServiceGateway
    {
        public RevsBensServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
