using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.Dapper.Mapper;
using ProjectZ.DAL.Dapper.Models;
using ProjectZ.DAL.Interfaces;

namespace ProjectZ.DAL.Dapper.Repositories
{
    public class SqlCompanyRepository : IRepository<Company>
    {
        private readonly IDbConnection _db;
        private readonly CustomSqlMapper _mapper;
        public SqlCompanyRepository(IDbConnection db, CustomSqlMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _db.QueryAsync<CompanySqlModel>("SELECT * FROM Companies");
            var employees = await _db.QueryAsync<EmployeeSqlModel>("SELECT * FROM Employees");
            return _mapper.MapCollectionCompanySqlModelToCompany(companies, employees);
        }
        public Company GetEntity(int id)
        {
            var company = _db.Query<CompanySqlModel>("SELECT * FROM Companies WHERE Id = @id",
                new { id }).FirstOrDefault();
            var employees =  _db.Query<EmployeeSqlModel>("SELECT * FROM Employees");
            return _mapper.MapCompanySqlModelToCompany(company, employees);
        }
        public void Create(Company item)
        {
            const string sqlQuery = "INSERT INTO Companies (Name, LegalStatus) VALUES(@Name, @LegalStatus)";
            _db.Execute(sqlQuery, _mapper.MapCompanyToCompanySqlModel(item));
        }
        public void Update(Company item)
        {
            const string sqlQuery = "UPDATE Companies SET Name = @Name, LegalStatus = @LegalStatus WHERE Id = @Id";
            _db.Execute(sqlQuery, _mapper.MapCompanyToCompanySqlModel(item));
        }
        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Companies WHERE Id = @id";
            _db.Execute(sqlQuery, new { id });
        }
    }
}
