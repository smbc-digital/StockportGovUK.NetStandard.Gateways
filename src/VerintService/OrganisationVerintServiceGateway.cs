using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.VerintService;

public partial class VerintServiceGateway : Gateway, IVerintServiceGateway
{
    private const string OrganisationEndpoint = "api/v1/Organisation";

    public async Task<List<OrganisationSearchResult>> SearchForOrganisationByName(string organisation)
    {
        HttpResponse<List<OrganisationSearchResult>> organisationSearchResult;
        try
        {
            organisationSearchResult = await GetAsync<List<OrganisationSearchResult>>($"{OrganisationEndpoint}/search/{organisation}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(SearchForOrganisationByName)}: " +
                $"An unexpected error occurred using organisation {organisation} - {exception.Message}");
        }

        if (!organisationSearchResult.IsSuccessStatusCode)
            throw new HttpResponseException(organisationSearchResult.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(SearchForOrganisationByName)}: " +
                $"Request for organisation {organisation} failed - {organisationSearchResult.ReasonPhrase}");

        return organisationSearchResult.ResponseContent;
    }
}
