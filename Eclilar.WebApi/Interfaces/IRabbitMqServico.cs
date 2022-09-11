using System.Threading.Tasks;
using Eclilar.Dominio.Entidades.Rabbit;

namespace Eclilar.WebApi.Interfaces
{
    public interface IRabbitMqServico
    {
        QueueDeclare CriaFila(QueueDeclare dados);
        Notificacao EnviaNotificacao(Notificacao dados);
       void CriarFilaEnviaMsg(string queue, string routingKey, string msg);
    }
}