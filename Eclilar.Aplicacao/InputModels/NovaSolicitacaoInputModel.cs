using System.ComponentModel.DataAnnotations;

namespace Eclilar.Aplicacao.InputModels
{
    public class NovaSolicitacaoInputModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string CouponCode { get; set; }

        [Required]
        public string AddressLat { get; set; }

        [Required]
        public string AddressLong { get; set; }

        [Required]
        public string AddressLocation { get; set; }

        [Required]
        public string ProfessionalId { get; set; }

        [Required]
        public string SpecialtyId { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string PaymentOptionId { get; set; }

        [Required]
        public string CardId { get; set; }

        [Required]
        public string AtendimentoData { get; set; }

        [Required]
        public string ValorConsulta { get; set; }

        [Required]
        public string Sintomas { get; set; }
        
        [Required]
        public string ProfessionalEmail { get; set; }
    }
}