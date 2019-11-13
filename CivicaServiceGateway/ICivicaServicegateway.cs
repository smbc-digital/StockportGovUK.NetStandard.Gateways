using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.CivicaServiceGateway
{
    public interface ICivicaServiceGateway
    {
        Task<HttpResponseMessage> IsBenefitsClaimant(string personReference);
        Task<HttpResponseMessage> GetBenefitDetails(string personReference);
        Task<HttpResponseMessage> GetAccounts(string personReference);
        Task<HttpResponseMessage> GetAccount(string personReference, string accountReference);
        Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year);
        Task<HttpResponseMessage> GetDocumentsWithAccountReference(string personReference, string accountReference);
        Task<HttpResponseMessage> GetDocuments(string personReference);
        Task<HttpResponseMessage> GetPropertiesOwned(string personReference);
        Task<HttpResponseMessage> GetCurrentProperty(string personReference);
        Task<HttpResponseMessage> GetPaymentSchedule(string personReference, string year);
    }
}