using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class FinalizaSolicitacaoInputModel
    {
        [Required]
        public int ProfessionalId { get; set; }

        [Required]
        public int AtendimentosId { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string ObservacaoAtendimento { get; set; }
    }
}