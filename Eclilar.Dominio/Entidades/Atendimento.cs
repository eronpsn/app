using System;

namespace Eclilar.Dominio.Entidades
{
    public class Atendimento
    {
        public int AtendimentosId { get; set; }  
        public int UserId { get; set; }
        public string CouponCode { get; set; }
        public string AddressLat { get; set; }
        public string AddressLong { get; set; }
        public string AddressLocation { get; set; }
        public int ProfessionalId { get; set; }
        public int CityId { get; set; }
        public int SpecialtyId { get; set; }
        public int CategoryId { get; set; }
        public int AtendimentoStatus { get; set; }
        public int PaymentStatus { get; set; }
        public int PaymentOptionId { get; set; }
        public int CardId { get; set; }
        public int AtendimentoPlatform { get; set; }
        public int SolicitacaoAdminStatus { get; set; }
        public DateTime Date { get; set; }
        public string AtendimentoData { get; set; }
        public string AtendimentoHora { get; set; }
        public string LastTimeStamp { get; set; }
        public string LaterDate { get; set; }
        public string LaterTime { get; set; }
        public string ValorConsulta { get; set; }
        public string Sintomas { get; set; }
        public string MotivoCancelamento { get; set; }
        public string ObservacaoAtendimento {get; set;}
         public Atendimento(){
             
         }
       public Atendimento(int atendimentosId, int userId, string couponCode, string addressLat, string addressLong, string addressLocation, int professionalId, int cityId, int specialtyId, int categoryId, int atendimentoStatus, int paymentStatus, int paymentOptionId, int cardId, int atendimentoPlatform, int solicitacaoAdminStatus, DateTime date, string atendimentoData, string atendimentoHora,string lastTimeStamp, string laterDate, string laterTime, string valorConsulta, string sintomas, string motivoCancelamento, string observacaoAtendimento)
        {
            AtendimentosId = atendimentosId;
            UserId = userId;
            CouponCode = couponCode;
            AddressLat = addressLat;
            AddressLong = addressLong;
            AddressLocation = addressLocation;
            ProfessionalId = professionalId;
            CityId = cityId;
            SpecialtyId = specialtyId;
            CategoryId = categoryId;
            AtendimentoStatus = atendimentoStatus;
            PaymentStatus = paymentStatus;
            PaymentOptionId = paymentOptionId;
            CardId = cardId;
            AtendimentoPlatform = atendimentoPlatform;
            SolicitacaoAdminStatus = solicitacaoAdminStatus;
            Date = date;
            AtendimentoData = atendimentoData;
            AtendimentoHora = atendimentoHora;
            LastTimeStamp = lastTimeStamp;
            LaterDate = laterDate;
            LaterTime = laterTime;
            ValorConsulta = valorConsulta;
            Sintomas = sintomas;
            MotivoCancelamento = motivoCancelamento;
            ObservacaoAtendimento = observacaoAtendimento;

        }
    }
}