using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;

namespace TechInterview.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee employee);

        Task<bool> DeleteEmployeeAsync(int id);

        Task<IEnumerable<Employee>> GetAllEmployeeAsync();

        Task<IEnumerable<Employee>> GetAllEmployeesEagerAsync();

        Task<Employee> GetEmployeeAsync(int id);

        Task<Employee> GetEmployeeEagerAsync(int id);

        Task<bool> UpdateEmployeeAsync(Employee employee);
    }
}