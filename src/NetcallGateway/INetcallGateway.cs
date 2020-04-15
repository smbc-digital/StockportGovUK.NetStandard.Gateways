using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public interface INetcallGateway : IGateway
    {
        Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId);

        Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId);

        Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string extension);

        Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string extension);
    }
}