using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;

namespace TechInterview.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);

        Task Delete(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        void Update(T entity);
    }
}