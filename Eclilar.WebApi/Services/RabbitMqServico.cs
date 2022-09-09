using System;
using System.Text;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades.Rabbit;
using Eclilar.WebApi.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Eclilar.WebApi.Services
{

    public class RabbitMqServico : BaseService, IRabbitMqServico
    {
        private readonly ILogger<RabbitMqServico> _logger;

        public QueueDeclare CriaFila(QueueDeclare dados)
        {
            try
            {
                IConfigurationRoot _configuration = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile("appsettings.json")
.Build();
                var factory = new ConnectionFactory()
                {
                    HostName = _configuration.GetValue<string>("Modules:RabbitMq:HostName"),
                    VirtualHost = _configuration.GetValue<string>("Modules:RabbitMq:VirtualHost"),
                    UserName = _configuration.GetValue<string>("Modules:RabbitMq:UserName"),
                    Password = _configuration.GetValue<string>("Modules:RabbitMq:Password")
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: dados.Queue,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" [x] error {0}", ex.Message.ToString());
            }
            return null;
        }

        public Notificacao EnviaNotificacao(Notificacao dados)
        {
            try
            {
                IConfigurationRoot _configuration = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile("appsettings.json")
.Build();
                var factory = new ConnectionFactory()
                {
                    HostName = _configuration.GetValue<string>("Modules:RabbitMq:HostName"),
                    VirtualHost = _configuration.GetValue<string>("Modules:RabbitMq:VirtualHost"),
                    UserName = _configuration.GetValue<string>("Modules:RabbitMq:UserName"),
                    Password = _configuration.GetValue<string>("Modules:RabbitMq:Password")
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {

                    var body = Encoding.UTF8.GetBytes(dados.Message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: dados.RoutingKey,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0} to {1}", dados.Message, dados.RoutingKey);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" [x] error {0}", ex.Message.ToString());
                return null;
            }
        }
    }
}