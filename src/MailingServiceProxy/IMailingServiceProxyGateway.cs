using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Mail;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.MailingServiceProxy;

public interface IMailingServiceProxyGateway
{
    Task<HttpResponse<string>> Send(Mail model);
}
