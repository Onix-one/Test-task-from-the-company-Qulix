using System.Collections.Generic;
using System.Linq;
using ProjectZ.BLL.Models;
using ProjectZ.Models;

namespace ProjectZ.Mapper
{
    public class CustomViewModelMapper
    {
        public CompanyViewModel MapCompanyToCompanyViewModel(Company company)
        {
            if (company.Id == 0)
            {
                var companyViewModel = new CompanyViewModel
                {
                    Name = company.Name,
                    LegalStatus = company.LegalStatus
                };
                return companyViewModel;
            }
            else
            {
                var companyViewModel = new CompanyViewModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    LegalStatus = company.LegalStatus
                };
                return companyViewModel;
            }
        }
        public Company MapCompanySqlModelToCompany(CompanyViewModel companyViewModel)
        {
            var company = new Company
            {
                Id = companyViewModel.Id,
                Name = companyViewModel.Name,
                LegalStatus = companyViewModel.LegalStatus
            };
            return company;
        }
        public IEnumerable<CompanyViewModel> MapCompaniesToCompaniesViewModel(IEnumerable<Company> companies)
        {
            var companiesViewModel = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                var companyViewModel = new CompanyViewModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    LegalStatus = company.LegalStatus,
                    Employees = company.Employees
                };
                companiesViewModel.Add(companyViewModel);
            }
            return companiesViewModel.AsEnumerable();
        }

        public EmployeeViewModel MapEmployeeToEmployeeViewModel(Employee employee)
        {
            if (employee.Id == 0)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    HiringDate = employee.HiringDate,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId,
                    Company = employee.Company
                };
                return employeeViewModel;
            }
            else
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    HiringDate = employee.HiringDate,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId,
                    Company = employee.Company
                };
                return employeeViewModel;
            }
        }
        public Employee MapEmployeeSqlModelToEmployee(EmployeeViewModel employeeViewModel)
        {
            var employee = new Employee
            {
                Id = employeeViewModel.Id,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                MiddleName = employeeViewModel.MiddleName,
                HiringDate = employeeViewModel.HiringDate,
                Position = employeeViewModel.Position,
                CompanyId = employeeViewModel.CompanyId,
                Company = employeeViewModel.Company
            };
            return employee;
        }
        public IEnumerable<EmployeeViewModel> MapEmployeesToEmployeesViewModel(IEnumerable<Employee> employees)
        {
            var employeesList = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    HiringDate = employee.HiringDate,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId,
                    Company = employee.Company
                };
                employeesList.Add(employeeViewModel);
            }
            return employeesList.AsEnumerable();
        }
    }
}
