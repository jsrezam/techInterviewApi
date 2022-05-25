using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;

namespace TechInterview.Core.Interfaces
{
    public interface IDepartmentService
    {
        Task AddDepartmentAsync(Department department);

        Task<bool> DeleteDepartmentAsync(int id);

        Task<IEnumerable<Department>> GetAllDepartmentAsync();

        Task<IEnumerable<Department>> GetAllDepartmentsEagerAsync();

        Task<Department> GetDepartmentAsync(int id);

        Task<Department> GetDepartmentEagerAsync(int id);

        Task<bool> UpdateDepartmentAsync(Department department);

        Task<IEnumerable<Department>> GetDepartmentsByEnterprise(int id);
    }
}