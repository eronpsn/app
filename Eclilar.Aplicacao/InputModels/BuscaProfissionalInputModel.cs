using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class BuscaProfissionalInputModel
    {
         [Required]
        public string SpecialtyId { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

         [Required]
        public string Cidade { get; set; }
    }
}