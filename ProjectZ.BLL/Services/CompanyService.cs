using ProjectZ.BLL.Interfaces;
using ProjectZ.BLL.Models;
using ProjectZ.DAL.Interfaces;

namespace ProjectZ.BLL.Services
{
    public class CompanyService : EntityService<Company>, ICompanyService
    {
        public CompanyService(IRepository<Company> repository) : base(repository) { }
        
    }
}
