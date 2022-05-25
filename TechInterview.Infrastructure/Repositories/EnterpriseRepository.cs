using TechInterview.Core.Entities;
using TechInterview.Core.Interfaces;
using TechInterview.Infrastructure.Data;

namespace TechInterview.Infrastructure.Repositories
{
    public class EnterpriseRepository : BaseRepository<Enterprise>, IEnterpriseRepository
    {
        public EnterpriseRepository(TechInterviewDataContext context)
            : base(context) { }
    }
}