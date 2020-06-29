using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.MailingService
{
    public interface IMailingServiceGateway
    {
        Task<HttpResponse<string>> Send(Mail model);
    }
}