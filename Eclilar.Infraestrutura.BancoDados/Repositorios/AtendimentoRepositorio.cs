using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Entidades.Profissional;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.Dominio.QueryParams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eclilar.Infraestrutura.BancoDados.Repositorios
{
    public class AtendimentoRepositorio : IAtendimentoRepositorio
    {

        private readonly ContextoBanco _contextoBanco;
        private readonly ILogger<AtendimentoRepositorio> _logger;

        public AtendimentoRepositorio(ContextoBanco contextoBanco, ILogger<AtendimentoRepositorio> logger)
        {
            _contextoBanco = contextoBanco;
            _logger = logger;
        }

        public async Task<IEnumerable<VisualizaAtendimento>> BuscaAtendimentos(int idtUser)
        {
            string sql = string.Format(@"select  date_format(str_to_date(a.atendimento_data, '%d/%m/%Y'), '%Y-%m-%d') as data,  a.*, p.professional_name,  s.specialty_name as professional_description, p.professional_image 
                                        from atendimentos a inner join professional p on(p.professional_id = a.professional_id)
                                        inner join specialty s ON(s.specialty_id = a.specialty_id) 
                                         where user_id = {0} ", idtUser);
            return await _contextoBanco.TVisuAtendimento.FromSqlRaw(sql)
                    .OrderBy(a => a.Data)
                    .ToListAsync();
        }

        public async Task<Atendimento> NovaSolicitacao(Atendimento request)
        {
            await _contextoBanco.TSolicitacao.AddAsync(request);
            await _contextoBanco.SaveChangesAsync();
            _logger.LogInformation($"Nova solicitacao: AtendimentoId  [{request.AtendimentosId}]");
            return await BuscaAtendimentoId(request.AtendimentosId);
        }
        public async Task<Atendimento> BuscaAtendimentoId(int idt)
        {
           return await _contextoBanco.TSolicitacao.
                Where(a => a.AtendimentosId == idt).
                OrderByDescending(a => a.Date).
                FirstOrDefaultAsync();         
        }

        public async Task<Atendimento> AlteraSolicitacao(Atendimento request)
        {
             _contextoBanco.TSolicitacao.Update(request);
            await _contextoBanco.SaveChangesAsync();
            _logger.LogInformation($"Update atendimentoId  [{request.AtendimentosId}]");
            return await BuscaAtendimentoId(request.AtendimentosId);
        }

      public async Task<IEnumerable<Agenda>> AgendaProfissional(int profissionalId)
        {
            string sql = string.Format(@"select  date_format(str_to_date(a.atendimento_data, '%d/%m/%Y'), '%Y-%m-%d') as atendimento_data, u.user_name,  u.user_image, (select admin_panel_min_attendance from admin_panel_settings) as min_atendimento, atendimentos_id, a.atendimento_status, a.atendimento_hora, a.address_location from atendimentos a inner join user u on(u.user_id = a.user_id) where a.professional_id = {0}  order by atendimento_data ", profissionalId);
            return await _contextoBanco.TAgenda.FromSqlRaw(sql)
                    .OrderBy(a => a.AtendimentoData)
                    .ToListAsync();
        }

    }
}