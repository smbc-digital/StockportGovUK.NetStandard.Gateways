using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Mail;

namespace StockportGovUK.AspNetCore.Gateways.MailingServiceGateway
{
    public interface IMailingServiceGateway
    {
        Task<HttpResponse<string>> Send(Mail model);
    }
}