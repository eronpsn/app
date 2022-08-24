using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Entidades.Profissional;
using Eclilar.Dominio.QueryParams;

namespace Eclilar.Dominio.Interfaces.Repositorios
{
    public interface IAtendimentoRepositorio
    {
        Task<IEnumerable<VisualizaAtendimento>> BuscaAtendimentos(int idtUser);
        Task<Atendimento> NovaSolicitacao(Atendimento request);
        Task<Atendimento> BuscaAtendimentoId(int idt);
        Task<Atendimento> AlteraSolicitacao(Atendimento request);
        Task<IEnumerable<Agenda>> AgendaProfissional(int profissionalId);


    }
}