using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Gateways.VerintService;

namespace StockportGovUK.NetStandard.Gateways.Helpers.Verint;

public class VerintHelper : IVerintHelper
{
    private readonly IVerintServiceGateway _verintServiceGateway;
    private readonly ILogger<VerintHelper> _logger;

    public VerintHelper(IVerintServiceGateway verintServiceGateway, ILogger<VerintHelper> logger)
    {
        _verintServiceGateway = verintServiceGateway;
        _logger = logger;
    }

    public async Task<VerintOnlineFormResponse> CreateVerintOnlineFormCase(VerintOnlineFormRequest request)
    {
        HttpResponse<VerintOnlineFormResponse> response;
        try
        {
            response = await _verintServiceGateway.CreateVerintOnlineFormCase(request);
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintHelper)}::{nameof(CreateVerintOnlineFormCase)}::" +
                $"{nameof(_verintServiceGateway)}::{nameof(_verintServiceGateway.CreateVerintOnlineFormCase)}: " +
                $"An unexpected error occurred while creating Case - {exception.Message}");
        }

        if (!response.IsSuccessStatusCode)
            throw new HttpResponseException(response.StatusCode,
                $"{nameof(VerintHelper)} :: {nameof(CreateVerintOnlineFormCase)}::" +
                $"{nameof(_verintServiceGateway)}::{nameof(_verintServiceGateway.CreateVerintOnlineFormCase)}: " +
                $"failed to create Case with status code {response.StatusCode}");

        return response.ResponseContent;
    }

    public async Task AddFormDataToVerintOnlineForm(VerintOnlineFormUpdateRequest request, bool logOnly = false)
    {
        HttpResponseMessage verintResponse;
        try
        {
            verintResponse = await _verintServiceGateway.UpdateVerintOnlineFormFormData(request);
        }
        catch (Exception exception)
        {
            string log = $"{nameof(VerintHelper)}::{nameof(AddFormDataToVerintOnlineForm)}: " +
                         $"An unexpected error occurred adding form data for VOF {request.VerintOnlineFormReference} " +
                         $"- {exception.Message} {exception.StackTrace}";
            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(424, log);

            return;
        }

        if (!verintResponse.IsSuccessStatusCode)
        {
            string log = $"{nameof(VerintHelper)}::{nameof(AddFormDataToVerintOnlineForm)}: " +
                         $"Failed to add form data for VOF {request.VerintOnlineFormReference} " +
                         $"- {verintResponse.ReasonPhrase}";

            if (logOnly)
                _logger.LogError(log);
            else
                throw new HttpResponseException(verintResponse.StatusCode, log);
        }
            
    }
}
