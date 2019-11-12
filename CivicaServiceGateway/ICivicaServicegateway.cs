using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.CivicaServiceGateway
{
    public interface ICivicaServiceGateway
    {
        Task<HttpResponseMessage> IsBenefitsClaimant(string personReference);

        Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year);

        Task<HttpResponseMessage> GetBenefitDetails(string personReference);
    }
}