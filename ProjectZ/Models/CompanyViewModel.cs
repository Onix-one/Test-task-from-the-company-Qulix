using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectZ.BLL.Enums;
using ProjectZ.BLL.Models;

namespace ProjectZ.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public LegalStatus LegalStatus { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
