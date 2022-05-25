using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;

namespace TechInterview.Core.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsEagerAsync();

        Task<Department> GetDepartmentEagerAsync(int id);

        Task<IEnumerable<Department>> GetDepartmentsByEnterpriseId(int id);
    }
}