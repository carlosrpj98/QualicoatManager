using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Specifications;

namespace QualicoatManager.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : EntityWithName
    {
        Task CreateItemAsync(T item);
        Task DeleteItemAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> SearchByNameAsync(string searchQuery);
        Task UpdateItemAsync(T newItem, int id);
    }
}