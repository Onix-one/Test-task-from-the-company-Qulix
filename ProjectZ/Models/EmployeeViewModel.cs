using System;
using ProjectZ.BLL.Enums;
using ProjectZ.BLL.Models;

namespace ProjectZ.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime HiringDate { get; set; }
        public WorkingPosition? Position { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
