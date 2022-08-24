using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Eclilar.Dominio.Interfaces.Repositorios;
using Eclilar.Infraestrutura.BancoDados;
using Eclilar.Infraestrutura.BancoDados.Repositorios;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace Eclilar.InjecaoDependencia.Infraestrutura.BancoDados
{
    public static class InjetarDependenciaBanco
    {

        public static IServiceCollection AddDependenciasBanco(this IServiceCollection serviceCollection,
            IConfiguration Configuration)
        {
            IConfigurationRoot _configuration = new ConfigurationBuilder()
     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
     .AddJsonFile("appsettings.json")
     .Build();
            var user = _configuration.GetValue<string>("Modules:Logging:user");
            var password = _configuration.GetValue<string>("Modules:Logging:pass");
            var server = _configuration.GetValue<string>("Modules:Servidor:producao");
            var banco = _configuration.GetValue<string>("Modules:Servidor:banco");
            //server=localhost;database=library;user=mysqlschema;password=mypassword
            var connectionString = "server=" + server + ";database=" + banco + ";user=" + user + ";Password=" + password+";Convert Zero Datetime=True;sslMode=None;";

            serviceCollection.AddDbContext<ContextoBanco>(options
                => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            serviceCollection.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            serviceCollection.AddScoped<IEspecialistaRepositorio, EspecialistaRepositorio>();
            serviceCollection.AddScoped<IProfissionalRepositorio, ProfissionalRepositorio>();
            serviceCollection.AddScoped<IAtendimentoRepositorio, AtendimentoRepositorio>();
            return serviceCollection;
        }
    }
}
