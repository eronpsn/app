using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Aplicacao.ViewModels.Agenda;
using Eclilar.Aplicacao.ViewModels.Retorno;
using Eclilar.Dominio.Compartilhado.Utilitarios;
using Eclilar.Dominio.Entidades;
using Eclilar.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eclilar.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/atendimento")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoServico _atenServico;
        public AtendimentoController(IAtendimentoServico atenServico)
        {
            _atenServico = atenServico;
        }

        [HttpGet("buscar/atendimentos/{UserId}")]
        [Authorize]
        public async Task<ActionResult<VisualizaAtendimento>> BuscaTodos([FromRoute] VisualizaAtendimentoInputModel request)
        {
            var dados = await _atenServico.BuscaAtendimentos(request.UserId);
            return Ok(dados);

        }

        [HttpPost("nova-solicitacao")]
        [Authorize]
        public async Task<ActionResult<Atendimento>> NovaSolicitacao(
            [FromBody] NovaSolicitacaoInputModel request)
        {
            var dados = await _atenServico.NovaSolicitacao(request);
            return Ok(dados);

        }

        [HttpPost("cancela-solicitacao-usuario")]
        [Authorize]
        public async Task<ActionResult<Atendimento>> CancelaSolicitacaoUsuario(
            [FromBody] CancelaSolicitacaoInputModel request)
        {
            var dados = await _atenServico.CancelaSolicitacao(request, Constantes.StatusCancelamentoUsuario);
            if (dados == null)
            {
                var r = new Retorno
                {
                    Mensagem = "Algo errado, tente novamente."
                };
                return StatusCode(500, r);
            }
            var retorno = new Retorno
            {
                Mensagem = "Atendimento cancelado."
            };
            return StatusCode(200, retorno);

        }

        [HttpPost("confirma-solicitacao")]
        [Authorize]
        public async Task<ActionResult<Atendimento>> ConfirmaSolicitacao(
            [FromBody] ConfirmaSolicitacaoInputModel request)
        {
            var dados = await _atenServico.ConfirmaSolicitacao(request);
            if (dados == null)
            {
                var r = new Retorno
                {
                    Mensagem = "Algo errado, tente novamente."
                };
                return StatusCode(500, r);
            }
            var retorno = new Retorno
            {
                Mensagem = "Atendimento confirmado."
            };
            return StatusCode(200, retorno);

        }

        [HttpPost("finaliza-solicitacao")]
        [Authorize]
        public async Task<ActionResult<Atendimento>> FinalizaSolicitacao(
            [FromBody] FinalizaSolicitacaoInputModel request)
        {
            var dados = await _atenServico.FinalizaSolicitacao(request);
            if (dados == null)
            {
                var r = new Retorno
                {
                    Mensagem = "Algo errado, tente novamente."
                };
                return StatusCode(500, r);
            }
            var retorno = new Retorno
            {
                Mensagem = "Atendimento finalizado."
            };
            return StatusCode(200, retorno);

        }
        [HttpPost("cancela-solicitacao-profissional")]
        [Authorize]
        public async Task<ActionResult<Atendimento>> CancelaSolicitacaoProfissional(
           [FromBody] CancelaSolicitacaoInputModel request)
        {
            var dados = await _atenServico.CancelaSolicitacao(request, Constantes.StatusCancelamentoProfissional);
            if (dados == null)
            {
                var r = new Retorno
                {
                    Mensagem = "Algo errado, tente novamente."
                };
                return StatusCode(500, r);
            }
            var retorno = new Retorno
            {
                Mensagem = "Atendimento cancelado."
            };
            return StatusCode(200, retorno);

        }

        [HttpGet("buscar/agenda/{ProfissionalId}")]
        [Authorize]
        public async Task<ActionResult<AgendaView>> AgendaProfissional([FromRoute] AgendaProfissionalInputModel request)
        {
            var dados = await _atenServico.AgendaProfissional(request.ProfissionalId);
            return Ok(dados);

        }

        [HttpGet("buscar/atendimento/{AtendimentosId}")]
        [Authorize]
        public async Task<ActionResult<Atendimento>> BuscaAtendimentoId([FromRoute] BuscaAtendimentoInputModel request)
        {
            var dados = await _atenServico.BuscaAtendimentoId(request.AtendimentosId);
            return Ok(dados);

        }

    }
}