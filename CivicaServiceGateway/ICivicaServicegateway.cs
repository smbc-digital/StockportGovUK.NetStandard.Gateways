using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.CivicaServiceGateway
{
    public interface ICivicaServiceGateway
    {
        Task<HttpResponseMessage> GetSessionId(string personReference);
        Task<HttpResponseMessage> IsBenefitsClaimant(string personReference);
        Task<HttpResponseMessage> GetBenefits(string personReference);
        Task<HttpResponseMessage> GetBenefitDetails(string personReference, string claimReference, string placeReference);
        Task<HttpResponseMessage> GetHousingBenefitPaymentHistory(string personReference);
        Task<HttpResponseMessage> GetCouncilTaxBenefitPaymentHistory(string personReference);
        Task<HttpResponseMessage> GetAccounts(string personReference);
        Task<HttpResponseMessage> GetAccount(string personReference, string accountReference);
        Task<HttpResponseMessage> GetAccountDetailsForYear(string personReference, string accountReference, int year);
        Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year);
        Task<HttpResponseMessage> GetDocumentsWithAccountReference(string personReference, string accountReference);
        Task<HttpResponseMessage> GetDocuments(string personReference);
        Task<HttpResponseMessage> GetPropertiesOwned(string personReference);
        Task<HttpResponseMessage> GetCurrentProperty(string personReference, string accountReference);
        Task<HttpResponseMessage> GetPaymentSchedule(string personReference, int year);
        Task<HttpResponseMessage> GetAvailability();
    }
}