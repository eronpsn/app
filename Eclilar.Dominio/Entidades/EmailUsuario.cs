namespace Eclilar.Dominio.Entidades {
    public class EmailUsuarioModel {
        
        public int UserId { get; set; }       
        public string UserEmail { get; set; }

        public EmailUsuarioModel(int userId,  string userEmail) {
            UserId = userId;         
            UserEmail = userEmail;
        }

        public EmailUsuarioModel()
        {
        }
    }
}