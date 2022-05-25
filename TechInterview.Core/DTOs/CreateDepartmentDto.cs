using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechInterview.Core.DTOs
{
    public class CreateDepartmentDto
    {
        public CreateDepartmentDto()
        {
            Employees = new Collection<int>();
        }

        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public ICollection<int> Employees { get; set; }
        public int EnterpriseId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}