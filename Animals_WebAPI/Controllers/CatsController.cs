using AnimalsClassLibrary.Abstractions;
using AnimalsClassLibrary.Models;
using AnimalsClassLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animals_WebAPI.Controllers
{
    [Route("api/Cats")]
    [ApiController]
    public class CatsController : ControllerBase
    {

        private IGenericRepository<Cat> _repository;
        private readonly ILogger<Cat> _logger;
        public CatsController(IGenericRepository<Cat> repository, ILogger<Cat> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
       
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("ExecutingGetAllCats", DateTime.Now);
                var response = _repository.GetAll();
                if (response != null)
                {
                    if (response.Count() > 0)
                    {
                        _logger.LogInformation("Get All Cats executed successfully with data fetched", DateTime.Now);
                        return Ok(response);
                    }
                    else
                        return StatusCode(204, "Any content found on query");
                }
                else
                {
                    _logger.LogInformation("Any data was found / something wrong while fetching data", DateTime.Now);
                    return StatusCode(500, "Something wrong found while trying to fetch data");
                }
                    
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on GetAllCats process" + ex.Message, DateTime.Now);
                return StatusCode(500, "Error on getting data operation, please double try");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Executing Get Cat by Id: {id}", DateTime.Now);

                var response = _repository.GetById(id);
                if (response == null)
                {
                    _logger.LogInformation($"Record with {id} not found on database", DateTime.Now);
                    return NotFound();
                }
                _logger.LogInformation($"Get Dog by Id {id} executed successfully with data fetched", DateTime.Now);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Cat by Id {id} was not found - {ex.Message}", DateTime.Now);
                return StatusCode(404, "Error while trying to fetch data, please try again with another id");
            }
        }

        // POST: GenericController/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult AddRecord([FromBody] Cat obj)
        {
            try
            {
                _logger.LogInformation("ExecutingAddNewCatRecord", DateTime.Now);
                var response = _repository.Add(obj);
                if (response != null)
                {
                    return new CreatedAtActionResult(nameof(GetById), nameof(BirdsController), new { response.Id }, response);
                }
                else
                    return StatusCode(204, "Without no response body ");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Adding Cat on CatsController was not performed properly " + ex.Message, DateTime.Now);
                return BadRequest("Unable to save data properly, please check data types and try again");
            }
        }

        [HttpPut("{id}")]
       // [ValidateAntiForgeryToken]
        public IActionResult UpdateRec(int id, [FromBody] Cat obj)
        {
            try
            {
                _logger.LogInformation($"ExecutingUpdateRecord of Dog id {id}");
                var response = _repository.Update(id, obj);
                if (response != null)
                {
                    _logger.LogInformation($"Record of cat id {id} updated successfully");
                    return Ok(response);
                }
                else
                {
                    _logger.LogInformation($"Executing Update Record CatsController caused error of {id}");
                    return StatusCode(204, "Without no response body");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"CatsController- Executing Update Record of id {id} Error: {ex.Message}");
                return StatusCode(500, $"Something wrong happened on deleting operation, please try again");
            }
           
        }


        // POST: GenericController/Delete/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteRec(int id)
        {
            try
            {
                _logger.LogInformation($"CatsController-Executing Deleting Record id {id}");
                var response = _repository.GetById(id);
                if (response != null)
                {
                    _repository.Delete(id);
                    return NoContent();
                }
                else
                {
                    _logger.LogInformation($"Deletion {nameof(CatsController)} threw error Record not found id {id}");
                    return StatusCode(404, "Record Not Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Executing Deleting Record on CatsControllersof id {id} threw Error: {ex.Message}");
                return StatusCode(500, "Something wrong happened on deleting operation, please try again");
            }
            
        }
    }
}
