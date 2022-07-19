using AnimalsClassLibrary.Abstractions;
using AnimalsClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animals_WebAPI.Controllers
{
    [Route("api/Birds")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private IGenericRepository<Bird> _repository;
        private readonly ILogger<Bird> _logger;

        public BirdsController(IGenericRepository<Bird> repository, ILogger<Bird> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("ExecutingGetAllBirds", DateTime.Now);
                var response = _repository.GetAll();
                if (response != null)
                {
                    if (response.Count() > 0)
                    {
                        _logger.LogInformation("Get All Birds executed successfully with data fetched", DateTime.Now);
                        return Ok(response);
                    }
                    else
                        return StatusCode(204, "Any content found on query");
                }
                else
                {
                    _logger.LogInformation("Error on GetAllBirds process" + DateTime.Now);
                    return StatusCode(500, "Error on getting data operation, please double try");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on GetAllBirds process" + ex.Message, DateTime.Now);
                return StatusCode(500, "Error on getting data operation, please double try");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Executing Get Bird by Id: {id}", DateTime.Now);

                var response = _repository.GetById(id);
                if (response == null)
                {
                    _logger.LogInformation($"Record with {id} not found on database", DateTime.Now);
                    return NotFound();
                }
                _logger.LogInformation($"Get Bird by Id {id} executed successfully with data fetched", DateTime.Now);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Bird by Id {id} was not found - {ex.Message}", DateTime.Now);
                return StatusCode(404, "Error while trying to fetch data, please try again with another id");
            }
        }

        // POST: GenericController/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult AddRecord([FromBody] Bird obj)
        {
            try
            {
                _logger.LogInformation("Executing Add New Bird Record", DateTime.Now);
                var response = _repository.Add(obj);
                if (response != null)
                {
                    return new CreatedAtActionResult(nameof(GetById), nameof(DogsController), new { response.Id }, response);
                }
                else
                    return StatusCode(204, "Without no response body ");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Adding Bird on BirdsController was not performed properly " + ex.Message, DateTime.Now);
                return BadRequest("Unable to save data properly, please check data types and try again");
            }
        }

        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        public IActionResult UpdateRec(int id, [FromBody] Bird obj)
        {
            try
            {
                _logger.LogInformation($"ExecutingUpdateRecord of Bird id {id}");
                var response = _repository.Update(id, obj);
                if (response != null)
                {
                    _logger.LogInformation($"Record of Bird id {id} updated successfully");
                    return Ok(response);
                }
                else
                {
                    _logger.LogInformation($"Executing Update Record BirdsController caused error of {id}");
                    return StatusCode(204, "Without no response body");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Executing Update Record on DogsController - id {id} Error: {ex.Message}");
                return StatusCode(500, $"Something wrong happened on deleting operation, please try again");
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteRec(int id)
        {
            try
            {
                _logger.LogInformation($"BirdsController-Executing Deleting Record id {id}");
                var response = _repository.GetById(id);
                if (response != null)
                {
                    _repository.Delete(id);
                    return NoContent();
                }
                else
                {
                    _logger.LogInformation($"Deletion {nameof(BirdsController)} threw error Record not found id {id}");
                    return StatusCode(404, "Record Not Found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Executing Deleting on BirdsControleer, Record id {id} threw Error: {ex.Message}");
                return StatusCode(500, "Something wrong happened on deleting operation, please try again");
            }

        }
    }
}
