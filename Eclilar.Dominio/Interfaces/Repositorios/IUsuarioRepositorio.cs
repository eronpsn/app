using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.ObjetosValor;

namespace Eclilar.Dominio.Interfaces.Repositorios {
    public interface IUsuarioRepositorio {
        Task<Usuario> InscricaoUsuario(Usuario user);
        Task<Usuario> LoginUsuario(String  email, String senha);
        Task<ProfissionalModel> LoginProfissional(String  email, String senha);

        Task<ProfissionalModel> InscricaoProfissional(ProfissionalModel user);
        Task<int> SalvaEspecializacao(ProfissionalEspecializacao dados);

       
    }
}
