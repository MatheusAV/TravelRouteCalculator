using CadastroRotasDomain.Entities;
using CadastroRotasRepository.Common;
using CadastroRotasRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroRotasRepository.Stores.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        private readonly ApplicationDbContext _Context;

        public GenericRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                _Context.Set<T>().Add(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw ;
            }
        }
        public async Task<IEnumerable<T>> AllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var entityInserted = await _Context.Set<T>().FirstOrDefaultAsync(r => r.Id == entity.Id);
            _Context.Set<T>().Remove(entityInserted);
            await _Context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FirstOrDefaultAsync(r => r.Id == id);
        }

        public IQueryable<T> GetQuery()
        {
            return _Context.Set<T>().AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            var entityInserted = await _Context.Set<T>().FirstOrDefaultAsync(r => r.Id == entity.Id);
            entityInserted = entity;
            await _Context.SaveChangesAsync();
        }
    }
}
