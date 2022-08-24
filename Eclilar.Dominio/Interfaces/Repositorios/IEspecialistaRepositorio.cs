using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;

namespace Eclilar.Dominio.Interfaces.Repositorios
{
    public interface IEspecialistaRepositorio
    {
           Task<IEnumerable<Especialista>> Buscar();
    }
}