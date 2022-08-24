using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class VisualizaAtendimentoInputModel
    {
         [Required]
        public int UserId {get;set;}
    }
}