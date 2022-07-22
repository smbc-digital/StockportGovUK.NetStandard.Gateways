﻿using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Mail;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.MailingService
{
    public class MailingServiceGateway : Gateway, IMailingServiceGateway
    {
        private const string MailingEndpoint = "api/mail";
        public MailingServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<string>> Send(Mail model)
            => await PostAsync<string>(MailingEndpoint, model);
    }
}
