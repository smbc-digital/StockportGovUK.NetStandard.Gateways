using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Verint;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Update;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using Address = StockportGovUK.NetStandard.Gateways.Models.Verint.Address;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public interface IVerintServiceGateway
    {
        #region Case

        Task<Case> GetCase(string caseRef);
        Task<string> CreateCase(Case crmCase);
        Task LinkCase(LinkCaseRequest linkCaseRequest, bool logOnly = false);
        Task UnLinkCase(LinkCaseRequest unLinkCaseRequest, bool logOnly = false);
        Task<string> CloseCase(CloseCaseRequest closeCaseRequest, bool logOnly = false);
        Task ReopenCase(ReopenCaseRequest reopenCaseRequest, bool logOnly = false);
        Task CleanupCase(CloseCaseRequest closeCaseRequest, bool logOnly = false);
        Task<int> UpdateCaseDescription(Case crmCase, bool logOnly = false);
        Task<int> UpdateCaseQueue(Case crmCase, bool logOnly = false);
        Task<int> UpdateCaseTitle(Case crmCase, bool logOnly = false);
        Task UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content, bool logOnly = false);
        Task<bool> AddCaseFormField(AddCaseFormFieldRequest request, bool logOnly = false);
        Task AddNoteWithAttachments(NoteWithAttachments model, bool logOnly = false);
        Task AddNote(NoteRequest model, bool logOnly = false);

        #endregion

        #region Verint Online Form

        Task<VerintOnlineForm> GetVerintOnlineFormCase(string verintOnlineFormReference);
        Task<VerintOnlineFormResponse> CreateVerintOnlineFormCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task<VerintOnlineFormResponse> AttachVerintOnlineFormToCase(VerintOnlineFormRequest verintOnlineFormRequest);
        Task UpdateVerintOnlineFormFormData(VerintOnlineFormUpdateRequest request, bool logOnly = false);

        #endregion

        #region Property

        Task<List<AddressSearchResult>> SearchForPropertyByPostcode(string postcode);
        Task<Address> GetPropertyByPlaceRef(string placeRef);
        Task<Address> GetPropertyFromUprn(string uprn);

        #endregion

        #region Street

        Task<List<AddressSearchResult>> GetStreetByReference(string street);
        Task<List<AddressSearchResult>> GetStreetByUsrn(string usrn);
        Task<List<AddressSearchResult>> SearchForPropertyByUsrn(string usrn);
        Task<AddressSearchResult> GetStreet(string reference);

        #endregion

        #region Organisation

        Task<List<OrganisationSearchResult>> SearchForOrganisationByName(string organisation);

        #endregion
    }
}
