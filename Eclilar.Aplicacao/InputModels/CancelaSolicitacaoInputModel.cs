using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class CancelaSolicitacaoInputModel
    {
        [Required]
        public int Id {get;set;}

        [Required]
         public int AtendimentosId {get;set;}

         [Required]
         public string Motivo {get;set;}

    }
}