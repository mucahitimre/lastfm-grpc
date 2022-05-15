using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Lastfm.Client.Http;

/// <summary>
/// The HTTP handler
/// </summary>
public class HttpHandler
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpHandler"/> class.
    /// </summary>
    public HttpHandler()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Posts the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    public HttpResponseModel Post(HttpRequestModel request)
    {
        try
        {
            var uriBuilder = new UriBuilder(request.BaseAddress)
            {
                Query = request.Endpoint.ToString() + GetParams(request)
            };

            using (var requestMsg = new HttpRequestMessage(request.Method, uriBuilder.Uri))
            {
                foreach (var header in request.Headers)
                {
                    requestMsg.Headers.Add(header.Key, header.Value);
                }
                if (request.Method == HttpMethod.Post)
                {
                    requestMsg.Content = new StringContent(request.Body, Encoding.UTF8, "application/json");
                }

                using (var responseMsg = _httpClient.SendAsync(requestMsg, HttpCompletionOption.ResponseContentRead).Result)
                using (var content = responseMsg.Content)
                {
                    var responseHeaders = responseMsg.Headers.ToDictionary(header => header.Key, header => header.Value.First());
                    var responseBody = responseMsg.Content.ReadAsStringAsync().Result;
                    var responseContentType = content.Headers?.ContentType?.MediaType;

                    return new HttpResponseModel(responseHeaders)
                    {
                        Body = responseBody,
                        ContentType = responseContentType,
                        StatusCode = responseMsg.StatusCode
                    };
                }
            }
        }
        catch (Exception e)
        {
            //log
            return HttpResponseModel.WithError(e);
        }
    }

    private static string GetParams(HttpRequestModel request)
    {
        return request.Parameters.Any() ? "&" + string.Join("&", request.Parameters.Select(x => x.Key + "=" + x.Value).ToArray()) : "";
    }
}
