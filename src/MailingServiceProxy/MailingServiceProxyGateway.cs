using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Mail;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.MailingServiceProxy;

public class MailingServiceProxyGateway : Gateway, IMailingServiceProxyGateway
{
    private const string MailingEndpoint = "api/v1/Home";
    public MailingServiceProxyGateway(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<HttpResponse<string>> Send(Mail model)
        => await PostAsync<string>(MailingEndpoint, model);
}
