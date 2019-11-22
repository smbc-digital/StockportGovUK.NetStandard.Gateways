using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.RevsBensServiceGateway
{
    public interface IRevsBensServiceGateway
    {
        Task<HttpResponseMessage> IsBenefitsClaimant(string personReference);

        Task<HttpResponseMessage> GetCouncilTaxDetails(string personReference, string accountReference, int year);

        Task<HttpResponseMessage> GetBenefits(string personReference);
    }
}
