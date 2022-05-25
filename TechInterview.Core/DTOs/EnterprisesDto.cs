using System;

namespace TechInterview.Core.DTOs
{
    public class EnterprisesDto
    {
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}