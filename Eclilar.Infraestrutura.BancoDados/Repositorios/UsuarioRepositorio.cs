using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.Dominio.ObjetosValor;
using Microsoft.Extensions.Logging;

namespace Eclilar.Infraestrutura.BancoDados.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly ContextoBanco _contextoBanco;

        public UsuarioRepositorio(ContextoBanco contextoBanco)
        {
            _contextoBanco = contextoBanco;
        }

        public async Task<Usuario> InscricaoUsuario(Usuario user)
        {
            await _contextoBanco.TUser.AddAsync(user);
            await _contextoBanco.SaveChangesAsync();
            return await LoginUsuario(user.UserEmail, user.UserPassword);
        }

        public async Task<Usuario> LoginUsuario(String email, String senha)
        {

            var aluno = await _contextoBanco.TUser.
                Where(a => a.UserEmail == email && a.UserPassword == senha).
                OrderByDescending(a => a.UserName).
                FirstOrDefaultAsync();

            return aluno;
        }
        public async Task<ProfissionalModel> LoginProfissional(String email, String senha)
        {

            return await _contextoBanco.TProfissional.
                Where(a => a.ProfessionalEmail == email && a.ProfessionalPassword == senha).
                OrderByDescending(a => a.ProfessionalName).
                FirstOrDefaultAsync();

        }
           public async Task<ProfissionalModel> InscricaoProfissional(ProfissionalModel user)
        {
            await _contextoBanco.TProfissional.AddAsync(user);
            await _contextoBanco.SaveChangesAsync();
            return await LoginProfissional(user.ProfessionalEmail, user.ProfessionalPassword);
        }
           public async Task<int> SalvaEspecializacao(ProfissionalEspecializacao dados)
        {
            await _contextoBanco.TProfiEspecializao.AddAsync(dados);
            return await _contextoBanco.SaveChangesAsync();
            
        }
        public async Task<EmailUsuarioModel> EmailUsuario(int userId)
        {
           string sql = string.Format(@"SELECT user_id, user_email
                                        FROM user 
                                        WHERE user_id = {0} ", userId);
            return await _contextoBanco.TEmailUsuario.FromSqlRaw(sql).FirstOrDefaultAsync();
          
        }
    }
}
