namespace StockportGovUK.NetStandard.Gateways.Models.FormBuilder
{
    public class PostPaymentUpdateRequest
    {
        public string Reference { get; set; }

        public EPaymentStatus PaymentStatus { get; set; }

        public string PaymentStatusDescription
        {
            get{
                return PaymentStatus switch
                {
                    EPaymentStatus.Failure => "Payment failed",
                    EPaymentStatus.Declined => "Payment declined",
                    EPaymentStatus.Cancelled => "Payment cancelled",
                    _ => "Paid",
                };
            }
        }
    }
}