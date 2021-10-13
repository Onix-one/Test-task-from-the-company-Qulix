using System;
using System.ComponentModel.DataAnnotations;
using ProjectZ.BLL.Enums;
using ProjectZ.BLL.Models;

namespace ProjectZ.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public DateTime HiringDate { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public WorkingPosition? Position { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
