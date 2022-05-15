using Grpc.Core;
using LastfmProtos;
using RabbitMQ.PostOffice.Lastfm.Listener.Api.Services;

public class LastfmServiceImpl : LastfmService.LastfmServiceBase
{
    public override Task<LovedTrackResponse> GetLovedTracks(LovedTrackRequest request, ServerCallContext context)
    {
        var tracks = Lastfm.UserGetLovedTracks();

        var model = new LovedTrackResponse();

        var list = new List<Track>();
        tracks.Lovedtracks.Track.ForEach(e =>
        {
            var tr = new Track
            {
                Artist = new Artist
                {
                    Name = e.Artist.Name,
                    Mbid = e.Artist.Mbid,
                    Url = e.Artist.Url.ToString()
                },
                Date = new Date
                {
                    Text = e.Date.Text,
                    Uts = e.Date.Uts
                },
                Mbid = e.Mbid,
                Name = e.Name,
                Url = e.Url.ToString(),
                Streamable = new Streamable
                {
                    Fulltrack = e.Streamable.Fulltrack,
                    Text = e.Streamable.Text
                }

            };

            var images = e.Image.Select(e => new Image
            {
                Size = (Size)Enum.Parse(typeof(Size), e.Size.ToString()),
                Text = e.Text.ToString()
            });

            tr.Image.AddRange(images);

            list.Add(tr);
        });

        model.Lovedtracks = new Lovedtracks()
        {
            Attr = new Attr
            {
                Page = tracks.Lovedtracks.Attr.Page,
                PerPage = tracks.Lovedtracks.Attr.PerPage,
                Total = tracks.Lovedtracks.Attr.Total,
                TotalPages = tracks.Lovedtracks.Attr.TotalPages,
                User = tracks.Lovedtracks.Attr.User
            }
        };

        model.Lovedtracks.Track.AddRange(list);

        return Task.FromResult(model);
    }
}