using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yovoyenruta_backend.Data.Entities;

namespace yovoyenruta_backend.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<User>>> GetUsers()
        {
            try
            {
                return await _context.users.ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public User Show(Guid id)
        {
            try
            {
                var user = _context.users.FirstOrDefault(user => user.id == id);

                if (user == null)
                    throw new Exception("No se encontró al usuario especificado");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<User>> Create(User user)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                User newUser = new User()
                {
                    id = Guid.NewGuid(),
                    user_type_id = user.user_type_id,
                    name = user.name,
                    email = user.email,
                    phone = user.phone,
                    password_hash = user.password_hash,
                    is_active = true,
                    enrollment_date = user.enrollment_date,
                    creation_date = DateTime.Now,
                };

                _context.users.Add(newUser);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return newUser;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Update(User user, Guid userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                
                var updateUser = _context.users.FirstOrDefault(user => user.id == userId);

                if (updateUser == null)
                    throw new Exception("No se encontró al usuario especificado");

                updateUser.user_type_id = user.user_type_id;
                updateUser.name = user.name;
                updateUser.email = user.email;
                updateUser.phone = user.phone;
                updateUser.password_hash = user.password_hash;
                updateUser.is_active = user.is_active;
                updateUser.enrollment_date = user.enrollment_date;

                _context.Entry(updateUser).State = EntityState.Modified;
                _context.SaveChanges();
                await transaction.CommitAsync();

                return updateUser;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async void Delete(Guid id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = _context.users.FirstOrDefault(user => user.id == id);

                if (user == null)
                    throw new Exception("No se encontró al usuario especificado");

                _context.users.Remove(user);
                _context.SaveChanges();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

    }
}
