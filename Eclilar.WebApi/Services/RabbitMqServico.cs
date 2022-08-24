using System;
using System.Text;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades.Rabbit;
using Eclilar.WebApi.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Eclilar.WebApi.Services
{

    public class RabbitMqServico :BaseService, IRabbitMqServico
    {
        private readonly ILogger<RabbitMqServico> _logger;

        public QueueDeclare CriaFila(QueueDeclare dados)
        {
             try
            {
                var factory = new ConnectionFactory() { HostName = "192.168.0.8" };
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
                 Console.WriteLine(" [x] error {0}",ex.Message.ToString());
            }
            return null;
        }

        public Notificacao EnviaNotificacao(Notificacao dados)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "192.168.0.8" };
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
                Console.WriteLine(" [x] error {0}",ex.Message.ToString());
                return null;
            }
        }
    }
    }