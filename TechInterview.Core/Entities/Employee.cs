using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechInterview.Core.Entities
{
    [Table("Employees")]
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Departments = new Collection<DepartmentEmployee>();
        }

        public int Age { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<DepartmentEmployee> Departments { get; set; }
        public string Email { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool Status { get; set; }
        public string Surname { get; set; }
    }
}