using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechInterview.Core.DTOs
{
    public class UpdateEmployeeDto
    {
        public UpdateEmployeeDto()
        {
            Departments = new Collection<int>();
        }

        public DateTime? Birthdate { get; set; }
        public ICollection<int> Departments { get; set; }
        public string Email { get; set; }
        public string ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool Status { get; set; }
        public string Surname { get; set; }
    }
}