using Newtonsoft.Json;
using RabbitMQ.PostOffice.Lastfm.Listener.Api.Handlers;
using RabbitMQ.PostOffice.Lastfm.Listener.Api.Http;
using RabbitMQ.PostOffice.Lastfm.Listener.Api.Models;
using System.Net;

namespace RabbitMQ.PostOffice.Lastfm.Listener.Api.Services
{
    public static class Lastfm
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

            // https://ws.audioscrobbler.com/2.0/?method=user.getlovedtracks&user=kolombokunta&api_key=2e797413106c040d565dc01ba07bb857&format=json&limit=500
            var parameters = new Dictionary<string, string>()
            {
                { "user", "kolombokunta" },
                { "limit", "550" },
                { "api_key", "2e797413106c040d565dc01ba07bb857" },
                { "format", "json" }
            };

            var methodName = LastfmMethodType.UserGetlovedtracks.GetDescription();
            var methodUrl = new Uri(methodName, UriKind.Relative);
            var request = HttpRequestModel.Create(Constants.Urls.APIV2, methodUrl, HttpMethod.Get, headers, parameters);

            return request;
        }
    }
}
