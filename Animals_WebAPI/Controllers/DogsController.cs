using AnimalsClassLibrary.Abstractions;
using AnimalsClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Animals_WebAPI.Controllers
{
    [Route("api/Dogs")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private IGenericRepository<Dog> _repository;
        private readonly ILogger<Dog> _logger;
        public DogsController(IGenericRepository<Dog> repository, ILogger<Dog> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("ExecutingGetAllDogs", DateTime.Now);
                var response = _repository.GetAll();
                if (response != null)
                {
                    if (response.Count() > 0)
                    {
                        _logger.LogInformation("Get All Dogs executed successfully with data fetched", DateTime.Now);
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
                _logger.LogError("Error on GetAllDogs process" + ex.Message, DateTime.Now);
                return StatusCode(500, "Error on getting data operation, please double try"); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Executing Get Dog by Id: {id}", DateTime.Now);
                
                var response = _repository.GetById(id);
                if (response == null)
                {
                    _logger.LogInformation($"Record with {id} not found on database", DateTime.Now);
                    return NotFound("Record not found in database");
                }  
                _logger.LogInformation($"Get Dog by Id {id} executed successfully with data fetched", DateTime.Now);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Dog by Id {id} was not found - {ex.Message}" , DateTime.Now);
                return StatusCode(404, "Error while trying to fetch data, please try again with another id");
            }
        }

        [HttpPost]
        public IActionResult AddRecord([FromBody] Dog obj)
        {
            try
            {
                _logger.LogInformation("ExecutingAddNewDogRecord", DateTime.Now);
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
                _logger.LogError($"Adding Dog on DogsController was not performed properly "+ ex.Message, DateTime.Now);
                return BadRequest("Unable to save data properly, please check data types and try again");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRec(int id, [FromBody] Dog obj)
        {
            try
            {
                _logger.LogInformation($"ExecutingUpdateRecord of Dog id {id}");
                var response = _repository.Update(id, obj);
                if (response != null)
                {
                    _logger.LogInformation($"Record of dog id {id} updated successfully");
                    return Ok(response);
                }
                else
                {
                    _logger.LogInformation($"Executing Update Record DogsController caused error of {id}");
                    return StatusCode(204, "Without no response body");
                }
                    

            }
            catch (Exception ex)
            {
                _logger.LogError($"Executing Update Record on DogsController - id {id} Error: {ex.Message}");
                return StatusCode(500, $"Something wrong happened on deleting operation, please try again");
             
            }

        }
        //Consider implementing bulk HTTP PUT operations that can batch updates to multiple resources in a collection.
        //The PUT request should specify the URI of the collection, and the request body should specify the details of the resources to be modified.
        //This approach can help to reduce chattiness and improve performance.
        //        //[ValidateAntiForgeryToken] investigar sobre el validateantiforgery

        [HttpDelete("{id}")]
        public IActionResult DeleteRec(int id)
        {
            try
            {
                _logger.LogInformation($"DogsController-Executing Deleting Record id {id}");
                var response = _repository.GetById(id);
                if (response != null)
                {
                    _repository.Delete(id);
                    return NoContent();
                }
                else
                {
                    _logger.LogInformation($"Deletion {nameof(DogsController)} threw error Record not found id {id}");
                    return StatusCode(404, "Record Not Found");
                }
                    
            }
            catch (Exception ex )
            {
                _logger.LogError($"Executing Deleting on DogControleer, Record id {id} threw Error: {ex.Message}");
                return StatusCode(500, "Something wrong happened on deleting operation, please try again");
            }

        }
    }
}
