using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;
using TechInterview.Infrastructure.Data;

namespace TechInterview.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(TechInterviewDataContext context)
            : base(context) { }

        public async Task<IEnumerable<Department>> GetAllDepartmentsEagerAsync()
        {
            return await entities
                .Include(en => en.Enterprise)
                .Include(e => e.Employees)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Department> GetDepartmentEagerAsync(int id)
        {
            return await entities
                .Include(en => en.Enterprise)
                .Include(e => e.Employees)
                .AsSplitQuery()
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsByEnterpriseId(int id)
        {
            return await entities
                .Where(d => d.EnterpriseId == id)
                .AsSplitQuery()
                .ToListAsync();
        }
    }
}