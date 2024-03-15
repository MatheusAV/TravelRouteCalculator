namespace CadastroRotasDomain.MensageResponse
{
    /// <summary>
    /// Representa uma resposta padrão de serviço para operações da API.
    /// </summary>
    /// <typeparam name="T">O tipo de dado da propriedade <see cref="Data"/>.</typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Obtém ou define os dados da resposta. 
        /// Este campo é genérico e pode representar um objeto de retorno variado dependendo da operação realizada.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Obtém ou define um valor que indica se a operação foi bem-sucedida.
        /// </summary>
        /// <value>
        /// <c>true</c> se a operação foi bem-sucedida; caso contrário, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Obtém ou define a mensagem de resposta. Pode ser uma mensagem de sucesso ou de erro, 
        /// fornecendo mais Contexto sobre o resultado da operação.
        /// </summary>
        public string Message { get; set; }
    }

}
