using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    internal static class QueryStringGenerator
    {
        internal static string GetByDateQueryString(GetByDateRequest request) =>
            $"?{nameof(request.Id)}={request.Id}&{nameof(request.Date)}={request.Date:s}";
    }
}
