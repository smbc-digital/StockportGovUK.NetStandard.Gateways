using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public interface IConverseCXGateway : IGateway
    {
        Task<HttpResponseMessage> PauseRecordingByIdAsync(string agentId);   

        Task<HttpResponseMessage> ResumeRecordingByIdAsync(string agentId);

        Task<HttpResponseMessage> PauseRecordingByEmailAsync(string email);   

        Task<HttpResponseMessage> ResumeRecordingByEmailAsync(string email);
    }
}