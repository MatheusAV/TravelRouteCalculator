using CadastroRotasDomain.Entities;
using CadastroRotasRepository.Interfaces;
using CadastroRotasRepository.Stores.Generic;
using CadastroRotasServices.Interfaces;
using CadastroRotasServices.Services;

namespace CadastroRotasAPI
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IGenericRepository<Rota>, GenericRepository<Rota>>();
            serviceProvider.AddScoped<IRotaService, RotaService>();

        }
    }
}
