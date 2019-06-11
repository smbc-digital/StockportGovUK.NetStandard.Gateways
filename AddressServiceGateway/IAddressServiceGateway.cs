using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.AddressService
{
    public interface IAddressServiceGateway : IGateway
    {
        Task<HttpResponse<T>> GetAddressesAsync<T>(string postcode);
        Task<HttpResponse<T>> GetPropertyDetailsAsync<T>(string uprn);
    }
}