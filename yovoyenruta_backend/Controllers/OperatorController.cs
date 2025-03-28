using Microsoft.AspNetCore.Mvc;
using yovoyenruta_backend.Data.Entities;
using yovoyenruta_backend.Repository;

namespace yovoyenruta_backend.Controllers
{
    [Route("api/operators")]
    public class OperatorController : ControllerBase
    {
        private readonly OperatorRepository repository;

        public OperatorController(OperatorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperators()
        {
            try
            {
                var operatos = await repository.GetOperators();
                return Ok(operatos);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOperator(Guid id)
        {
            try
            {
                var bus_driver = repository.Show(id);

                return Ok(bus_driver);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperator(Operator bus_driver)
        {
            try
            {
                var newBusDriver = await repository.Create(bus_driver);
                return Created("api/users", newBusDriver);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpPut("{operetorId}")]
        public async Task<IActionResult> UpdateOperator(Operator bus_driver, Guid operetorId)
        {
            try
            {
                var newBusDriver = await repository.Update(bus_driver, operetorId);
                return Ok(newBusDriver);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }

        [HttpDelete("{operetorId}")]
        public IActionResult DeleteOperator(Guid operetorId)
        {
            try
            {
                repository.Delete(operetorId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = ex.Message });
            }
        }


    }
}
