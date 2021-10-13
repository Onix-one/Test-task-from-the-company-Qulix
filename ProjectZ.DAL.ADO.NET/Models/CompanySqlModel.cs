using System.Collections.Generic;
using ProjectZ.BLL.Models;

namespace ProjectZ.DAL.ADO.NET.Models
{
    public class CompanySqlModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LegalStatus { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
