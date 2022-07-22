using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Mail;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.MailingService
{
    public interface IMailingServiceGateway
    {
        Task<HttpResponse<string>> Send(Mail model);
    }
}