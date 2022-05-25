using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;
using TechInterview.Infrastructure.Data;

namespace TechInterview.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TechInterviewDataContext context)
            : base(context) { }

        public async Task<IEnumerable<Employee>> GetAllEmployeesEagerAsync()
        {
            return await entities
                .Include(d => d.Departments)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeEagerAsync(int id)
        {
            return await entities
                .Include(d => d.Departments)
                .AsSplitQuery()
                .SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}