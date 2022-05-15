using Grpc.Core;
using Lastfm.Client.Services;
using LastfmProtos;

public class LastfmServiceImpl : LastfmService.LastfmServiceBase
{
    public override async Task GetLovedTracksStream(LovedTrackStreamRequest request, IServerStreamWriter<LovedTrackResponse> responseStream, ServerCallContext context)
    {
        var tracks = LastfmServiceClient.UserGetLovedTracks().Lovedtracks;
        var packageSize = tracks.Track.Count / request.Count;
        for (int i = 0; i < packageSize;)
        {
            var data = tracks.Track.Skip(i).Take(request.Count);
            i += request.Count;

            var response = GetLovedTracksInternal(data, tracks.Attr);

            await responseStream.WriteAsync(new LovedTrackResponse
            {
                Lovedtracks = response
            });
            Thread.Sleep(250);
        }
    }

    public override async Task<LovedTrackResponse> GetLovedTracks(LovedTrackRequest request, ServerCallContext context)
    {
        var tracks = LastfmServiceClient.UserGetLovedTracks();

        var response = new LovedTrackResponse
        {
            Lovedtracks = GetLovedTracksInternal(tracks.Lovedtracks.Track, tracks.Lovedtracks.Attr)
        };

        return await Task.FromResult(response);
    }

    private static Lovedtracks GetLovedTracksInternal(IEnumerable<Lastfm.Client.Models.Track> tracks, Lastfm.Client.Models.Attr attr)
    {
        var model = new Lovedtracks();
        var list = new List<Track>();
        foreach (var item in tracks)
        {
            var tr = new Track
            {
                Artist = new Artist
                {
                    Name = item.Artist.Name,
                    Mbid = item.Artist.Mbid,
                    Url = item.Artist.Url.ToString()
                },
                Date = new Date
                {
                    Text = item.Date.Text,
                    Uts = item.Date.Uts
                },
                Mbid = item.Mbid,
                Name = item.Name,
                Url = item.Url.ToString(),
                Streamable = new Streamable
                {
                    Fulltrack = item.Streamable.Fulltrack,
                    Text = item.Streamable.Text
                }
            };

            var images = item.Image.Select(e => new Image
            {
                Size = (Size)Enum.Parse(typeof(Size), e.Size.ToString()),
                Text = e.Text.ToString()
            });

            tr.Image.AddRange(images);

            list.Add(tr);
        }

        model.Attr = new Attr
        {
            Page = attr.Page,
            PerPage = attr.PerPage,
            Total = attr.Total,
            TotalPages = attr.TotalPages,
            User = attr.User
        };

        model.Track.AddRange(list);

        return model;
    }
}