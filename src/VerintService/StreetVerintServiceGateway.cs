using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Exceptions;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.VerintService;

public partial class VerintServiceGateway : Gateway, IVerintServiceGateway
{
    private const string StreetEndpoint = "api/v1/Street";

    public async Task<List<AddressSearchResult>> GetStreetByReference(string street)
    {
        HttpResponse<List<AddressSearchResult>> addressResponse;
        try
        {
            addressResponse = await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/streetsearch/{street}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetStreetByReference)}: " +
                $"An unexpected error occurred using street {street} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(GetStreetByReference)}: " +
                $"Request for street {street} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }

    public async Task<List<AddressSearchResult>> GetStreetByUsrn(string usrn)
    {
        HttpResponse<List<AddressSearchResult>> addressResponse;
        try
        {
            addressResponse = await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/usrnsearch/{usrn}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetStreetByUsrn)}: " +
                $"An unexpected error occurred using USRN {usrn} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(GetStreetByUsrn)}: " +
                $"Request for USRN {usrn} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }

    public async Task<List<AddressSearchResult>> SearchForPropertyByUsrn(string usrn)
    {
        HttpResponse<List<AddressSearchResult>> addressResponse;
        try
        {
            addressResponse = await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/search-usrn/{usrn}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(SearchForPropertyByUsrn)}: " +
                $"An unexpected error occurred using USRN {usrn} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(SearchForPropertyByUsrn)}: " +
                $"Request for USRN {usrn} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }

    public async Task<AddressSearchResult> GetStreet(string reference)
    {
        HttpResponse<AddressSearchResult> addressResponse;
        try
        {
            addressResponse = await GetAsync<AddressSearchResult>($"{StreetEndpoint}/{reference}");
        }
        catch (Exception exception)
        {
            throw new HttpResponseException(424,
                $"{nameof(VerintServiceGateway)}::{nameof(GetStreet)}: " +
                $"An unexpected error occurred using reference {reference} - {exception.Message}");
        }

        if (!addressResponse.IsSuccessStatusCode)
            throw new HttpResponseException(addressResponse.StatusCode,
                $"{nameof(VerintServiceGateway)}::{nameof(GetStreet)}: " +
                $"Request for reference {reference} failed - {addressResponse.ReasonPhrase}");

        return addressResponse.ResponseContent;
    }
}
