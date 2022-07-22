using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.FormBuilder
{
    public enum EPaymentStatus
    {
        [Display(Name = "Paid")]
        Success = 0,

        [Display(Name = "Payment Failed")]
        Failure = 1,

        [Display(Name = "Payment Cancelled")]
        Cancelled = 2,

        [Display(Name = "Payment Declined")]
        Declined = 3
    }
}

