using System.ComponentModel;

namespace Lastfm.Client.Models;

/// <summary>
/// The lastfm method type.
/// </summary>
public enum LastfmMethodType
{
    /// <summary>
    /// The user get loved tracks.
    /// </summary>
    [Description("?method=user.getlovedtracks")]
    UserGetlovedtracks = 1
}