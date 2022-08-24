using System;

namespace Eclilar.Dominio.Entidades {
    public class Usuario {
        
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }    
        public string UserImage { get; set; }
        public DateTime DataNasc {get; set;}
        public string UserPassword { get; set; }
        public string RegisterDate {get; set;}
        public DateTime UserSignupDate {get; set;}

        public Usuario(int userId, string userName,  string userEmail, string userPhone, string userImage, DateTime dataNasc,  string userPassword, string registerDate, DateTime userSignupDate) {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            UserPhone = userPhone;
            UserImage = userImage;
            DataNasc = dataNasc;
            UserPassword = userPassword;
            RegisterDate = registerDate;
            UserSignupDate = userSignupDate;
        }

        public Usuario()
        {
        }
    }
}