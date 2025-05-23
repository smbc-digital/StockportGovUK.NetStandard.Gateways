﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Verint;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Update;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using StockportGovUK.NetStandard.Gateways.Response;
using Address = StockportGovUK.NetStandard.Gateways.Models.Verint.Address;

namespace StockportGovUK.NetStandard.Gateways.VerintService
{
    public class VerintServiceGateway : Gateway, IVerintServiceGateway
    {
        private const string CaseEndpoint = "api/v1/Case";
        private const string VerintOnlineFormEndpoint = "api/v1/VerintOnlineForm";
        private const string PropertyEndpoint = "api/v1/Property";
        private const string OrganisationEndpoint = "api/v1/Organisation";
        private const string StreetEndpoint = "api/v1/Street";

        public VerintServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<Case>> GetCase(string caseRef)
            => await GetAsync<Case>($"{CaseEndpoint}?caseId={caseRef}");

        public async Task<HttpResponse<string>> CreateCase(Case crmCase)
            => await PostAsync<string>($"{CaseEndpoint}", crmCase);

        public async Task<HttpResponseMessage> LinkCase(LinkCaseRequest linkCaseRequest)
            => await PatchAsync($"{CaseEndpoint}/link", linkCaseRequest);

        public async Task<HttpResponseMessage> UnLinkCase(LinkCaseRequest unLinkCaseRequest)
            => await PatchAsync($"{CaseEndpoint}/unlink", unLinkCaseRequest);

        public async Task<HttpResponse<string>> CloseCase(CloseCaseRequest closeCaseRequest)
            => await PatchAsync<string>($"{CaseEndpoint}/close-case", closeCaseRequest);

        public async Task<HttpResponseMessage> ReopenCase(ReopenCaseRequest reopenCaseRequest)
            => await PatchAsync($"{CaseEndpoint}/reopen-case", reopenCaseRequest);

        public async Task<HttpResponseMessage> CleanupCase(CloseCaseRequest closeCaseRequest)
            => await PatchAsync($"{CaseEndpoint}/close-and-clean-case", closeCaseRequest);

        public async Task<HttpResponse<VerintOnlineForm>> GetVerintOnlineFormCase(string verintOnlineFormReference)
            => await GetAsync<VerintOnlineForm>($"{VerintOnlineFormEndpoint}/{verintOnlineFormReference}");

        public async Task<HttpResponse<VerintOnlineFormResponse>> CreateVerintOnlineFormCase(VerintOnlineFormRequest verintOnlineFormRequest)
            => await PostAsync<VerintOnlineFormResponse>($"{VerintOnlineFormEndpoint}", verintOnlineFormRequest);

        public async Task<HttpResponse<VerintOnlineFormResponse>> AttachVerintOnlineFormToCase(VerintOnlineFormRequest verintOnlineFormRequest)
            => await PostAsync<VerintOnlineFormResponse>($"{VerintOnlineFormEndpoint}/Attach", verintOnlineFormRequest);

        public async Task<HttpResponseMessage> UpdateVerintOnlineFormFormData(VerintOnlineFormUpdateRequest request)
            => await PatchAsync($"{VerintOnlineFormEndpoint}/update-form-data", request);

        public async Task<HttpResponse<int>> UpdateCaseDescription(Case crmCase)
            => await PostAsync<int>($"{CaseEndpoint}/updatecasedescription", crmCase);

        public async Task<HttpResponse<int>> UpdateCaseQueue(Case crmCase)
            => await PatchAsync<int>($"{CaseEndpoint}/update-case-queue", crmCase);

        public async Task<HttpResponse<int>> UpdateCaseTitle(Case crmCase)
            => await PatchAsync<int>($"{CaseEndpoint}/update-case-title", crmCase);

        public async Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content)
            => await PatchAsync($"{CaseEndpoint}/integration-form-fields", content);

        public async Task<HttpResponse<bool>> AddCaseFormField(AddCaseFormFieldRequest request)
            => await PatchAsync<bool>($"{CaseEndpoint}/add-caseform-field", request);

        public async Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByPostcode(string postcode)
            => await GetAsync<List<AddressSearchResult>>($"{PropertyEndpoint}/search/{postcode}");

        public async Task<HttpResponse<Address>> GetPropertyByPlaceRef(string placeRef)
            => await GetAsync<Address>($"{PropertyEndpoint}/{placeRef}");

        public async Task<HttpResponse<Address>> GetPropertyFromUprn(string uprn)
            => await GetAsync<Address>($"{PropertyEndpoint}/uprn/{uprn}");

        public async Task<HttpResponse<List<OrganisationSearchResult>>> SearchForOrganisationByName(string organisation)
            => await GetAsync<List<OrganisationSearchResult>>($"{OrganisationEndpoint}/search/{organisation}");

        public async Task<HttpResponse<List<AddressSearchResult>>> GetStreetByReference(string street)
            => await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/streetsearch/{street}");

        public async Task<HttpResponse<List<AddressSearchResult>>> GetStreetByUsrn(string usrn)
            => await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/usrnsearch/{usrn}");

        public async Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByUsrn(string usrn)
            => await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/search-usrn/{usrn}");

        public async Task<HttpResponse<AddressSearchResult>> GetStreet(string reference)
            => await GetAsync<AddressSearchResult>($"{StreetEndpoint}/{reference}");

        public async Task<HttpResponseMessage> AddNoteWithAttachments(NoteWithAttachments model)
            => await PostAsync($"{CaseEndpoint}/add-note-with-attachments", model);

        public async Task<HttpResponseMessage> AddNote(NoteRequest model)
            => await PostAsync($"{CaseEndpoint}/add-note", model);
    }
}
