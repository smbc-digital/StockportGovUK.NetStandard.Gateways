﻿using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.WiredPlus;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public interface IWiredPlusGateway
    {
        Task<HttpResponse<object>> GetAccountInfo();
        Task<HttpResponse<NewsletterSignUpResponse>> CreateContact(NewsletterSignUpRequest request);
        Task<HttpResponse<NewsletterSignUpResponse>> UpdateContact(NewsletterSignUpRequest request);
        Task<HttpResponse<GetListByIdResponse>> GetListById(GetListByIdRequest request);
        Task<HttpResponse<object>> ResubscribeContact(NewsletterSignUpRequest request);
        Task<HttpResponse<NewsletterContactResponse>> GetContactByEmail(NewsletterSignUpRequest request);
    }
}
