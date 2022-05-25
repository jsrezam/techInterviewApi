using System;
using System.Threading.Tasks;

namespace TechInterview.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IEnterpriseRepository EnterpriseRepository { get; }

        Task SaveChangesAsync();
    }
}