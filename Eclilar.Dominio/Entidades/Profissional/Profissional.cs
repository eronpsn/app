using System;

namespace Eclilar.Dominio.Entidades
{
    public class ProfissionalModel
    {
        public int ProfessionalId { get; set; }
        public string ProfessionalName { get; set; }
        public string ProfessionalEmail {get; set;}
        public string ProfessionalPhone {get; set;}
        public string ProfessionalPassword {get; set;}
        public string ProfessionalDescription { get; set; }
        public string ProfessionalImage { get; set; }
        public string Rating { get; set; }
        public int CompletedAttendance { get; set; }
        public string ProfessionalValueVisit { get; set; }
        public string ProfessionalExperience { get; set; }
        public string ProfessionalFormation { get; set; }       
        public int CityId { get; set; }
        public int ProfessionalAdminStatus { get; set; }
        public string RegisterDate { get; set; }  
        public DateTime ProfessionalSignupDate { get; set; }  
    }
}