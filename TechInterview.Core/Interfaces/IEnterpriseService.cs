using System.Collections.Generic;
using System.Threading.Tasks;
using TechInterview.Core.Entities;

namespace TechInterview.Core.Interfaces
{
    public interface IEnterpriseService
    {
        Task AddEnterpriseAsync(Enterprise enterprise);

        Task<bool> DeleteEnterpriseAsync(int id);

        Task<IEnumerable<Enterprise>> GetAllEnterprisesAsync();

        Task<Enterprise> GetEnterpriseAsync(int id);

        Task<bool> UpdateEnterpriseAsync(Enterprise enterprise);

        Task<Enterprise> GetEnterpriseByEmployeeAsync(int id);
    }
}