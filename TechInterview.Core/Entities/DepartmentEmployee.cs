using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechInterview.Core.Entities
{
    [Table("Departments_Employees")]
    public class DepartmentEmployee : BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}