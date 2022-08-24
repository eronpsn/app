using System.Text.Json.Serialization;

namespace Eclilar.Aplicacao.ViewModels.Especialista
{
    public class EspecialistaView
    {
         [JsonPropertyName("specialty_id")]
        public string SpecialtyId { get; private set; }

        [JsonPropertyName("specialty_name")]
        public string SpecialtyName { get; private set; }

        [JsonPropertyName("specialty_image")]
        public string SpecialtyImage { get; private set; }

        [JsonPropertyName("specialty_category")]
        public string SpecialtyCategory { get; private set; }
    }
}