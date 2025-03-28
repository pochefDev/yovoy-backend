using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using yovoyenruta_backend.Data.Entities;

namespace yovoyenruta_backend.Repository
{
    public class OperatorRepository
    {
        private readonly ApplicationDbContext _context;

        public OperatorRepository(ApplicationDbContext context)
        {
            _context= context;
        }

        public class DriverCardInfo()
        {
            public Operator DriverInfo { get; set; }
            public User UserInfo { get; set; }

            public Shift ShiftInfo { get; set; }
        }

        public async Task<ActionResult<List<Operator>>> GetOperators()
        {
            try
            {
                return await _context.operators.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult<DriverCardInfo> Show(Guid id)
        {
            try
            {
                var bus_driver = _context.operators.FirstOrDefault(driver => driver.id == id);

                if (bus_driver == null)
                    throw new Exception("No se encontró al usuario especificado");

                var result = new DriverCardInfo
                {
                       DriverInfo = bus_driver,
                       UserInfo = _context.users.Find(bus_driver.user_id),
                       ShiftInfo = _context.shifts.Find(bus_driver.shift_id)
                };

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ActionResult<Operator>> Create(Operator bus_driver)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                Operator newOperator = new Operator()
                {
                    id  =  Guid.NewGuid(),
                    user_id = bus_driver.user_id,
                    shift_id = bus_driver.shift_id,
                    operator_number = bus_driver.operator_number,
                    service_zone = bus_driver.service_zone,
                    salary = bus_driver.salary,
                };

                _context.operators.Add(newOperator);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return newOperator;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<Operator>> Update(Operator bus_driver, Guid id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var update_bus_driver = _context.operators.FirstOrDefault(bus_driver => bus_driver.id == id);
                if (update_bus_driver == null)
                    throw new Exception("No se encontró al usuario especificado");

                update_bus_driver.operator_number = bus_driver.operator_number;
                update_bus_driver.service_zone = bus_driver.service_zone;
                update_bus_driver.years_experience = bus_driver.years_experience;
                update_bus_driver.current_status = bus_driver.current_status;
                update_bus_driver.salary = bus_driver.salary;

                _context.Entry(update_bus_driver).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return update_bus_driver;
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
                var bus_driver = _context.operators.FirstOrDefault(bus_driver => bus_driver.id == id);

                if (bus_driver == null)
                    throw new Exception("No se encontró al usuario especificado");

                _context.operators.Remove(bus_driver);
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
