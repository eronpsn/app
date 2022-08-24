namespace Eclilar.Dominio.Entidades.Rabbit
{
    public class Notificacao
    {
        public string RoutingKey { get; set; }
        public string Message {get; set;}
    }
}