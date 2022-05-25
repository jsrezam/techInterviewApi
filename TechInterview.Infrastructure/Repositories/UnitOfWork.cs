using System.Threading.Tasks;
using TechInterview.Core.Interfaces;
using TechInterview.Infrastructure.Data;

namespace TechInterview.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechInterviewDataContext _context;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IEnterpriseRepository _enterpriseRepository;

        public UnitOfWork(TechInterviewDataContext context)
        {
            _context = context;
            _enterpriseRepository = new EnterpriseRepository(_context);
            _departmentRepository = new DepartmentRepository(_context);
            _employeeRepository = new EmployeeRepository(_context);
        }

        public IDepartmentRepository DepartmentRepository => _departmentRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository;
        public IEnterpriseRepository EnterpriseRepository => _enterpriseRepository;

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}