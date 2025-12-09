using StockportGovUK.NetStandard.Gateways.Models.FormBuilder;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models.FormBuilder
{
    public class PostPaymentUpdateRequestTests
    {
        [Theory]
        [InlineData(EPaymentStatus.Failure,   "Payment failed")]
        [InlineData(EPaymentStatus.Declined,  "Payment declined")]
        [InlineData(EPaymentStatus.Cancelled, "Payment cancelled")]
        [InlineData(EPaymentStatus.Success,   "Paid")]
        public void PaymentStatusDescription_ShouldReturnExpectedText(EPaymentStatus status, string expected)
        {
            PostPaymentUpdateRequest request = new()
            {
                Reference = "123456",
                PaymentStatus = status
            };

            Assert.Equal(expected, request.PaymentStatusDescription);
        }
    }
}
