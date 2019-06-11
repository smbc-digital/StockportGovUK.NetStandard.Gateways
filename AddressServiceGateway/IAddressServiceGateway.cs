using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.AddressService
{
    public interface IAddressServiceGateway : IGateway
    {
        Task<HttpResponseMessage> GetAddressesAsync(string postcode);
        Task<HttpResponseMessage> GetPropertyDetailsAsync(string uprn);
    }
}