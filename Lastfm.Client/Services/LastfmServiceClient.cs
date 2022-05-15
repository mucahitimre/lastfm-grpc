﻿using Lastfm.Client.Handlers;
using Lastfm.Client.Http;
using Lastfm.Client.Models;
using Newtonsoft.Json;
using System.Net;

namespace Lastfm.Client.Services
{
    public static class LastfmServiceClient
    {
        public static LovedTrack UserGetLovedTracks()
        {
            var response = new LovedTrack();
            var request = CreateRequestModel();
            var httpResponse = new HttpHandler().Post(request);
            if (httpResponse.IsSuccess && httpResponse.StatusCode == HttpStatusCode.OK)
            {
                response = JsonConvert.DeserializeObject<LovedTrack>(httpResponse.Body);
            }

            return response;
        }

        private static HttpRequestModel CreateRequestModel()
        {
            var headers = new Dictionary<string, string>();

            // https://ws.audioscrobbler.com/2.0/?method=user.getlovedtracks&user=kolombokunta&api_key=&format=json&limit=500
            var parameters = new Dictionary<string, string>()
            {
                { "user", "kolombokunta" },
                { "limit", "550" },
                { "api_key", "" },
                { "format", "json" }
            };

            var methodName = LastfmMethodType.UserGetlovedtracks.GetDescription();
            var methodUrl = new Uri(methodName, UriKind.Relative);
            var request = HttpRequestModel.Create(Constants.Urls.APIV2, methodUrl, HttpMethod.Get, headers, parameters);

            return request;
        }
    }
}
