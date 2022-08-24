using System.Collections.Generic;

namespace Eclilar.Aplicacao.ViewModels.Agenda
{
    public class AgendaRetornoView
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public ICollection<AgendaView> Details { get; set; }
    }
}