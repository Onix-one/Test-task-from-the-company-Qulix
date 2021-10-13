using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.ADO.NET.Mapper;
using ProjectZ.DAL.ADO.NET.Models;
using ProjectZ.DAL.Interfaces;

namespace ProjectZ.DAL.ADO.NET.Repositories
{
    public class SqlEmployeeRepository : IRepository<Employee>
    {
        private readonly IDbConnection _db;
        private readonly CustomSqlMapper _mapper;
        public SqlEmployeeRepository(IDbConnection db, CustomSqlMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            const string sqlQuery = "SELECT * FROM Employees A INNER JOIN Companies B on A.CompanyId = B.Id;";
            var employees = await _db.QueryAsync<Employee, Company, Employee>(
                sqlQuery,
                (employee, company) =>
                {
                    employee.Company = company;
                    employee.CompanyId = company.Id;
                    return employee;
                },
                splitOn: "CompanyId");
            return employees;
        }
        public Employee GetEntity(int id)
        {
            var employee = _db.QueryFirstOrDefault<EmployeeSqlModel>("SELECT * FROM Employees WHERE Id = @id",
                new { id });
            var companyId = employee.CompanyId;
            var company = _db.Query<CompanySqlModel>("SELECT * FROM Companies WHERE Id = @companyId",
                new { companyId }).FirstOrDefault();
            return _mapper.MapEmployeeSqlModelToEmployee(employee, company);
        }

        public void Create(Employee item)
        {
            const string sqlQuery = "INSERT INTO Employees (FirstName, MiddleName, " +
                                    "LastName, HiringDate, Position, CompanyId) " +
                                    "VALUES(@FirstName, @MiddleName, " +
                                    "@LastName, @HiringDate, @Position, @CompanyId)";
            _db.Execute(sqlQuery, _mapper.MapEmployeeToEmployeeSqlModel(item));
        }
        public void Update(Employee item)
        {
            const string sqlQuery = "UPDATE Employees SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                                    "HiringDate = @HiringDate, Position = @Position, CompanyId = @CompanyId WHERE Id = @Id";
            _db.Execute(sqlQuery, _mapper.MapEmployeeToEmployeeSqlModel(item));
        }
        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Employees WHERE Id = @id";
            _db.Execute(sqlQuery, new { id });
        }
    }
}
