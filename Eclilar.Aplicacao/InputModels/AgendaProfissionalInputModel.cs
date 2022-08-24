using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class AgendaProfissionalInputModel
    {
        [Required]
        public int ProfissionalId { get; set; }
    }
}