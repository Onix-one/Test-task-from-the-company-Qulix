using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectZ.BLL.Interfaces
{
    public interface IEntityService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetEntityById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
       
    }
}
