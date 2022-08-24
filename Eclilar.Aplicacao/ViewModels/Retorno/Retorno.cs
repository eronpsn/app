namespace Eclilar.Aplicacao.ViewModels.Retorno
{
    public class Retorno
    {
        public Retorno()
        {

        }
        public Retorno(string mensagem)
        {
            this.Mensagem = mensagem;

        }
        public string Mensagem { get; set; }
    }
}