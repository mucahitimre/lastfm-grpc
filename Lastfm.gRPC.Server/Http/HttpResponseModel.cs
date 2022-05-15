using System;
using System.Collections.Generic;
using System.Net;

namespace RabbitMQ.PostOffice.Lastfm.Listener.Api.Http;

/// <summary>
/// The HTTP response model
/// </summary>
public class HttpResponseModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResponseModel" /> class.
    /// </summary>
    /// <param name="headers">The headers.</param>
    public HttpResponseModel(IDictionary<string, string> headers)
    {
        IsSuccess = true;
        Headers = new Dictionary<string, string>(headers);
    }

    /// <summary>
    /// Withes the error message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public static HttpResponseModel WithErrorMessage(string message)
    {
        return new HttpResponseModel(message);
    }

    /// <summary>
    /// Withes the error.
    /// </summary>
    /// <param name="e">The e.</param>
    /// <returns></returns>
    public static HttpResponseModel WithError(Exception e)
    {
        return new HttpResponseModel(e);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResponseModel"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    private HttpResponseModel(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpResponseModel"/> class.
    /// </summary>
    /// <param name="exception">The exception.</param>
    private HttpResponseModel(Exception exception)
    {
        IsSuccess = false;
        ErrorMessage = exception.Message;
    }

    /// <summary>
    /// Gets or sets the body.
    /// </summary>
    /// <value>
    /// The body.
    /// </value>
    public string Body { get; set; }

    /// <summary>
    /// Gets the headers.
    /// </summary>
    /// <value>
    /// The headers.
    /// </value>
    public IReadOnlyDictionary<string, string> Headers { get; }

    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    /// <value>
    /// The status code.
    /// </value>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the type of the content.
    /// </summary>
    /// <value>
    /// The type of the content.
    /// </value>
    public string ContentType { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is success.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>
    /// The error message.
    /// </value>
    public string ErrorMessage { get; }

}
