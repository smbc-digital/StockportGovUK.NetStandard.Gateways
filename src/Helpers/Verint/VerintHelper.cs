using System;
using System.Net;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Gateways.VerintService;

namespace StockportGovUK.NetStandard.Gateways.Helpers.Verint;

public class VerintHelper : IVerintHelper
{
    private readonly IVerintServiceGateway _verintServiceGateway;

    public VerintHelper(IVerintServiceGateway verintServiceGateway)
    {
        _verintServiceGateway = verintServiceGateway;
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
}
