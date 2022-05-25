using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechInterview.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            this.Employees = new Collection<DepartmentEmployee>();
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public ICollection<DepartmentEmployee> Employees { get; set; }
        public Enterprise Enterprise { get; set; }
        public int EnterpriseId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}