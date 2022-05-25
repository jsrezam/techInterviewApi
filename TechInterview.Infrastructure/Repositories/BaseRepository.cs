using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;
using TechInterview.Infrastructure.Data;

namespace TechInterview.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> entities;

        public BaseRepository(TechInterviewDataContext context)
        {
            entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetByIdAsync(id);
            entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}