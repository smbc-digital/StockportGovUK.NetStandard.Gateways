using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Models.Verint;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Update;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.VerintService;

public partial class VerintServiceGateway : Gateway, IVerintServiceGateway
{
    private const string CaseEndpoint = "api/v1/Case";

    public async Task<Case> GetCase(string caseRef)
    {
        HttpResponse<Case> verintCaseResponse;
        try
        {
            verintCaseResponse = await GetAsync<Case>($"{CaseEndpoint}?caseId={caseRef}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetCase)}: " +
                $"An unexpected error occurred while searching for CaseReference {caseRef} - {exception.Message}");
        }

        if (!verintCaseResponse.IsSuccessStatusCode)
            throw new HttpResponseException(verintCaseResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(GetCase)}: " +
                $"Request to get Case for CaseReference {caseRef} failed - {verintCaseResponse.ReasonPhrase}");

        return verintCaseResponse.ResponseContent;
    } 

    public async Task<string> CreateCase(Case crmCase)
    {
        HttpResponse<string> verintCaseResponse;
        try
        {
            verintCaseResponse = await PostAsync<string>($"{CaseEndpoint}", crmCase);
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)} :: {nameof(CreateCase)}: " +
                $"An unexpected error occurred while creating Case - {exception.Message}");
        }

        if (!verintCaseResponse.IsSuccessStatusCode)
            throw new HttpResponseException(verintCaseResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(VerintServiceGateway.CreateCase)}: " +
                $"failed to create Case with status code {verintCaseResponse.StatusCode}");

        return verintCaseResponse.ResponseContent;
    }

    public async Task LinkCase(LinkCaseRequest linkCaseRequest, bool logOnly = false)
    {
        HttpResponseMessage linkVerintCaseResponse;
        try
        {
            linkVerintCaseResponse = await PatchAsync($"{CaseEndpoint}/link", linkCaseRequest);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(LinkCase)}: " +
                         $"An unexpected error occurred while linking Cases {linkCaseRequest.CaseReference} and {linkCaseRequest.TargetCaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!linkVerintCaseResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(LinkCase)}: " +
                         $"failed to link Cases {linkCaseRequest.CaseReference} and {linkCaseRequest.TargetCaseReference} with status code {linkVerintCaseResponse.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(linkVerintCaseResponse.StatusCode, log);
        }
    }

    public async Task UnLinkCase(LinkCaseRequest unLinkCaseRequest, bool logOnly = false)
    {
        HttpResponseMessage unLinkVerintCaseResponse;
        try
        {
            unLinkVerintCaseResponse = await PatchAsync($"{CaseEndpoint}/unlink", unLinkCaseRequest);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UnLinkCase)}: " +
                         $"An unexpected error occurred while unlinking Cases {unLinkCaseRequest.CaseReference} and {unLinkCaseRequest.TargetCaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!unLinkVerintCaseResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UnLinkCase)}: " +
                         $"failed to unlink Cases {unLinkCaseRequest.CaseReference} and {unLinkCaseRequest.TargetCaseReference} with status code {unLinkVerintCaseResponse.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(unLinkVerintCaseResponse.StatusCode, log);
        }
    }

    public async Task<string> CloseCase(CloseCaseRequest closeCaseRequest, bool logOnly = false)
    {
        {
            HttpResponse<string> verintCaseResponse = new();
            try
            {
                verintCaseResponse = await PatchAsync<string>($"{CaseEndpoint}/close-case", closeCaseRequest);
            }
            catch (Exception exception)
            {
                string log = $"{nameof(VerintServiceGateway)}::{nameof(CloseCase)}: " +
                             $"An unexpected error occurred while closing Case {closeCaseRequest.CaseReference} - {exception.Message}";

                if (logOnly)
                    _logger.LogError(log);
                else
                    throw new HttpResponseException(424, log);
            }

            if (!verintCaseResponse.IsSuccessStatusCode)
            {
                string log = $"{nameof(VerintServiceGateway)}::{nameof(CloseCase)}: " +
                             $"failed to close Case {closeCaseRequest.CaseReference} with status code {verintCaseResponse.StatusCode}";

                if (logOnly)
                    _logger.LogError(log);
                else
                    throw new HttpResponseException(verintCaseResponse.StatusCode, log);
            }

            return verintCaseResponse.ResponseContent;
        }
    }

    public async Task ReopenCase(ReopenCaseRequest reopenCaseRequest, bool logOnly = false)
    {
        HttpResponseMessage verintCaseResponse;

        try
        {
            verintCaseResponse = await PatchAsync($"{CaseEndpoint}/reopen-case", reopenCaseRequest);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(ReopenCase)}: " +
                         $"An unexpected error occurred trying to reopen Case {reopenCaseRequest.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!verintCaseResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(ReopenCase)}: " +
                         $"failed to reopen Case {reopenCaseRequest.CaseReference} - {verintCaseResponse.ReasonPhrase}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(verintCaseResponse.StatusCode, log);
        }
    }

    public async Task CleanupCase(CloseCaseRequest closeCaseRequest, bool logOnly = false)
    {
        HttpResponseMessage result;

        try
        {
            result = await PatchAsync($"{CaseEndpoint}/close-and-clean-case", closeCaseRequest);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(CleanupCase)}: " +
                         $"An unexpected error occurred trying to cleanup Case {closeCaseRequest.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!result.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(CleanupCase)}: " +
                         $"failed to cleanup Case {closeCaseRequest.CaseReference} - {result.ReasonPhrase}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(result.StatusCode, log);
        }
    }

    public async Task<int> UpdateCaseDescription(Case crmCase, bool logOnly = false)
    {
        HttpResponse<int> verintCaseResponse = new();
        try
        {
            verintCaseResponse = await PostAsync<int>($"{CaseEndpoint}/updatecasedescription", crmCase);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseDescription)}: " +
                         $"An unexpected error occurred while updating Case {crmCase.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);
        }

        if (!verintCaseResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseDescription)}: " +
                         $"failed to update Case {crmCase.CaseReference} with status code {verintCaseResponse.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(verintCaseResponse.StatusCode, log);
        }

        return verintCaseResponse.ResponseContent;
    }

    public async Task<int> UpdateCaseQueue(Case crmCase, bool logOnly = false)
    {
        HttpResponse<int> verintCaseResponse = new();
        try
        {
            verintCaseResponse = await PatchAsync<int>($"{CaseEndpoint}/update-case-queue", crmCase);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseQueue)}: " +
                         $"An unexpected error occurred while updating Case queue {crmCase.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);
        }

        if (!verintCaseResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseQueue)}: " +
                         $"failed to update Case queue {crmCase.CaseReference} with status code {verintCaseResponse.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(verintCaseResponse.StatusCode, log);
        }

        return verintCaseResponse.ResponseContent;
    }

    public async Task<int> UpdateCaseTitle(Case crmCase, bool logOnly = false)
    {
        HttpResponse<int> verintCaseResponse = new();
        try
        {
            verintCaseResponse = await PatchAsync<int>($"{CaseEndpoint}/update-case-title", crmCase);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseTitle)}: " +
                         $"An unexpected error occurred while updating Case title {crmCase.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);
        }

        if (!verintCaseResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseTitle)}: " +
                         $"failed to update Case title {crmCase.CaseReference} with status code {verintCaseResponse.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(verintCaseResponse.StatusCode, log);
        }

        return verintCaseResponse.ResponseContent;
    }

    public async Task UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content, bool logOnly = false)
    {
        HttpResponseMessage response;

        try
        {
            response = await PatchAsync($"{CaseEndpoint}/integration-form-fields", content);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseIntegrationFormField)}: " +
                         $"An unexpected error occurred while updating Case Integration Form Field {content.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!response.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateCaseIntegrationFormField)}: " +
                         $"failed to update Case Integration Form Field {content.CaseReference} with status code {response.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(response.StatusCode, log);
        }
    }

    public async Task<bool> AddCaseFormField(AddCaseFormFieldRequest request, bool logOnly = false)
    {
        HttpResponse<bool> response = new();

        try
        {
            response = await PatchAsync<bool>($"{CaseEndpoint}/add-caseform-field", request);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(AddCaseFormField)}: " +
                         $"An unexpected error occurred while adding Case Form Field {request.CaseReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);
        }

        if (!response.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(AddCaseFormField)}: " +
                         $"failed to add Case Form Field {request.CaseReference} with status code {response.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(response.StatusCode, log);
        }

        return response.ResponseContent;
    }

    public async Task AddNoteWithAttachments(NoteWithAttachments model, bool logOnly = false)
    {
        HttpResponseMessage response;
        try
        {
            response = await PostAsync($"{CaseEndpoint}/add-note-with-attachments", model);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(AddNoteWithAttachments)}: " +
                         $"An unexpected error occurred while creating Note with attachments - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!response.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(AddNoteWithAttachments)}: " +
                         $"failed to create Note with attachments with status code {response.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(response.StatusCode, log);
        }
    }

    public async Task AddNote(NoteRequest model, bool logOnly = false)
    {
        HttpResponseMessage response;
        try
        {
            response = await PostAsync($"{CaseEndpoint}/add-note", model);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(AddNote)}: " +
                         $"An unexpected error occurred while creating Note - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!response.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(AddNote)}: " +
                         $"failed to create Note with status code {response.StatusCode}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(response.StatusCode, log);
        }
    }
}
