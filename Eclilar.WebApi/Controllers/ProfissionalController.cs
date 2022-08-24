using System;
using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Aplicacao.ViewModels.Especialista;
using Eclilar.Dominio.Entidades;
using Eclilar.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eclilar.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/profissional")]
    public class ProfissionalController : ControllerBase
    {
        private readonly ILogger<ProfissionalController> _logger;
        private readonly IProfissionalServico _profissionalServico;

        public ProfissionalController(ILogger<ProfissionalController> logger, IProfissionalServico profissionalServico)
        {
            _logger = logger;
            _profissionalServico = profissionalServico;
        }

        [HttpGet("buscar/todos/{Latitude}/{Longitude}/{Cidade}")]
        [Authorize]
        public async Task<ActionResult<ProfissionalModel>> BuscaTodos([FromRoute] BuscaProfissionalInputModel request)
        {
            _logger.LogInformation($"Buscar.");
            var dados = await _profissionalServico.BuscaTodos();
            return Ok(dados);

        }

        [HttpGet("categoria/{SpecialtyId}")]
        [Authorize]
        public async Task<ActionResult<Categoria>> BuscaCategoria([FromRoute] CategoriaInputModel request)
        {
            _logger.LogInformation($"Buscando as categorias.");
            var dados = await _profissionalServico.BuscaCategoria(Convert.ToInt32(request.SpecialtyId));
            return Ok(dados);

        }
        [HttpPost("buscar/profissional")]
        [Authorize]
          public async Task<ActionResult<ProfissionalModel>> ProcuraProfissional(
            [FromBody] BuscaProfissionalInputModel request)
        {
            var dados = await _profissionalServico.ProcuraProfissional(request);
            return Ok(dados);

        }

    }
}