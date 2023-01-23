﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public interface IBookingServiceAdminGateway
    {
        Task<HttpResponseMessage> GetVersionNumber();

        Task<HttpResponseMessage> GetContext(Guid contextId);

        Task<HttpResponseMessage> GetContexts();

        Task<HttpResponseMessage> GetByUsername(string username);

        Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request);

        Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId);

        Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(GetByDateRequest request);
    }
}
