using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechInterview.Core.DTOs
{
    public class CreateEnterpriseDto
    {
        public CreateEnterpriseDto()
        {
            Departments = new Collection<int>();
        }

        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<int> Departments { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}