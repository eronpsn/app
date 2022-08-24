using System.Text.Json.Serialization;

namespace Eclilar.Infraestrutura.Seguranca.Models
{
    public class UsuarioModel
    {
         [JsonPropertyName("user_id")]
        public string UserId { get; set; }

         [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("user_email")]
        public string UserEmail { get; set; }

        [JsonPropertyName("user_phone")]
        public string UserPhone { get; set; }       

        [JsonPropertyName("user_image")]
        public string UserImage { get; set; }
   
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        
    }
}