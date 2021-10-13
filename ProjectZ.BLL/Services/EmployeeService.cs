using ProjectZ.BLL.Interfaces;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.Interfaces;

namespace ProjectZ.BLL.Services
{
    public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        public EmployeeService(IRepository<Employee> repository) : base(repository) { }

    }
}
