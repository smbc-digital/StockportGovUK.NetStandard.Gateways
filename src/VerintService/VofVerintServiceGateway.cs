using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.VerintService;

public partial class VerintServiceGateway : Gateway, IVerintServiceGateway
{
    private const string VerintOnlineFormEndpoint = "api/v1/VerintOnlineForm";

    public async Task<VerintOnlineForm> GetVerintOnlineFormCase(string verintOnlineFormReference)
    {
        HttpResponse<VerintOnlineForm> response;
        try
        {
            response = await GetAsync<VerintOnlineForm>($"{VerintOnlineFormEndpoint}/{verintOnlineFormReference}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetVerintOnlineFormCase)}: " +
                $"An unexpected error occurred while retrieving VOF {verintOnlineFormReference} - {exception.Message}");
        }

        if (!response.IsSuccessStatusCode)
            throw new HttpResponseException(response.StatusCode,
                $"{nameof(VerintServiceGateway)} :: {nameof(GetVerintOnlineFormCase)}: " +
                $"failed to retrieve VOF {verintOnlineFormReference} with status code {response.StatusCode}");

        return response.ResponseContent;
    }

    public async Task<VerintOnlineFormResponse> CreateVerintOnlineFormCase(VerintOnlineFormRequest verintOnlineFormRequest)
    {
        HttpResponse<VerintOnlineFormResponse> response;
        try
        {
            response = await PostAsync<VerintOnlineFormResponse>($"{VerintOnlineFormEndpoint}", verintOnlineFormRequest);
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(CreateVerintOnlineFormCase)}: " +
                $"An unexpected error occurred while creating VOF Case - {exception.Message}");
        }

        if (!response.IsSuccessStatusCode)
            throw new HttpResponseException(response.StatusCode,
                $"{nameof(VerintServiceGateway)} :: {nameof(CreateVerintOnlineFormCase)}: " +
                $"failed to create VOF Case with status code {response.StatusCode}");

        return response.ResponseContent;
    }

    public async Task<VerintOnlineFormResponse> AttachVerintOnlineFormToCase(VerintOnlineFormRequest verintOnlineFormRequest)
    {
        HttpResponse<VerintOnlineFormResponse> response;
        try
        {
            response = await PostAsync<VerintOnlineFormResponse>($"{VerintOnlineFormEndpoint}/Attach", verintOnlineFormRequest);
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(AttachVerintOnlineFormToCase)}: " +
                $"An unexpected error occurred while attaching VOF to Case {verintOnlineFormRequest.VerintCase.CaseReference} - {exception.Message}");
        }

        if (!response.IsSuccessStatusCode)
            throw new HttpResponseException(response.StatusCode,
                $"{nameof(VerintServiceGateway)} :: {nameof(AttachVerintOnlineFormToCase)}: " +
                $"failed to attach VOF to Case {verintOnlineFormRequest.VerintCase.CaseReference} with status code {response.StatusCode}");

        return response.ResponseContent;
    }

    public async Task UpdateVerintOnlineFormFormData(VerintOnlineFormUpdateRequest request) =>
        await UpdateVerintOnlineFormFormData(request, false);

    public async Task UpdateVerintOnlineFormFormData(VerintOnlineFormUpdateRequest request, bool logOnly)
    {
        HttpResponseMessage verintResponse;
        try
        {
            verintResponse = await PatchAsync($"{VerintOnlineFormEndpoint}/update-form-data", request);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(UpdateVerintOnlineFormFormData)}: " +
                         $"An unexpected error occurred adding form data for VOF {request.VerintOnlineFormReference} - {exception.Message}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!verintResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintServiceGateway)}::{nameof(VerintServiceGateway.UpdateVerintOnlineFormFormData)}: " +
                         $"Failed to add form data for VOF {request.VerintOnlineFormReference} - {verintResponse.ReasonPhrase}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(verintResponse.StatusCode, log);
        }
    }
}
