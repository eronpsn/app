using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Eclilar.Infraestrutura.BancoDados.Repositorios
{
    public class EspecialistaRepositorio: IEspecialistaRepositorio
    {

        private readonly ContextoBanco _contextoBanco;
        
        public EspecialistaRepositorio(ContextoBanco contextoBanco)
        {
            _contextoBanco = contextoBanco;
        }
        public async Task<IEnumerable<Especialista>> Buscar()
        {
            return await _contextoBanco.TEspecialista
                .Where(e => e.SpecialtyStatus == 1)
                .OrderBy(e => e.SpecialtyName)
                .ToListAsync();
        }
    }
}