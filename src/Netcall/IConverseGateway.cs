using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public interface IConverseGateway : IGateway
    {
        Task<HttpResponseMessage> PauseRecordingAsync(string pid, string netcallUserId);

        Task<HttpResponseMessage> ResumeRecordingAsync(string pid, string netcallUserId);

        Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string pid, string extension);

        Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string pid, string extension);
    }
}