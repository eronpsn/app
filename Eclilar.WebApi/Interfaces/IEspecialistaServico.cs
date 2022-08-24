using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;

namespace Eclilar.WebApi.Interfaces {
    public interface IEspecialistaServico {

        Task<IEnumerable<Especialista>> Buscar();
    }
}
