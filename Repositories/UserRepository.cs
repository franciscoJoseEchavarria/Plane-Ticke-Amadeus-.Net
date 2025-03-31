using AmadeusAPI.Interfaces;
using AmadeusAPI.Models;
using AmadeusAPI.Data;
using Microsoft.EntityFrameworkCore;



namespace AmadeusAPI.Repositories;

    public class UserRepository : IUserRepository
    {
        private readonly AmadeusAPIDbContext _context;

        public UserRepository(AmadeusAPIDbContext context)
        {
            _context = context;
        }
        
        public async Task <User> GetUser(String email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found.");
            }
            return user;
        }
        
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

         public async Task<PagedResult<User>> GetPagedUsers(int page, int pageSize)
    {
        // Asegúrate de que page y pageSize tengan valores razonables
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        // Obtenemos la consulta base
        var query = _context.Users.AsQueryable();

        // Contamos cuántos usuarios hay en total
        var totalItems = await query.CountAsync();

        // Calculamos cuántas páginas hay
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        // Obtenemos solo los elementos de la página solicitada
        var items = await query
            .OrderBy(u => u.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // Retornamos el resultado paginado
        return new PagedResult<User>
        {
            Items = items,
            currentPage = page,
            pageSize = pageSize,
            totalItems = totalItems,
            totalPages = totalPages
        };
    }


    }
