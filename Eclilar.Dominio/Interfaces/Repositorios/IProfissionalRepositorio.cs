using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;

namespace Eclilar.Dominio.Interfaces.Repositorios
{
    public interface IProfissionalRepositorio
    {
         Task<IEnumerable<ProfissionalModel>> BuscaTodos();
         Task<IEnumerable<Categoria>> BuscaCategoria(int specialtyId);
         Task<IEnumerable<ProfissionalModel>> ProcuraProfissional(string specialtyId);
        
    }
}