namespace StockportGovUK.NetStandard.Gateways.Models.FormBuilder
{
    public class PostPaymentUpdateRequest
    {
        public string Reference { get; set; }

        public EPaymentStatus PaymentStatus { get; set; }

        public string PaymentStatusDescription
        {
            get{
                switch(PaymentStatus)
                {
                    case EPaymentStatus.Failure:
                        return "Payment failed";
                    case EPaymentStatus.Declined:
                        return "Payment declined";
                    case EPaymentStatus.Cancelled:
                        return "Payment cancelled";    
                    default:
                        return "Paid";
                }
            }
        }
    }
}