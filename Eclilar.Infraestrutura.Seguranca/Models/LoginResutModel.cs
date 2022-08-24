using System.Text.Json.Serialization;
using Eclilar.Infraestrutura.Seguranca.Models;

namespace Eclilar.Infraestrutura.Seguranca.Models
{
    public class LoginResultModel
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("details")]
        public UsuarioModel Details { get; set; }
    }
}