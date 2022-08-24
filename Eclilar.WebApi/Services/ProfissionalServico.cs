using System.Collections.Generic;
using System.Threading.Tasks;
using Eclilar.Aplicacao.InputModels;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.WebApi.Interfaces;
using Microsoft.Extensions.Logging;

namespace Eclilar.WebApi.Services
{
    public class ProfissionalServico:BaseService,IProfissionalServico
    {
         private readonly ILogger<IProfissionalServico> _logger;
     private readonly IProfissionalRepositorio _profissionalRepositorio;


        // inject your database here for user validation
        public ProfissionalServico(ILogger<IProfissionalServico> logger, IProfissionalRepositorio profissionalRepositorio)
        {
            _logger = logger;
            _profissionalRepositorio = profissionalRepositorio;
        }
      
        public async Task<IEnumerable<ProfissionalModel>> BuscaTodos()
        {
            _logger.LogInformation($"Buscando todos os profissionais ");
     
            var dados = await _profissionalRepositorio.BuscaTodos();
            return dados;
        }
         public async Task<IEnumerable<Categoria>> BuscaCategoria(int specialtyId)
        {
            _logger.LogInformation($"Buscando as categorias ");
     
            var dados = await _profissionalRepositorio.BuscaCategoria(specialtyId);
            return dados;
        }

        public async Task<IEnumerable<ProfissionalModel>> ProcuraProfissional(BuscaProfissionalInputModel request)
        {
            _logger.LogInformation($"Buscando os profissionais ");
     
            var dados = await _profissionalRepositorio.ProcuraProfissional(request.SpecialtyId);
            return dados;
        }
    }


}
