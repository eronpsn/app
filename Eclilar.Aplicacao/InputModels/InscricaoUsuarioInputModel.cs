using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class InscricaoUsuarioInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DataNasc { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}