using CadastroRotasDomain.Entities;
using CadastroRotasDomain.MensageResponse;
using CadastroRotasServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CadastroRotasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RotaController : AppBaseController
    {
        public RotaController(IServiceProvider serviceProvider, IRotaService service) : base(serviceProvider, service)
        {
        }

        /// <summary>
        /// Lista todas as rotas disponíveis.
        /// </summary>
        /// <response code="200">Retorna a lista de rotas.</response>
        /// <response code="404">Não foi possível encontrar rotas.</response>
        [SwaggerResponse(200, "Lista de rotas encontradas", typeof(ServiceResponse<List<Rota>>))]
        [SwaggerResponse(404, "Rotas não encontradas")]
        [HttpGet("Lista")]
        public async Task<IActionResult> BuscaRotasAsync()
        {
            var response = await _service.BuscaRotasAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        /// <summary>
        /// Busca detalhes de uma rota específica pelo ID.
        /// </summary>
        /// <param name="id">O ID da rota.</param>
        /// <response code="200">Retorna os detalhes da rota.</response>
        /// <response code="404">Rota não encontrada.</response>
        [SwaggerResponse(200, "Detalhes da rota", typeof(ServiceResponse<Rota>))]
        [SwaggerResponse(404, "Rota não encontrada")]
        [HttpGet("Busca/{id}")]
        public async Task<IActionResult> BuscaRota(int id)
        {
            var response = await _service.BuscaRota(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        /// <summary>
        /// Insere uma nova rota no sistema.
        /// </summary>
        /// <param name="rota">Dados da nova rota.</param>
        /// <response code="201">Rota criada com sucesso.</response>
        /// <response code="400">Erro ao inserir a rota.</response>
        [SwaggerResponse(201, "Rota inserida com sucesso", typeof(ServiceResponse<Rota>))]
        [SwaggerResponse(400, "Erro ao inserir a rota")]
        [HttpPost("Inseri")]
        public async Task<IActionResult> InseriRota([FromBody] Rota rota)
        {
            var response = await _service.InseriRota(rota);
            if (response.Success)
            {
                return CreatedAtAction(nameof(BuscaRota), new { id = rota.Id }, response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Atualiza os dados de uma rota existente.
        /// </summary>
        /// <param name="rota">Dados atualizados da rota.</param>
        /// <response code="200">Rota atualizada com sucesso.</response>
        /// <response code="404">Rota não encontrada.</response>
        [SwaggerResponse(200, "Rota atualizada com sucesso", typeof(ServiceResponse<Rota>))]
        [SwaggerResponse(404, "Rota não encontrada")]
        [HttpPut("Atualiza")]
        public async Task<IActionResult> AtualizaRota([FromBody] Rota rota)
        {
            var response = await _service.AtualizaRota(rota);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        /// <summary>
        /// Deleta uma rota específica pelo ID.
        /// </summary>
        /// <param name="id">O ID da rota a ser deletada.</param>
        /// <response code="200">Rota deletada com sucesso.</response>
        /// <response code="400">Erro ao deletar a rota.</response>
        [SwaggerResponse(200, "Rota deletada com sucesso", typeof(ServiceResponse<Rota>))]
        [SwaggerResponse(400, "Erro ao deletar a rota")]
        [HttpDelete("Deleta/{id}")]      

        public async Task<IActionResult> DeletaRota(int id)
        {
            var rota = await _service.BuscaRota(id);
            if (!rota.Success)
            {
                return NotFound(rota);
            }

            var response = await _service.DeletaRota(rota.Data);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Busca a rota mais barata entre duas localidades.
        /// </summary>
        /// <param name="origem">A localidade de origem da rota.</param>
        /// <param name="destino">A localidade de destino da rota.</param>
        /// <response code="200">Rota mais barata encontrada com sucesso.</response>
        /// <response code="400">Erro ao buscar a rota mais barata.</response>
        [HttpGet("BuscaMelhorRota")]
        [SwaggerResponse(200, "Rota mais barata encontrada com sucesso", typeof(ServiceResponse<string>))]
        [SwaggerResponse(400, "Erro ao buscar a rota mais barata")]
        public async Task<IActionResult> BuscaMelhorRota(string origem, string destino)
        {
            var resposta = await _service.BuscaMelhorRotaAsync(origem, destino);

            if (resposta.Success)
            {
                return Ok(resposta);
            }
            else
            {
                return BadRequest(resposta);
            }
        }
    }
}