using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;

namespace TechInterview.Core.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnterpriseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEnterpriseAsync(Enterprise enterprise)
        {
            await _unitOfWork.EnterpriseRepository.AddAsync(enterprise);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteEnterpriseAsync(int id)
        {
            await _unitOfWork.EnterpriseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Enterprise>> GetAllEnterprisesAsync()
        {
            return await _unitOfWork.EnterpriseRepository.GetAllAsync();
        }

        public async Task<Enterprise> GetEnterpriseAsync(int id)
        {
            return await _unitOfWork.EnterpriseRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateEnterpriseAsync(Enterprise enterprise)
        {
            _unitOfWork.EnterpriseRepository.Update(enterprise);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Enterprise> GetEnterpriseByEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeeEagerAsync(id);
            if (employee == null) return null;
            
            var departmentId = employee.Departments.FirstOrDefault().DepartmentId;
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);
            return await _unitOfWork.EnterpriseRepository.GetByIdAsync(department.EnterpriseId);
        }
    }
}