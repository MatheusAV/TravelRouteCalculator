using CadastroRotasDomain.Entities;
using CadastroRotasDomain.MensageResponse;
using CadastroRotasRepository.Interfaces;
using CadastroRotasServices.Interfaces;

namespace CadastroRotasServices.Services
{
    public class RotaService : BaseService, IRotaService
    {
        public RotaService(IGenericRepository<Rota> genericRepository) : base(genericRepository)
        {
        }

        public async Task<ServiceResponse<List<Rota>>> BuscaRotasAsync()
        {
            try
            {
                var listaRotas = await _rep.AllAsync();
                return new ServiceResponse<List<Rota>> { Data = listaRotas.ToList(), Success = true, Message = "Rotas encontradas com sucesso." };
            }
            catch (Exception)
            {

                return new ServiceResponse<List<Rota>> { Data = null, Success = false, Message = "Erro ao buscar rotas." };
            }
        }

        public async Task<ServiceResponse<Rota>> BuscaRota(int id)
        {
            try
            {
                var rota = await _rep.GetByIdAsync(id);
                if (rota == null)
                {
                    return new ServiceResponse<Rota> { Data = null, Success = false, Message = "Rota não encontrada." };
                }
                return new ServiceResponse<Rota> { Data = rota, Success = true, Message = "Rota encontrada com sucesso." };
            }
            catch (Exception)
            {

                return new ServiceResponse<Rota> { Data = null, Success = false, Message = "Erro ao buscar a rota." };
            }
        }

        public async Task<ServiceResponse<Rota>> AtualizaRota(Rota rota)
        {
            try
            {
                await _rep.UpdateAsync(rota);
                return new ServiceResponse<Rota> { Data = rota, Success = true, Message = "Rota atualizada com sucesso." };
            }
            catch (Exception)
            {

                return new ServiceResponse<Rota> { Data = null, Success = false, Message = "Erro ao atualizar a rota." };
            }
        }

        public async Task<ServiceResponse<Rota>> DeletaRota(Rota rota)
        {
            try
            {
                await _rep.DeleteAsync(rota);
                return new ServiceResponse<Rota> { Data = null, Success = true, Message = "Rota deletada com sucesso." };
            }
            catch (Exception)
            {

                return new ServiceResponse<Rota> { Data = null, Success = false, Message = "Erro ao deletar a rota." };
            }
        }

        public async Task<ServiceResponse<Rota>> InseriRota(Rota rota)
        {
            try
            {
                await _rep.AddAsync(rota);
                return new ServiceResponse<Rota> { Data = rota, Success = true, Message = "Rota inserida com sucesso." };
            }
            catch (Exception)
            {
                return new ServiceResponse<Rota> { Data = null, Success = false, Message = "Erro ao inserir a rota." };
            }
        }     


        public async Task<ServiceResponse<List<string>>> BuscaMelhorRotaAsync(string origem, string destino)
        {
            try
            {
                List<Rota> rotas = (await _rep.AllAsync()).ToList();

                var grafo = new Grafo(direcionado: false);

                grafo.InserirAresta(rotas);

                if (!grafo.Vertices.ContainsKey(origem) || !grafo.Vertices.ContainsKey(destino))
                {
                    return new ServiceResponse<List<string>>
                    {
                        Data = null,
                        Success = false,
                        Message = "Origem ou destino não encontrados."
                    };
                }

                var caminhos = grafo.EncontrarTodosCaminhos(origem, destino);
                List<string> caminhosOrdenados = new List<string>();

                if (caminhos.Count > 0)
                {
                    // Organiza as rotas por custo
                    var caminhosComDetalhes = caminhos.Select(caminho => new
                    {
                        Descricao = caminho,                        
                        Custo = int.Parse(caminho.Split('$')[1].Trim())
                    })
                    .OrderBy(c => c.Custo) // Ordena diretamente pelo custo, do mais barato ao mais caro
                    .ToList();

                    // Numerando as rotas organizadas                    
                    for (int i = 0; i < caminhosComDetalhes.Count; i++)
                    {
                        caminhosOrdenados.Add($"{i + 1}. {caminhosComDetalhes[i].Descricao}");
                    }

                    return new ServiceResponse<List<string>>
                    {
                        Data = caminhosOrdenados,
                        Success = true,
                        Message = "Rotas encontradas com sucesso."
                    };
                }
                else
                {
                    return new ServiceResponse<List<string>>
                    {
                        Data = null,
                        Success = false,
                        Message = "Não foi possível encontrar um caminho."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<string>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Erro ao buscar a melhor rota: {ex.Message}"
                };
            }
        }

    }
}

