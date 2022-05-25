using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;

namespace TechInterview.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            await _unitOfWork.EmployeeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _unitOfWork.EmployeeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesEagerAsync()
        {
            return await _unitOfWork.EmployeeRepository.GetAllEmployeesEagerAsync();
        }

        public Task<Employee> GetEmployeeAsync(int id)
        {
            return _unitOfWork.EmployeeRepository.GetByIdAsync(id);
        }

        public async Task<Employee> GetEmployeeEagerAsync(int id)
        {
            return await _unitOfWork.EmployeeRepository.GetEmployeeEagerAsync(id);
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}