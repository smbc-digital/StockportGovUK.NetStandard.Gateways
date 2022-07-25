using System;

namespace StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Response
{

    public class SimpleMandateSetupResponse
    {
        public SimpleMandateSetupResponse()
        {

        }

        public SimpleMandateSetupResponse(GovUkMandateSetupResponse response)
        {
            MandateId = response.mandate_id;
            Reference = response.reference;
            IsSucessful = response.state.status == "created";
            CreationDate = response.created_date;
            Description = response.description;
            MandateSetupUrl = response._links.next_url.href;
        }

        public string MandateId { get; set; }

        public string Reference { get; set; }

        public bool IsSucessful { get; set; }

        public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        public string MandateSetupUrl { get; set; }
    }
}