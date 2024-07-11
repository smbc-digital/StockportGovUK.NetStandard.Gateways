﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string UserEndpoint = "api/v1/User";

        public async Task<HttpResponseMessage> GetUserById(Guid id) =>
            await GetAsync($"{UserEndpoint}/{id}");

        public async Task<HttpResponseMessage> GetUserByUsername(string username) =>
            await GetAsync($"{UserEndpoint}/name/{username}");

        public async Task<HttpResponseMessage> GetUsersByUsernameFuzzy(string username) =>
            await GetAsync($"{UserEndpoint}/fuzzy/{username}");

        public async Task<HttpResponseMessage> MakeUserSuperuser(BaseUserRequest request) =>
            await PatchAsync($"{UserEndpoint}/make-superuser", request);

        public async Task<HttpResponseMessage> RemoveSuperuserPermission(BaseUserRequest request) =>
            await PatchAsync($"{UserEndpoint}/remove-superuser", request);

        public async Task<HttpResponseMessage> ActivateUser(BaseUserRequest request) =>
            await PatchAsync($"{UserEndpoint}/activate", request);

        public async Task<HttpResponseMessage> DeactivateUser(BaseUserRequest request) =>
            await PatchAsync($"{UserEndpoint}/deactivate", request);

        public async Task<HttpResponseMessage> RemoveUserContextPermissions(BaseUserRequest request) =>
            await PatchAsync($"{UserEndpoint}/remove-context-permissions", request);
    }
}
