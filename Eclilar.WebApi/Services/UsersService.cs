using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.Dominio.Entidades;
using Eclilar.WebApi.Interfaces;
using Eclilar.WebApi.Validadores;
using Eclilar.Infraestrutura.Seguranca.Models;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Dominio.Compartilhado.Utilitarios;

namespace Eclilar.WebApi.Services
{

    public class UserService : BaseService, IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUsuarioRepositorio _usuarioRepositorio;


        // inject your database here for user validation
        public UserService(ILogger<UserService> logger, IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> InscricaoUsuario(InscricaoUsuarioInputModel user)
        {
            _logger.LogInformation($"Nova inscrição");
            var usuario = new Usuario
            {
                UserName = user.FirstName + " " + user.LastName,
                UserPhone = user.Phone,
                DataNasc = Convert.ToDateTime(user.DataNasc), //DateTime.ParseExact( user.DataNasc, "YYYY-MM-dd", null),
                UserPassword = user.Password,
                RegisterDate = DataHora.ObterDataHoraAtual().ToString("dddd, dd MMMM yyyy"),
                UserEmail = user.UserEmail,
                UserSignupDate = DataHora.ObterDataHoraAtual(),
                UserImage = "default.jpeg"

            };
            var retorno = await _usuarioRepositorio.InscricaoUsuario(usuario);
            return retorno;
        }

        public async Task<Usuario> LoginUsuario(LoginRequest loginRequest)
        {
            _logger.LogInformation($"Verificando o usuário  [{loginRequest.Email}]");
            Validate(new LoginValidador(), loginRequest);

            var usuario = await _usuarioRepositorio.LoginUsuario(loginRequest.Email, loginRequest.Senha);
            return usuario;
        }

        public async Task<ProfissionalModel> LoginProfissional(LoginRequest loginRequest)
        {
            _logger.LogInformation($"Verificando o profissional  [{loginRequest.Email}]");
            Validate(new LoginValidador(), loginRequest);

            return await _usuarioRepositorio.LoginProfissional(loginRequest.Email, loginRequest.Senha);

        }
        public async Task<ProfissionalModel> InscricaoProfissional(InscricaoProfissionalInputModel user)
        {
            _logger.LogInformation($"Nova inscrição de profissional [{user.UserEmail}]");
            var usuario = new ProfissionalModel
            {
                ProfessionalName = user.FirstName + " " + user.LastName,
                ProfessionalPhone = user.Phone,
                ProfessionalPassword = user.Password,
                RegisterDate = DataHora.ObterDataHoraAtual().ToString("dddd, dd MMMM yyyy"),
                ProfessionalEmail = user.UserEmail,
                ProfessionalSignupDate = DataHora.ObterDataHoraAtual(),
                ProfessionalImage = "default.jpeg",
                Rating = "5",
                ProfessionalExperience = "-",
                ProfessionalFormation = "-",
                ProfessionalValueVisit = "100,00"               


            };
            var retorno = await _usuarioRepositorio.InscricaoProfissional(usuario);
            int professionalId = retorno.ProfessionalId;
            if (professionalId > 0)
            {
                string[] especialidades = user.specialty.Split("#");
                string[] categoria;
                for (int i = 0; i < especialidades.Length; i++)
                {
                    if (especialidades[i] != "")
                    {
                        categoria = especialidades[i].Split("-"); //posição 0 => Especialização, 1=> categoria da especialização

                        var esp = new ProfissionalEspecializacao
                        {
                            IdProfessionalId = professionalId,
                            IdSpecialtyId = int.Parse(categoria[0].ToString())
                        };

                        await _usuarioRepositorio.SalvaEspecializacao(esp);
                    }

                }
            }
            return retorno;
        }

    }


}
