using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Entidades.Profissional;

namespace Eclilar.WebApi.Interfaces
{
    public interface IAtendimentoServico
    {
        Task<IEnumerable<VisualizaAtendimento>> BuscaAtendimentos(int idtUser);
        Task<Atendimento> NovaSolicitacao(NovaSolicitacaoInputModel request);
        Task<Atendimento> CancelaSolicitacao(CancelaSolicitacaoInputModel request, int statusAtendimento);
        Task<Atendimento> ConfirmaSolicitacao(ConfirmaSolicitacaoInputModel request);
        Task<Atendimento> FinalizaSolicitacao(FinalizaSolicitacaoInputModel request);
        Task<IEnumerable<Agenda>> AgendaProfissional(int profissionalId);
        Task<Atendimento> BuscaAtendimentoId(int atendimentosId);
    }
}