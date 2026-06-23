using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface IGenericRepository<T> where T :class
    {
        Task <IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(int id);

         Task<bool> isExistAsync(int id);

        void DeleteAsync(T entity);

        Task AddAsync(T entity);
    }
}
