using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Dominio.Entidades;

namespace Eclilar.WebApi.Interfaces
{
    public interface IProfissionalServico
    {
        Task<IEnumerable<ProfissionalModel>> BuscaTodos();

        Task<IEnumerable<Categoria>> BuscaCategoria(int specialtyId);

        Task<IEnumerable<ProfissionalModel>> ProcuraProfissional(BuscaProfissionalInputModel request);
    }
}