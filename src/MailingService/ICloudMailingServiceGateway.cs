using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.MailingService;

public interface ICloudMailingServiceGateway
{
    Task<HttpResponseMessage> SendSesEmail(Mail request);
}
