using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.MailingService;

public class CloudMailingServiceGateway : Gateway, ICloudMailingServiceGateway
{
    private const string CloudMailingServiceEndpoint = "api/v1/Home";

    public CloudMailingServiceGateway(HttpClient httpClient) : base(httpClient) { }

    public async Task<HttpResponseMessage> SendSesEmail(Mail request) =>
            await PostAsync($"{CloudMailingServiceEndpoint}/ses-email", request);
}
