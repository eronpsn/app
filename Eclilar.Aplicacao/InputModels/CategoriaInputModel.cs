using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class CategoriaInputModel
    {
        [Required]
        public string SpecialtyId { get; set; }
    }
}