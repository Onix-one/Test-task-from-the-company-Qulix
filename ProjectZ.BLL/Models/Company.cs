using System.Collections.Generic;
using ProjectZ.BLL.Enums;

namespace ProjectZ.BLL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LegalStatus LegalStatus { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
