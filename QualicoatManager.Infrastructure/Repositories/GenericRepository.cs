using Microsoft.EntityFrameworkCore;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Infrastructure;
using QualicoatManager.Infrastructure.Context;

namespace QualicoatManager.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityWithName
    {
        private readonly QualicoatManagerDbContext _qualicoatManagerDbContext;

        public GenericRepository(QualicoatManagerDbContext qualicoatManagerDbContext)
        {
            _qualicoatManagerDbContext = qualicoatManagerDbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? entity = await _qualicoatManagerDbContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException($"Entity of type {typeof(T)} not found!");
            };
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _qualicoatManagerDbContext.Set<T>().OrderBy(p => p.Name)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> SearchByNameAsync(string searchQuery)
        {
            return await _qualicoatManagerDbContext.Set<T>()
                .Where(r => r.Name.ToLower().Contains(searchQuery.ToLower()))
                .ToListAsync();
        }

        public async Task CreateItemAsync(T item)
        {
            await _qualicoatManagerDbContext.Set<T>().AddAsync(item);
            await _qualicoatManagerDbContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(T newItem, int id)
        {
            var existingItem = await GetByIdAsync(id);

            if (existingItem == null)
            {
                throw new NullReferenceException($"Item with ID {id} not found.");
            }

            newItem.Id = existingItem.Id;
            _qualicoatManagerDbContext.Entry(existingItem).CurrentValues.SetValues(newItem);
            

            await _qualicoatManagerDbContext.SaveChangesAsync();
        }


        public async Task DeleteItemAsync(int id)
        {
            var item = GetByIdAsync(id);
            if (item != null)
            {
                _qualicoatManagerDbContext.Set<T>().Remove(await item);
                await _qualicoatManagerDbContext.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            var entity = await ApplySpecification(spec).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new NullReferenceException($"Entity of type {typeof(T)} not found!");
            };

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_qualicoatManagerDbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
