using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Context
{
    public interface IBookingServiceAdminContextGateway
    {
        Task<HttpResponseMessage> GetContext(Guid contextId);

        Task<HttpResponseMessage> GetContexts();
    }
}
