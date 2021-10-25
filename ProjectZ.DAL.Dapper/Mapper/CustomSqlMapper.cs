using System;
using System.Collections.Generic;
using System.Linq;
using ProjectZ.BLL.Enums;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.Dapper.Models;

namespace ProjectZ.DAL.Dapper.Mapper
{
    public class CustomSqlMapper
    {
        public CompanySqlModel MapCompanyToCompanySqlModel(Company company)
        {
            if (company.Id == 0)
            {
                var companySqlModel = new CompanySqlModel
                {
                    Name = company.Name,
                    LegalStatus = company.LegalStatus.ToString()
                };
                return companySqlModel;
            }
            else
            {
                var companySqlModel = new CompanySqlModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    LegalStatus = company.LegalStatus.ToString()
                };
                return companySqlModel;
            }
        }
        public Company MapCompanySqlModelToCompany(CompanySqlModel companySqlModel, 
            IEnumerable<EmployeeSqlModel> collectionEmployeeSqlModel)
        {
            var company = new Company
            {
                Id = companySqlModel.Id,
                Name = companySqlModel.Name,
                LegalStatus = (LegalStatus)Enum.Parse(typeof(LegalStatus), companySqlModel.LegalStatus),
                Employees = MapCollectionEmployeeSqlModelToEmployee(collectionEmployeeSqlModel)
                    .Where(_ => _.CompanyId == companySqlModel.Id).ToList()
            };
            return company;
        }

        private Company MapCompanySqlModelToCompanyWithoutEmployees(CompanySqlModel companySqlModel)
        {
            var company = new Company
            {
                Id = companySqlModel.Id,
                Name = companySqlModel.Name,
                LegalStatus = (LegalStatus)Enum.Parse(typeof(LegalStatus), companySqlModel.LegalStatus)
            };
            return company;
        }
        public IEnumerable<Company> MapCollectionCompanySqlModelToCompany(IEnumerable<CompanySqlModel> collectionCompanySqlModel,
            IEnumerable<EmployeeSqlModel> collectionEmployeeSqlModel)
        {
            var companies = new List<Company>();
            foreach (var companySqlModel in collectionCompanySqlModel)
            {
                var company = new Company
                {
                    Id = companySqlModel.Id,
                    Name = companySqlModel.Name,
                    LegalStatus = (LegalStatus)Enum.Parse(typeof(LegalStatus), companySqlModel.LegalStatus),
                    Employees = MapCollectionEmployeeSqlModelToEmployee(collectionEmployeeSqlModel)
                        .Where(_=>_.CompanyId == companySqlModel.Id).ToList()
                };
                companies.Add(company);
            }
            return companies.AsEnumerable();
        }
        public EmployeeSqlModel MapEmployeeToEmployeeSqlModel(Employee employee)
        {
            if (employee.Id == 0)
            {
                var employeeSqlModel = new EmployeeSqlModel
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    HiringDate = employee.HiringDate.Date,
                    Position = employee.Position.ToString(),
                    CompanyId = employee.CompanyId
                };
                return employeeSqlModel;
            }
            else
            {
                var employeeSqlModel = new EmployeeSqlModel
                {
                    Id = employee.Id,
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    HiringDate = employee.HiringDate.Date,
                    Position = employee.Position.ToString(),
                    CompanyId = employee.CompanyId
                };
                return employeeSqlModel;
            }
        }
        public Employee MapEmployeeSqlModelToEmployee(EmployeeSqlModel employeeSqlModel, CompanySqlModel companySqlModel)
        {
            var company = new Employee
            {
                Id = employeeSqlModel.Id,
                LastName = employeeSqlModel.LastName,
                FirstName = employeeSqlModel.FirstName,
                MiddleName = employeeSqlModel.MiddleName,
                HiringDate = employeeSqlModel.HiringDate.Date,
                Position = (WorkingPosition)Enum.Parse(typeof(WorkingPosition), employeeSqlModel.Position),
                CompanyId = employeeSqlModel.CompanyId,
                Company = MapCompanySqlModelToCompanyWithoutEmployees(companySqlModel)
            };
            return company;
        }
        private IEnumerable<Employee> MapCollectionEmployeeSqlModelToEmployee(IEnumerable<EmployeeSqlModel> collectionEmployeeSqlModel)
        {
            var employees = new List<Employee>();
            foreach (var employeeSqlModel in collectionEmployeeSqlModel)
            {
                var employee = new Employee
                {
                    Id = employeeSqlModel.Id,
                    LastName = employeeSqlModel.LastName,
                    FirstName = employeeSqlModel.FirstName,
                    MiddleName = employeeSqlModel.MiddleName,
                    HiringDate = employeeSqlModel.HiringDate.Date,
                    Position = (WorkingPosition)Enum.Parse(typeof(WorkingPosition), employeeSqlModel.Position),
                    CompanyId = employeeSqlModel.CompanyId,
                    Company = employeeSqlModel.Company
                };
                employees.Add(employee);
            }
            return employees.AsEnumerable();
        }
    }
}
