using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechInterview.Core.Entities
{
    public class Enterprise : BaseEntity
    {
        public Enterprise()
        {
            Departments = new Collection<Department>();
        }

        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Department> Departments { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}