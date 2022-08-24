using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class BuscaAtendimentoInputModel
    {
        [Required]
        public int AtendimentosId { get; set; }
    }
}