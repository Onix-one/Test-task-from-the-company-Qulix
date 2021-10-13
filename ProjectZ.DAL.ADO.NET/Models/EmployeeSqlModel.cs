using System;
using ProjectZ.BLL.Models;

namespace ProjectZ.DAL.ADO.NET.Models
{
    public class EmployeeSqlModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime HiringDate { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
