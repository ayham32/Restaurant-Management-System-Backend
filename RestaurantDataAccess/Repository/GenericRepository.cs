using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly RestaurantDbContext _context;

        public GenericRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public void DeleteAsync(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<bool> isExistAsync(int id)
            => await _context.Set<T>().FindAsync(id) != null;
    }
}
