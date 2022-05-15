using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Lastfm.Client.Http;

/// <summary>
/// The HTTP request model
/// </summary>
public class HttpRequestModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpRequestModel"/> class.
    /// </summary>
    /// <param name="baseAddress">The base address.</param>
    /// <param name="endpoint">The endpoint.</param>
    /// <param name="method">The method.</param>
    /// <param name="headers">The headers.</param>
    /// <param name="parameters">The parameters.</param>
    private HttpRequestModel(Uri baseAddress,
        Uri endpoint,
        HttpMethod method,
        IDictionary<string, string> headers,
        IDictionary<string, string> parameters)
    {
        BaseAddress = baseAddress;
        Endpoint = endpoint;
        Method = method;
        Headers = headers;
        Parameters = parameters;
    }

    /// <summary>
    /// Creates the specified base address.
    /// </summary>
    /// <param name="baseAddress">The base address.</param>
    /// <param name="endpoint">The endpoint.</param>
    /// <param name="method">The method.</param>
    /// <param name="headers">The headers.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns></returns>
    public static HttpRequestModel Create(
        Uri baseAddress,
        Uri endpoint,
        HttpMethod method,
        IDictionary<string, string> headers,
        IDictionary<string, string> parameters)
    {
        return new HttpRequestModel(baseAddress, endpoint, method, headers, parameters);
    }

    /// <summary>
    /// Gets the base address.
    /// </summary>
    /// <value>
    /// The base address.
    /// </value>
    public Uri BaseAddress { get; }

    /// <summary>
    /// Gets the endpoint.
    /// </summary>
    /// <value>
    /// The endpoint.
    /// </value>
    public Uri Endpoint { get; }

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <value>
    /// The headers.
    /// </value>
    public IDictionary<string, string> Headers { get; }

    /// <summary>
    /// Gets the parameters.
    /// </summary>
    /// <value>
    /// The parameters.
    /// </value>
    public IDictionary<string, string> Parameters { get; }

    /// <summary>
    /// Gets the method.
    /// </summary>
    /// <value>
    /// The method.
    /// </value>
    public HttpMethod Method { get; }

    /// <summary>
    /// Gets or sets the body.
    /// </summary>
    /// <value>
    /// The body.
    /// </value>
    public string Body { get; set; }
}
