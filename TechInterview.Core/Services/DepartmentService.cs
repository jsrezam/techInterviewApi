using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;

namespace TechInterview.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _unitOfWork.DepartmentRepository.AddAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            await _unitOfWork.DepartmentRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _unitOfWork.DepartmentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsEagerAsync()
        {
            return await _unitOfWork.DepartmentRepository.GetAllDepartmentsEagerAsync();
        }

        public async Task<Department> GetDepartmentAsync(int id)
        {
            return await _unitOfWork.DepartmentRepository.GetByIdAsync(id);
        }

        public Task<Department> GetDepartmentEagerAsync(int id)
        {
            return _unitOfWork.DepartmentRepository.GetDepartmentEagerAsync(id);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsByEnterprise(int id)
        {
            return await _unitOfWork.DepartmentRepository.GetDepartmentsByEnterpriseId(id);
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            _unitOfWork.DepartmentRepository.Update(department);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}