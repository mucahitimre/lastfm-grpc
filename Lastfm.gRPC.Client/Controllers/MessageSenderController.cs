using LastfmProtosClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.PostOffice.Publisher.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageSenderController : ControllerBase
    {
        public MessageSenderController()
        {
        }

        [HttpPost(Name = "SendMessage")]
        public bool SendMessage()
        {
            var factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                HostName = "localhost"
            };

            using var GrpcChannel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:7066");
            var client = new LastfmService.LastfmServiceClient(GrpcChannel);
            var response = client.GetLovedTracksAsync(new LovedTrackRequest() { });
            var tracks = response.ResponseAsync.Result;
            var lovedOrdered = tracks.Lovedtracks.Track.GroupBy(e => e.Artist).OrderByDescending(e => e.Count()).ToList();

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                foreach (var item in lovedOrdered)
                {
                    channel.QueueDeclare(queue: "Artist",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var bodyArtist = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item.Key));

                    channel.BasicPublish(exchange: "",
                                         routingKey: "Artist",
                                         basicProperties: null,
                                         body: bodyArtist);

                    channel.QueueDeclare(queue: "Artist.Track",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item.ToArray()));

                    channel.BasicPublish(exchange: "",
                                         routingKey: "Artist.Track",
                                         basicProperties: null,
                                         body: body);
                }
            }

            return true;
        }
    }
}


