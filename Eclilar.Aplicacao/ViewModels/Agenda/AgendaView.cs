using System;

namespace Eclilar.Aplicacao.ViewModels.Agenda
{
    public class AgendaView
    {
        public int AtendimentosId { get; set; }
        public DateTime AtendimentoData { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public int MinAtendimento { get; set; }
        public int AtendimentoStatus { get; set; }
        public string atendimentoHora { get; set; }
        public string addressLocation { get; set; }
    }
}