using LastfmProtosClient;
using Microsoft.AspNetCore.Mvc;

namespace Lastfm.gRPC.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageSenderController : ControllerBase
    {
        public MessageSenderController()
        {
        }

        [HttpPost(Name = "GetLovedTracks")]
        public object GetLovedTracks()
        {
            using var GrpcChannel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:7066");
            var client = new LastfmService.LastfmServiceClient(GrpcChannel);
            var response = client.GetLovedTracksAsync(new LovedTrackRequest() { });
            var tracks = response.ResponseAsync.Result;

            return tracks;
        }
    }
}