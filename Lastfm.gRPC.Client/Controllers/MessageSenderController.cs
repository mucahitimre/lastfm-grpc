using LastfmProtosClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lastfm.gRPC.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageSenderController : ControllerBase
    {
        public MessageSenderController()
        {
        }

        [HttpGet("UnaryGetLovedTracks")]
        public object UnaryGetLovedTracks()
        {
            using var GrpcChannel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:7066");
            var client = new LastfmService.LastfmServiceClient(GrpcChannel);
            var response = client.GetLovedTracksAsync(new LovedTrackRequest() { });
            var tracks = response.ResponseAsync.Result;

            return tracks;
        }

        [HttpGet("StreamGetLovedTracks")]
        public async Task StreamGetLovedTracks()
        {
            using var GrpcChannel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:7066");
            var client = new LastfmService.LastfmServiceClient(GrpcChannel);
            var response = client.GetLovedTracksStream(new LovedTrackStreamRequest { Count = 1 });

            Response.ContentType = "application/json";
            StreamWriter sw;
            await using ((sw = new StreamWriter(Response.Body)).ConfigureAwait(false))
            {
                while (await response.ResponseStream.MoveNext(new CancellationToken(false)))
                {
                    await sw.WriteLineAsync(JsonConvert.SerializeObject(response.ResponseStream.Current)).ConfigureAwait(false);
                    await sw.FlushAsync().ConfigureAwait(false);
                }
            }
        }
    }
}