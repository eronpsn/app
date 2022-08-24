using System.Threading.Tasks;
using Eclilar.Aplicacao.ViewModels.Especialista;
using Eclilar.Dominio.Entidades;
using Eclilar.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eclilar.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/especialista")]
    public class EspecialistaController : ControllerBase
    {
        private readonly IEspecialistaServico _especialista;
        public EspecialistaController(IEspecialistaServico especialista)
        {
            _especialista = especialista;
        }
        [HttpGet("buscar")]
        [Authorize]
        public async Task<ActionResult<EspecialistaView>> Buscar()
        {

            var dados = await _especialista.Buscar();
            return Ok(dados);

        }

        [HttpGet("todas-especialidades")]
        [AllowAnonymous]
        public async Task<ActionResult<EspecialistaView>> TodasEspecialidades()
        {

            var dados = await _especialista.Buscar();
            return Ok(dados);

        }
    }
}