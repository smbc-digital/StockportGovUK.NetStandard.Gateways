﻿using StockportGovUK.NetStandard.Gateways.Models.Conesso;
using StockportGovUK.NetStandard.Gateways.Response;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Conesso
{
    public interface IConessoGateway
    {
        Task<HttpResponse<ContactResponse>> CreateContact(ContactRequest request);
        Task<HttpResponse<ContactResponse>> UpdateContact(ContactRequest request);
        Task<HttpResponse<ListResponse>> GetListById(int listId);
        Task<HttpResponse<ContactResponse>> GetContactByEmail(string emailAddress);

    }
}
