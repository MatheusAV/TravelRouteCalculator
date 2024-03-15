namespace CadastroRotasDomain.Entities
{
    /// <summary>
    /// Representa uma rota de viagem entre duas localidades, incluindo a origem, o destino e o custo da viagem.
    /// </summary>
    public class Rota : Base
    {
        /// <summary>
        /// Obtém ou define a localidade de origem da rota.
        /// </summary>
        /// <value>A localidade de onde a rota se inicia.</value>
        public string Origem { get; set; }

        /// <summary>
        /// Obtém ou define a localidade de destino da rota.
        /// </summary>
        /// <value>A localidade onde a rota termina.</value>
        public string Destino { get; set; }

        /// <summary>
        /// Obtém ou define o custo associado à viagem da rota.
        /// </summary>
        /// <value>O custo financeiro da viagem.</value>
        public decimal Custo { get; set; }
    }
}
