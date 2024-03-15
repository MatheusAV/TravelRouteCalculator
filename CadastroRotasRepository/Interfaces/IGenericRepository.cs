using CadastroRotasDomain.Entities;

namespace CadastroRotasRepository.Interfaces
{
    public interface IGenericRepository<T> where T : Base
    {
        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        IQueryable<T> GetQuery();

        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> AllAsync();
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}
