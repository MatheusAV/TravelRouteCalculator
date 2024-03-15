using CadastroRotasDomain.Entities;
using CadastroRotasRepository.Interfaces;

namespace CadastroRotasServices.Services
{
    public class BaseService
    {
        protected readonly IGenericRepository<Rota> _rep;

        public BaseService(IGenericRepository<Rota> genericRepository)
        {
            _rep = genericRepository;
        }
    }
}
