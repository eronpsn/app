using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Dominio.Entidades;
using Eclilar.Infraestrutura.Seguranca.Models;

namespace Eclilar.WebApi.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> InscricaoUsuario(InscricaoUsuarioInputModel user);
        Task<Usuario> LoginUsuario(LoginRequest loginRequest);
        Task<ProfissionalModel> LoginProfissional(LoginRequest loginRequest);
         Task<ProfissionalModel> InscricaoProfissional(InscricaoProfissionalInputModel user);
    }
}