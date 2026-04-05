using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Interfaces
{
    /*
     * Interface for a general repository
     */
    public interface IRepository<T>
    {
        IQueryable<T> Query();
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
