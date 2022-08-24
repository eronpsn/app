using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eclilar.WebApi.Interfaces;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.WebApi.Services;

namespace Eclilar.WebApi.Servicos
{
    public class EspecialistaServico : BaseService, IEspecialistaServico
    {
        private readonly IEspecialistaRepositorio _especialistaRepositorio;
        public EspecialistaServico(IEspecialistaRepositorio especialistaRepositorio)
        {
            _especialistaRepositorio = especialistaRepositorio;

        }

        public async Task<IEnumerable<Especialista>> Buscar()
        {
            var dados = await _especialistaRepositorio.Buscar();
            return dados;
        }

    }
}