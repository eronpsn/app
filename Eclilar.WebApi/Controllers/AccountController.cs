using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Eclilar.WebApi.Infrastructure;
using Eclilar.WebApi.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Eclilar.Dominio.Entidades;
using Eclilar.Infraestrutura.Seguranca.Models;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Aplicacao.ViewModels.Login.Profissional;
using System.Text;
using RabbitMQ.Client;

namespace Eclilar.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/acesso")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public AccountController(ILogger<AccountController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }
        [AllowAnonymous]
        [HttpPost("inscricao/usuario")]
        public async Task<ActionResult<LoginResultModel>> InscricaoUsuario([FromBody] InscricaoUsuarioInputModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var usuario = await _userService.InscricaoUsuario(request);
            if (usuario is null)
            {
                return NotFound(new LoginResultModel
                {
                    Result = "0",
                    Message = "Dados inválidos. Tente novamente"
                });
            }

            var role = "Usuario";
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserEmail),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserEmail, claims, DateTime.Now);
            _logger.LogInformation($"Usuário [{request.UserEmail}] logado.");
            return Ok(new LoginResultModel
            {
                Result = "1",
                Message = "Logado com Sucesso!!",
                Details = new UsuarioModel
                {
                    UserId = usuario.UserId.ToString(),
                    UserName = usuario.UserName,
                    UserEmail = usuario.UserEmail,
                    UserPhone = usuario.UserPhone,
                    UserImage = usuario.UserImage,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                }

            });
        }

        [AllowAnonymous]
        [HttpPost("autenticar/usuario")]
        public async Task<ActionResult<LoginResultModel>> LoginUsuario([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = await _userService.LoginUsuario(request);
            if (usuario is null)
            {
                return NotFound(new LoginResultModel
                {
                    Result = "0",
                    Message = "Dados inválidos. Tente novamente"
                });
            }

            var role = "Usuario";
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);
            _logger.LogInformation($"Usuário [{request.Email}] logado.");
            return Ok(new LoginResultModel
            {
                Result = "1",
                Message = "Logado com Sucesso!!",
                Details = new UsuarioModel
                {
                    UserId = usuario.UserId.ToString(),
                    UserName = usuario.UserName,
                    UserEmail = usuario.UserEmail,
                    UserPhone = usuario.UserPhone,
                    UserImage = usuario.UserImage,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                }

            });
        }

        [AllowAnonymous]
        [HttpPost("autenticar/profissional")]
        public async Task<ActionResult<LoginProfissionalResultView>> LoginProfissional([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usuario = await _userService.LoginProfissional(request);
            if (usuario is null)
            {
                return NotFound(new LoginProfissionalResultView
                {
                    Result = "0",
                    Message = "Dados inválidos. Tente novamente"
                });
            }

            var role = "Profissional";
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);
            _logger.LogInformation($"Profissional [{request.Email}] logado.");
            return Ok(new LoginProfissionalResultView
            {
                Result = "1",
                Message = "Logado com Sucesso!!",
                Details = new LoginProfissionalView
                {
                    ProfessionalId = usuario.ProfessionalId.ToString(),
                    ProfessionalName = usuario.ProfessionalName,
                    ProfessionalEmail = usuario.ProfessionalEmail,
                    ProfessionalImage = usuario.ProfessionalImage,
                    Rating = usuario.Rating,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                }

            });
        }

        [AllowAnonymous]
        [HttpPost("inscricao/profissional")]
        public async Task<ActionResult<LoginProfissionalResultView>> InscricaoProfissional([FromBody] InscricaoProfissionalInputModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var usuario = await _userService.InscricaoProfissional(request);
            if (usuario is null)
            {
                return NotFound(new LoginResultModel
                {
                    Result = "0",
                    Message = "Dados inválidos. Tente novamente"
                });
            }

            var role = "Usuario";
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserEmail),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserEmail, claims, DateTime.Now);
            _logger.LogInformation($"Usuário [{request.UserEmail}] logado.");
            return Ok(new LoginProfissionalResultView
            {
                Result = "1",
                Message = "Logado com Sucesso!!",
               Details = new LoginProfissionalView
                {
                    ProfessionalId = usuario.ProfessionalId.ToString(),
                    ProfessionalName = usuario.ProfessionalName,
                    ProfessionalEmail = usuario.ProfessionalEmail,
                    ProfessionalImage = usuario.ProfessionalImage,
                    Rating = usuario.Rating,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                }

            });
        }

        [AllowAnonymous]
        [HttpPost("autenticar/msg")]
        public IActionResult EnviarMsg()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "192.168.0.8" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "eronpsn@gmail.com",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "eronpsn@gmail.com",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);

                    return Accepted();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Erro:", ex.Message);
                return new StatusCodeResult(500);
            }
        }

    }


}
