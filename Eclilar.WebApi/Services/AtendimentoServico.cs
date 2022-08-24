using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Dominio.Compartilhado.Utilitarios;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Entidades.Profissional;
using Eclilar.Dominio.Entidades.Rabbit;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.WebApi.Interfaces;
using Microsoft.Extensions.Logging;

namespace Eclilar.WebApi.Services
{
    public class AtendimentoServico : BaseService, IAtendimentoServico
    {
        private readonly ILogger<IAtendimentoServico> _logger;
        private readonly IAtendimentoRepositorio _atendRepositorio;
        private readonly IRabbitMqServico _rabbit;


        // inject your database here for user validation
        public AtendimentoServico(ILogger<IAtendimentoServico> logger, IAtendimentoRepositorio atendRepositorio, IRabbitMqServico rabbit)
        {
            _logger = logger;
            _atendRepositorio = atendRepositorio;
            _rabbit = rabbit;
        }

        public async Task<IEnumerable<VisualizaAtendimento>> BuscaAtendimentos(int idtUser)
        {
            _logger.LogInformation($"Buscando todos os atendimentos ");

            var dados = await _atendRepositorio.BuscaAtendimentos(idtUser);
            return dados;
        }

        public async Task<Atendimento> NovaSolicitacao(NovaSolicitacaoInputModel request)
        {
            _logger.LogInformation($"Nova solicitação ");
            var solicitacao = new Atendimento
            {
                UserId = Convert.ToInt32(request.UserId),
                CouponCode = request.CouponCode,
                AddressLat = request.AddressLat,
                AddressLong = request.AddressLong,
                AddressLocation = request.AddressLocation,
                ProfessionalId = Convert.ToInt32(request.ProfessionalId),
                CityId = 1,
                SpecialtyId = Convert.ToInt32(request.SpecialtyId),
                CategoryId = Convert.ToInt32(request.CategoryId),
                AtendimentoStatus = 1,
                PaymentStatus = 1,
                PaymentOptionId = Convert.ToInt32(request.PaymentOptionId),
                CardId = Convert.ToInt32(request.CardId),
                AtendimentoPlatform = 1,
                SolicitacaoAdminStatus = 1,
                Date = DataHora.ObterDataHoraAtual(),
                AtendimentoData = request.AtendimentoData,
                LastTimeStamp = DataHora.ObterDataHoraAtual().ToString("HH:mm:ss"),
                LaterDate = DataHora.ObterDataHoraAtual().ToString("dddd, dd MMMM yyyy"),
                LaterTime = DataHora.ObterDataHoraAtual().ToString("HH:mm:ss"),
                ValorConsulta = request.ValorConsulta,
                Sintomas = request.Sintomas,
            };
            var retorno = await _atendRepositorio.NovaSolicitacao(solicitacao);
            var fila = new QueueDeclare
            {
                Queue = request.ProfessionalEmail+"_p"
            };
            _rabbit.CriaFila(fila);
            var notificacao = new Notificacao
            {
                RoutingKey = request.ProfessionalEmail+"_p",
                Message = "#1#"

            };
            _rabbit.EnviaNotificacao(notificacao);
            return retorno;

        }
        public async Task<Atendimento> CancelaSolicitacao(CancelaSolicitacaoInputModel request, int statusAtendimento)
        {
            _logger.LogInformation($"Cancela solicitação ");

            var solBanco = await _atendRepositorio.BuscaAtendimentoId(request.AtendimentosId);
            var solicitacao = new Atendimento
            {
                AtendimentosId = request.AtendimentosId,
                UserId = solBanco.UserId,
                CouponCode = solBanco.CouponCode,
                AddressLat = solBanco.AddressLat,
                AddressLong = solBanco.AddressLong,
                AddressLocation = solBanco.AddressLocation,
                ProfessionalId = solBanco.ProfessionalId,
                CityId = solBanco.CityId,
                SpecialtyId = solBanco.SpecialtyId,
                CategoryId = solBanco.CategoryId,
                AtendimentoStatus = statusAtendimento,
                PaymentStatus = solBanco.PaymentStatus,
                PaymentOptionId = solBanco.PaymentOptionId,
                CardId = solBanco.CardId,
                AtendimentoPlatform = solBanco.AtendimentoPlatform,
                SolicitacaoAdminStatus = solBanco.SolicitacaoAdminStatus,
                Date = solBanco.Date,
                AtendimentoData = solBanco.AtendimentoData,
                LastTimeStamp = solBanco.LastTimeStamp,
                LaterDate = solBanco.LaterDate,
                LaterTime = solBanco.LaterTime,
                ValorConsulta = solBanco.ValorConsulta,
                Sintomas = solBanco.Sintomas,
                MotivoCancelamento = request.Motivo

            };
            var retorno = await _atendRepositorio.AlteraSolicitacao(solicitacao);
            return retorno;

        }
        public async Task<Atendimento> ConfirmaSolicitacao(ConfirmaSolicitacaoInputModel request)
        {
            _logger.LogInformation($"Confirma solicitação ");

            var solBanco = await _atendRepositorio.BuscaAtendimentoId(request.AtendimentosId);
            var solicitacao = new Atendimento
            {
                AtendimentosId = request.AtendimentosId,
                UserId = solBanco.UserId,
                CouponCode = solBanco.CouponCode,
                AddressLat = solBanco.AddressLat,
                AddressLong = solBanco.AddressLong,
                AddressLocation = solBanco.AddressLocation,
                ProfessionalId = request.ProfessionalId,
                CityId = solBanco.CityId,
                SpecialtyId = solBanco.SpecialtyId,
                CategoryId = solBanco.CategoryId,
                AtendimentoStatus = 2,
                PaymentStatus = solBanco.PaymentStatus,
                PaymentOptionId = solBanco.PaymentOptionId,
                CardId = solBanco.CardId,
                AtendimentoPlatform = solBanco.AtendimentoPlatform,
                SolicitacaoAdminStatus = solBanco.SolicitacaoAdminStatus,
                Date = solBanco.Date,
                AtendimentoData = solBanco.AtendimentoData,
                AtendimentoHora = request.AtendimentoHora,
                LastTimeStamp = solBanco.LastTimeStamp,
                LaterDate = solBanco.LaterDate,
                LaterTime = solBanco.LaterTime,
                ValorConsulta = solBanco.ValorConsulta,
                Sintomas = solBanco.Sintomas,
                MotivoCancelamento = solBanco.MotivoCancelamento

            };
            var retorno = await _atendRepositorio.AlteraSolicitacao(solicitacao);
            return retorno;

        }

        public async Task<Atendimento> FinalizaSolicitacao(FinalizaSolicitacaoInputModel request)
        {
            _logger.LogInformation($"Finaliza solicitação ");

            var solBanco = await _atendRepositorio.BuscaAtendimentoId(request.AtendimentosId);
            var solicitacao = new Atendimento
            {
                AtendimentosId = request.AtendimentosId,
                UserId = solBanco.UserId,
                CouponCode = solBanco.CouponCode,
                AddressLat = solBanco.AddressLat,
                AddressLong = solBanco.AddressLong,
                AddressLocation = solBanco.AddressLocation,
                ProfessionalId = request.ProfessionalId,
                CityId = solBanco.CityId,
                SpecialtyId = solBanco.SpecialtyId,
                CategoryId = solBanco.CategoryId,
                AtendimentoStatus = 3,
                PaymentStatus = solBanco.PaymentStatus,
                PaymentOptionId = solBanco.PaymentOptionId,
                CardId = solBanco.CardId,
                AtendimentoPlatform = solBanco.AtendimentoPlatform,
                SolicitacaoAdminStatus = solBanco.SolicitacaoAdminStatus,
                Date = solBanco.Date,
                AtendimentoData = solBanco.AtendimentoData,
                AtendimentoHora = solBanco.AtendimentoHora,
                LastTimeStamp = solBanco.LastTimeStamp,
                LaterDate = solBanco.LaterDate,
                LaterTime = solBanco.LaterTime,
                ValorConsulta = solBanco.ValorConsulta,
                Sintomas = solBanco.Sintomas,
                MotivoCancelamento = solBanco.MotivoCancelamento,
                ObservacaoAtendimento = request.ObservacaoAtendimento

            };
            var retorno = await _atendRepositorio.AlteraSolicitacao(solicitacao);
            return retorno;

        }
        public async Task<IEnumerable<Agenda>> AgendaProfissional(int profissionalId)
        {

            return await _atendRepositorio.AgendaProfissional(profissionalId);
        }

        public async Task<Atendimento> BuscaAtendimentoId(int atendimentosId)
        {
            return await _atendRepositorio.BuscaAtendimentoId(atendimentosId);
        }
    }
}