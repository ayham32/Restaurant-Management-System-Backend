using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.Entities;
using RestaurantDataAccess.InterfaceRepository;
using RestaurantShared.Pagination;
using RestaurantShared.Parameters;

namespace RestaurantDataAccess.Repository
{
    public class PeopleRepository : GenericRepository<Person>,IPeopleRepository
    {
        private readonly RestaurantDbContext _context;

        public PeopleRepository(RestaurantDbContext context):base(context)
        {
            _context = context;
        }       
        
        
        public async Task<Person> GetPersonAsync(string NationalNo)
           => await _context.People.SingleOrDefaultAsync(p=>p.NationalNo== NationalNo);

        
        public async Task<bool> isPersonExist(string NationalNo)
            => await _context.People.AnyAsync(p => p.NationalNo == NationalNo);

        public async Task<PagedResult<Person>> GetAll(PersonParameter parameters)
        {
            var query = _context.People
                        .AsNoTracking()
                        .AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(parameters.Search))
            {
                query = query.Where(p =>
                    p.FirstName.Contains(parameters.Search) ||
                    p.LastName.Contains(parameters.Search));
            }

            // Filter Gender
            if (parameters.Gender.HasValue)
            {
                query = query.Where(p =>
                    p.Gender == parameters.Gender);
            }

            var totalCount = await query.CountAsync();

            var people = await query
                .Skip((parameters.PageNumber - 1)
                    * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new PagedResult<Person>
            {
                Items = people,
                TotalCount = totalCount,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize
            };
        }
        

    }
}
