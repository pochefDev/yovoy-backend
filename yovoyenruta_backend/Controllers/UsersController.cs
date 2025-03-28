using Microsoft.AspNetCore.Mvc;
using yovoyenruta_backend.Data.Entities;
using yovoyenruta_backend.Repository;

namespace yovoyenruta_backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository repository;

        public UsersController(UserRepository repository)
        {
            this.repository = repository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await repository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex) 
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            try
            {
                var user = repository.Show(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var newUser = await repository.Create(user);
                return Created("api/users", newUser);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, Guid userId)
        {
            try
            {
                var newUser = await repository.Update(user, userId);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            try
            {
                repository.Delete(userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }
    }
}
