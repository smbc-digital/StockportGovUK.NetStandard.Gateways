using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.RevsBensService
{
    public interface IRevsBensServiceGateway
    {
        Task<HttpResponseMessage> IsBenefitsClaimant(string personReference);

        Task<HttpResponseMessage> GetCurrentCouncilTaxAccountReference(string personReference);

        Task<HttpResponseMessage> GetCouncilTaxDetails(string personReference, string accountReference, int year);

        Task<HttpResponseMessage> GetReducedCouncilTaxDetails(string personReference, string accountReference, int year);

        Task<HttpResponseMessage> GetBenefits(string personReference);

        Task<HttpResponseMessage> GetPerson(string personReference);

        Task<HttpResponseMessage> GetCivicaAvailability();

        Task<HttpResponseMessage> GetCivicaBrokersAvailability();

        Task<HttpResponseMessage> GetDocumentForAccount(string personReference, string accountReference, string documentId);

        Task<HttpResponseMessage> GetBaseCouncilTaxAccount(string personReference);

        Task<HttpResponseMessage> GetDocumentsForPerson(string personReference);
    }
}
