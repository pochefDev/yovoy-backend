using Microsoft.EntityFrameworkCore;
using System.IO;
using yovoyenruta_backend.Data.Entities;

namespace yovoyenruta_backend.Data.DataSets
{
    public class InitialDataSeeder
    {
        private readonly ApplicationDbContext _context;

        public InitialDataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            UserTypeSeeder();
            UserSeeder();
            OperatorSeeder();

        }

        public void UserTypeSeeder()
        {
            if (!_context.user_types.Any())
            {
                IEnumerable<UserType> user_types = new List<UserType>()
                {
                    new UserType
                    {
                        id = Guid.NewGuid(),
                        description = "",
                        type = "passenger"
                    },
                    new UserType
                    {
                        id = Guid.NewGuid(),
                        description = "",
                        type = "driver"
                    }
                };

                _context.user_types.AddRange(user_types);
                _context.SaveChanges();


            }
        }

        public void UserSeeder()
        {
            if (!_context.user_types.Any())
            {
                var driver_type = _context.user_types.First(type => type.type == "driver");
                var passenger_type = _context.user_types.First(type => type.type == "passenger");

                if (!_context.users.Any())
                {
                    IEnumerable<User> users = new List<User>()
                    {
                        new User()
                        {
                            id = Guid.NewGuid(),
                            user_type_id = driver_type.id,
                            name = "Axel Olmos",
                            email = "axl@email.com",
                            phone = "449-451-5965",
                            password_hash = "axl12345",
                            is_active = true,
                            creation_date = DateTime.Now,
                            enrollment_date = DateTime.Now,
                        },
                        new User()
                        {
                            id = Guid.NewGuid(),
                            user_type_id = driver_type.id,
                            name = "Lalo Salinas",
                            email = "edu@email.com",
                            phone = "449-123-0013",
                            password_hash = "lalo12345",
                            is_active = true,
                            creation_date = DateTime.Now,
                            enrollment_date = DateTime.Now,
                        },
                        new User()
                        {
                            id = Guid.NewGuid(),
                            user_type_id = passenger_type.id,
                            name = "Diego Camacho",
                            email = "diego@email.com",
                            phone = "449-123-0013",
                            password_hash = "camacho12345",
                            is_active = true,
                            creation_date = DateTime.Now,
                            enrollment_date = DateTime.Now,
                        },
                        new User()
                        {
                            id = Guid.NewGuid(),
                            user_type_id = passenger_type.id,
                            name = "Pochef Carbajal",
                            email = "pochef@email.com",
                            phone = "449-279-1189",
                            password_hash = "poch12345",
                            is_active = true,
                            creation_date = DateTime.Now,
                            enrollment_date = DateTime.Now,
                        }
                    };

                    _context.users.AddRange(users);
                    _context.SaveChanges();

                };

            }
        }

        public void OperatorSeeder()
        {
            if (!_context.users.Any())
            {
                var axl_driver = _context.users.First(user => user.email == "axl@email.com");
                var lalo_driver = _context.users.First(user => user.email == "edu@email.com");

                if (!_context.operators.Any())
                {
                    IEnumerable<Operator> operators = new List<Operator>()
                    {
                        new Operator() {
                            id = Guid.NewGuid(),
                            user_id  = axl_driver.id,
                            service_zone = "Centro"
                        },
                        new Operator()
                        {
                            id = Guid.NewGuid(),
                            user_id = lalo_driver.id,
                            service_zone = "Norte"
                        }
                    };
                    _context.operators.AddRange(operators);
                    _context.SaveChanges();
                }
            }
        }
    }
}
