using System;

namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
{
    
    public class SimpleMandateStatusResponse
    {
        public SimpleMandateStatusResponse()
        {
                
        }

        public SimpleMandateStatusResponse(GovUkMandateStatusResponse response)
        {
            MandateId = response.mandate_id;
            Reference = response.reference;
            State = response.state.status;
            CreationDate = response.created_date;
            Description = response.description;
            PayeeName = response.payer.name;
            PayeeEmail = response.payer.email;
            BankStatementReference = response.bank_statement_reference;
        }

        public string MandateId { get; set; }

        public string Reference { get; set; }

        public string State { get; set; }

        public bool IsSucessful { get; set; }

        public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        public string PayeeName { get; set; }

        public string PayeeEmail { get; set; }

        public string BankStatementReference { get; set; }
    }
}