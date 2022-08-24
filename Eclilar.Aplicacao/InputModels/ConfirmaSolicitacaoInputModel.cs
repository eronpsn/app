using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class ConfirmaSolicitacaoInputModel
    {
         [Required]
        public int ProfessionalId {get;set;}

        [Required]
         public int AtendimentosId {get;set;}

         [Required]
         public string AtendimentoHora {get;set;}
    }
}