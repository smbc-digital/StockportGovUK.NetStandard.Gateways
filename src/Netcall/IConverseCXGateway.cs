using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public interface IConverseCXGateway : IGateway
    {
        Task<HttpResponseMessage> PauseRecordingAsync(string agentId);   

        Task<HttpResponseMessage> ResumeRecordingAsync(string agentId);
    }
}