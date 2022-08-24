 using System.Text.Json.Serialization;
 using System.ComponentModel.DataAnnotations;
 namespace Eclilar.Infraestrutura.Seguranca.Models {
  public class LoginRequest
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("senha")]
        public string Senha { get; set; }

        
    }
 }