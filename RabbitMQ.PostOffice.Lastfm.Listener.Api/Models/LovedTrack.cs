using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RabbitMQ.PostOffice.Lastfm.Listener.Api.Models;

/// <summary>
/// The loved track
/// </summary>
/// <summary>
/// The loved track
/// </summary>
public class LovedTrack
{
    /// <summary>
    /// Gets or sets the lovedtracks.
    /// </summary>
    /// <value>
    /// The lovedtracks.
    /// </value>
    [JsonProperty("lovedtracks")]
    public Lovedtracks Lovedtracks { get; set; }
}

/// <summary>
/// The lovedtracks
/// </summary>
public class Lovedtracks
{
    /// <summary>
    /// Gets or sets the track.
    /// </summary>
    /// <value>
    /// The track.
    /// </value>
    [JsonProperty("track")]
    public List<Track> Track { get; set; }

    /// <summary>
    /// Gets or sets the attribute.
    /// </summary>
    /// <value>
    /// The attribute.
    /// </value>
    [JsonProperty("@attr")]
    public Attr Attr { get; set; }
}

/// <summary>
/// The attribute
/// </summary>
public class Attr
{
    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>
    /// The user.
    /// </value>
    [JsonProperty("user")]
    public string User { get; set; }

    /// <summary>
    /// Gets or sets the total pages.
    /// </summary>
    /// <value>
    /// The total pages.
    /// </value>
    [JsonProperty("totalPages")]
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the page.
    /// </summary>
    /// <value>
    /// The page.
    /// </value>
    [JsonProperty("page")]
    public int Page { get; set; }

    /// <summary>
    /// Gets or sets the per page.
    /// </summary>
    /// <value>
    /// The per page.
    /// </value>
    [JsonProperty("perPage")]
    public int PerPage { get; set; }

    /// <summary>
    /// Gets or sets the total.
    /// </summary>
    /// <value>
    /// The total.
    /// </value>
    [JsonProperty("total")]
    public int Total { get; set; }
}

/// <summary>
/// The track
/// </summary>
public class Track
{
    /// <summary>
    /// Gets or sets the artist.
    /// </summary>
    /// <value>
    /// The artist.
    /// </value>
    [JsonProperty("artist")]
    public Artist Artist { get; set; }

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>
    /// The date.
    /// </value>
    [JsonProperty("date")]
    public Date Date { get; set; }

    /// <summary>
    /// Gets or sets the mbid.
    /// </summary>
    /// <value>
    /// The mbid.
    /// </value>
    [JsonProperty("mbid")]
    public string Mbid { get; set; }

    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    /// <value>
    /// The URL.
    /// </value>
    [JsonProperty("url")]
    public Uri Url { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    /// <value>
    /// The image.
    /// </value>
    [JsonProperty("image")]
    public List<Image> Image { get; set; }

    /// <summary>
    /// Gets or sets the streamable.
    /// </summary>
    /// <value>
    /// The streamable.
    /// </value>
    [JsonProperty("streamable")]
    public Streamable Streamable { get; set; }
}

/// <summary>
/// The artist
/// </summary>
public class Artist
{
    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    /// <value>
    /// The URL.
    /// </value>
    [JsonProperty("url")]
    public Uri Url { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the mbid.
    /// </summary>
    /// <value>
    /// The mbid.
    /// </value>
    [JsonProperty("mbid")]
    public string Mbid { get; set; }
}

/// <summary>
/// The date
/// </summary>
public class Date
{
    /// <summary>
    /// Gets or sets the uts.
    /// </summary>
    /// <value>
    /// The uts.
    /// </value>
    [JsonProperty("uts")]
    public int Uts { get; set; }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    [JsonProperty("#text")]
    public string Text { get; set; }
}

/// <summary>
/// The image
/// </summary>
public class Image
{
    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    /// <value>
    /// The size.
    /// </value>
    [JsonProperty("size")]
    public Size Size { get; set; }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    [JsonProperty("#text")]
    public Uri Text { get; set; }
}

/// <summary>
/// The streamable
/// </summary>
public class Streamable
{
    /// <summary>
    /// Gets or sets the fulltrack.
    /// </summary>
    /// <value>
    /// The fulltrack.
    /// </value>
    [JsonProperty("fulltrack")]
    public int Fulltrack { get; set; }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    [JsonProperty("#text")]
    public int Text { get; set; }
}

/// <summary>
/// The size
/// </summary>
public enum Size { Extralarge, Large, Medium, Small };
