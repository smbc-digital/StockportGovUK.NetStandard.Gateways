using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Response;
using Address = StockportGovUK.NetStandard.Gateways.Models.Verint.Address;

namespace StockportGovUK.NetStandard.Gateways.VerintService;
public partial class VerintServiceGateway : Gateway, IVerintServiceGateway
{
    private const string PropertyEndpoint = "api/v1/Property";

    public async Task<List<AddressSearchResult>> SearchForPropertyByPostcode(string postcode)
    {
        HttpResponse<List<AddressSearchResult>> addressResponse;
        try
        {
            addressResponse = await GetAsync<List<AddressSearchResult>>($"{PropertyEndpoint}/search/{postcode}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(SearchForPropertyByPostcode)}: " +
                $"An unexpected error occurred using postcode {postcode} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(SearchForPropertyByPostcode)}: " +
                $"Request for postcode {postcode} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }

    public async Task<Address> GetPropertyByPlaceRef(string placeRef)
    {
        HttpResponse<Address> addressResponse;
        try
        {
            addressResponse = await GetAsync<Address>($"{PropertyEndpoint}/{placeRef}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetPropertyByPlaceRef)}: " +
                $"An unexpected error occurred using placeRef {placeRef} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(GetPropertyByPlaceRef)}: " +
                $"Request for placeRef {placeRef} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }

    public async Task<Address> GetPropertyFromUprn(string uprn)
    {
        HttpResponse<Address> addressResponse;
        try
        {
            addressResponse = await GetAsync<Address>($"{PropertyEndpoint}/uprn/{uprn}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetPropertyFromUprn)}: " +
                $"An unexpected error occurred using UPRN {uprn} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(GetPropertyFromUprn)}: " +
                $"Request for UPRN {uprn} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }
}
