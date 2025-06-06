﻿using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Extensions;
using StockportGovUK.NetStandard.Gateways.Models.WiredPlus;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public class WiredPlusGateway : Gateway, IWiredPlusGateway
    {
        // Base URL :  https://api.wiredplus.com/
        // Usage Auth Token can be added in the gateway setup as per normal BUT needs to be a BASE64 encoded string of - https://www.base64encode.org/
        // {API_KEY_NAME}:{API_KEY}

        private const string CreateContactEndpoint = "v1/CreateContact";
        private const string UpdateContactEndpoint = "v1/UpdateContact";
        private const string GetListByIdEndpoint = "v1/GetListById";
        private const string ResubscribeContactEndpoint = "v1/ResubscribeContact";
        private const string GetContactByEmailEndpoint = "v1/GetContactByEmail";
        private const string GetAccountInfoEndpoint = "v1/GetAccountInfo";

        public WiredPlusGateway(HttpClient httpClient) : base(httpClient) { }

        public async Task<HttpResponse<object>> GetAccountInfo() =>
            await GetAsync<object>(GetAccountInfoEndpoint);

        public async Task<HttpResponse<NewsletterSignUpResponse>> CreateContact(NewsletterSignUpRequest request)
        {
            var content = new MultipartFormDataContent();

            content.AddIfNotNull(request.FirstName, "first_name");
            content.AddIfNotNull(request.LastName, "last_name");
            content.AddIfNotNull(request.Name, "name");
            content.AddIfNotNull(request.Gender, "gender");
            content.AddIfNotNull(request.Company, "company");
            content.AddIfNotNull(request.JobTitle, "job_title");
            content.AddIfNotNull(request.Address, "address");
            content.AddIfNotNull(request.AddressLine2, "address_2");
            content.AddIfNotNull(request.City, "city");
            content.AddIfNotNull(request.County, "county");
            content.AddIfNotNull(request.Postcode, "post_code");
            content.AddIfNotNull(request.Country, "country");
            content.AddIfNotNull(request.CountryCode, "country_code");
            content.AddIfNotNull(request.WebAddress, "www");
            content.AddIfNotNull(request.Email, "email");
            content.AddIfNotNull(request.Telephone, "telephone");
            content.AddIfNotNull(request.Mobile, "mobile");
            content.AddIfNotNull(request.Tags, "tags");
            content.AddIfNotNull(request.OptIn.ToString(), "opt_in");
            content.AddIfNotNull(request.ContactListId.ToString(), "contact_list_id");


            request.CustomValues.ForEach(_ => content.Add(new StringContent(_.Value), _.Key));

            return await PostAsync<NewsletterSignUpResponse>(CreateContactEndpoint, content, false);
        }

        public async Task<HttpResponse<NewsletterSignUpResponse>> UpdateContact(NewsletterSignUpRequest request)
        {
            var content = new MultipartFormDataContent();

            content.AddIfNotNull(request.FirstName, "first_name");
            content.AddIfNotNull(request.LastName, "last_name");
            content.AddIfNotNull(request.Name, "name");
            content.AddIfNotNull(request.Gender, "gender");
            content.AddIfNotNull(request.Company, "company");
            content.AddIfNotNull(request.JobTitle, "job_title");
            content.AddIfNotNull(request.Address, "address");
            content.AddIfNotNull(request.AddressLine2, "address_2");
            content.AddIfNotNull(request.City, "city");
            content.AddIfNotNull(request.County, "county");
            content.AddIfNotNull(request.Postcode, "post_code");
            content.AddIfNotNull(request.Country, "country");
            content.AddIfNotNull(request.CountryCode, "country_code");
            content.AddIfNotNull(request.WebAddress, "www");
            content.AddIfNotNull(request.Email, "email");
            content.AddIfNotNull(request.Telephone, "telephone");
            content.AddIfNotNull(request.Mobile, "mobile");
            content.AddIfNotNull(request.Tags, "tags");
            content.AddIfNotNull(request.OptIn.ToString(), "opt_in");
            content.AddIfNotNull(request.ContactListId.ToString(), "contact_list_id");


            request.CustomValues.ForEach(_ => content.Add(new StringContent(_.Value), _.Key));

            return await PostAsync<NewsletterSignUpResponse>(UpdateContactEndpoint, content, false);
        }

        public async Task<HttpResponse<GetListByIdResponse>> GetListById(GetListByIdRequest request)
        {
            var content = new MultipartFormDataContent();

            content.AddIfNotNull(request.Id.ToString(), "listid");

            return await PostAsync<GetListByIdResponse>(GetListByIdEndpoint, content, false);
        }

        public async Task<HttpResponse<object>> ResubscribeContact(NewsletterSignUpRequest request)
        {
            var content = new MultipartFormDataContent();
            
            content.AddIfNotNull(request.Email, "email");

            return await PostAsync<object>(ResubscribeContactEndpoint, content, false);
        }

        public async Task<HttpResponse<NewsletterContactResponse>> GetContactByEmail(NewsletterSignUpRequest request)
        {
            var content = new MultipartFormDataContent();

            content.AddIfNotNull(request.Email, "email");

            return await PostAsync<NewsletterContactResponse>(GetContactByEmailEndpoint, content, false);
        }
    }
}
