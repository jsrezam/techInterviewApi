using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;

namespace TechInterview.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesEagerAsync();

        Task<Employee> GetEmployeeEagerAsync(int id);
    }
}