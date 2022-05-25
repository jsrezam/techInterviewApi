using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechInterview.Core.DTOs
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            Departments = new Collection<int>();
        }

        public int Age { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<int> Departments { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool Status { get; set; }
        public string Surname { get; set; }
    }
}