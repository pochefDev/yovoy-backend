using Microsoft.AspNetCore.Mvc;

namespace yovoyenruta_backend.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{email}/{password}")]
        public IActionResult LoginOperator(string email, string password)
        {
            try
            {
                var user = _context.users
                    .FirstOrDefault(user => user.email == email
                                         && user.role == "driver"
                                         && user.is_active == true);

                if (user == null)
                    throw new Exception("Credenciales incorrectas");

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);

                if (!isPasswordValid)
                    throw new Exception("Credenciales incorrectas");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }
    }
}
