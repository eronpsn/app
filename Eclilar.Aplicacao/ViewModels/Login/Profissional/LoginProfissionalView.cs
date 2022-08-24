using System.Text.Json.Serialization;

namespace Eclilar.Aplicacao.ViewModels.Login.Profissional
{
    public class LoginProfissionalView
    {
        public string ProfessionalId { get; set; }

        public string ProfessionalName { get; set; }

        public string ProfessionalDescription { get; set; }

        public string ProfessionalEmail { get; set; }       

        public string ProfessionalImage { get; set; }

        public string Rating { get; set; }

        public string VerfiyDocument { get; set; }

        public string ProfessionalStatusMessage { get; set; }
        public string ProfessionalStatusImage { get; set; }
   
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}