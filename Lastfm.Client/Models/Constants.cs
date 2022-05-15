using System;

namespace Lastfm.Client.Models;

/// <summary>
/// The constants
/// </summary>
public static class Constants
{
    /// <summary>
    /// The urls
    /// </summary>
    public static class Urls
    {
        // https://ws.audioscrobbler.com/2.0/?method=user.getlovedtracks&user=kolombokunta&api_key=&format=json&limit=500
        /// <summary>
        /// The API v2
        /// </summary>
        public static readonly Uri APIV2 = new("https://ws.audioscrobbler.com/2.0/?");
    }
}