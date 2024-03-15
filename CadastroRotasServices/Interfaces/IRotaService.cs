using CadastroRotasDomain.Entities;
using CadastroRotasDomain.MensageResponse;

namespace CadastroRotasServices.Interfaces
{
    public interface IRotaService
    {
        Task<ServiceResponse<List<Rota>>> BuscaRotasAsync();
        Task<ServiceResponse<Rota>> BuscaRota(int id);
        Task<ServiceResponse<Rota>> AtualizaRota(Rota rota);
        Task<ServiceResponse<Rota>> DeletaRota(Rota rota);
        Task<ServiceResponse<Rota>> InseriRota(Rota rota);
        Task<ServiceResponse<List<string>>> BuscaMelhorRotaAsync(string origem, string destino);
        Task<ServiceResponse<List<Rota>>> InserirRotasAsync(List<Rota> rotas);
    }
}
