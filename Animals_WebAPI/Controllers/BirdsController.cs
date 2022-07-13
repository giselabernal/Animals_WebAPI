using AnimalsAppLibrary.Abstractions;
using AnimalsAppLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animals_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private IGenericRepository<Bird> _repository;

        public BirdsController(IGenericRepository<Bird> repository)
        {
            _repository = repository;
        }


        [HttpGet("GetAllBirds")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _repository.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBirdById{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _repository.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: GenericController/Create
        [HttpPost("Add-Bird")]
        // [ValidateAntiForgeryToken]
        public IActionResult AddRecord([FromBody] Bird obj)
        {
            try
            {
                var response = _repository.Add(obj);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Bird-by-Id{id}")]
        // [ValidateAntiForgeryToken]
        public IActionResult UpdateRec(int id, [FromBody] Bird obj)
        {
            try
            {
                var response = _repository.Update(id, obj);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // POST: GenericController/Delete/5
        [HttpDelete("Remove-Bird-By-Id{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteRec(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
