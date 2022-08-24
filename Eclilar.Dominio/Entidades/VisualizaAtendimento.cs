using System;
namespace Eclilar.Dominio.Entidades
{
    public class VisualizaAtendimento
    {
        public int AtendimentosId { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
        public string AddressLat { get; set; }
        public string AddressLong { get; set; }
        public string AddressLocation { get; set; }
        public string AtendimentoData { get; set; }
        public string AtendimentoHora { get; set; }
        public string LastTimeStamp { get; set; }
        public string LaterDate { get; set; }
        public string LaterTime { get; set; }
        public int ProfessionalId { get; set; }
        public int CityId { get; set; }
        public int SpecialtyId { get; set; }
        public int CategoryId { get; set; }
        public int PemFile { get; set; }
        public int AtendimentoStatus { get; set; }
        public int PaymentStatus { get; set; }
        public int ReasonId { get; set; }
        public int PaymentOptionId { get; set; }
        public int CardId { get; set; }
        public int AtendimentoPlatform { get; set; }
        public int SolicitacaoAdminStatus { get; set; }
        public DateTime Date { get; set; }
        public string ProfessionalName { get; set; }
        public string ProfessionalDescription { get; set; }
        public string ProfessionalImage { get; set; }
        public string ValorConsulta { get; set; }
        public string Sintomas { get; set; }
        public DateTime Data { get; set; }
       public string MotivoCancelamento { get; set; }
    }
}