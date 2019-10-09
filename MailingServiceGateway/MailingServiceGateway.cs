using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.MailingServiceGateway
{
    public class MailingServiceGateway : Gateway, IMailingServiceGateway
    {
        private const string MailingEndpoint = "api/mail";
        public MailingServiceGateway(HttpClient client) : base(client)
        {
        }

        //public async Task<HttpResponse<string>> Send(Mail model)
        //{
        //    return await PostAsync<string>(MailingEndpoint, model);
        //}
    }
}
