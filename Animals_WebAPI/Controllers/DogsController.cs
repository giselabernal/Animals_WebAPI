using AnimalsAppLibrary.Abstractions;
using AnimalsAppLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animals_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private IGenericRepository<Dog> _repository;

        public DogsController(IGenericRepository<Dog> repository)
        {
            _repository = repository;
        }


        [HttpGet("GetAllDogs")]
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

        [HttpGet("GetDogById{id}")]
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
        [HttpPost("Add-Dog")]
        // [ValidateAntiForgeryToken]
        public IActionResult AddRecord([FromBody] Dog obj)
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

        [HttpPut("Update-Dog-by-Id{id}")]
        // [ValidateAntiForgeryToken]
        public IActionResult UpdateRec(int id, [FromBody] Dog obj)
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
        [HttpDelete("Remove-Dog-By-Id{id}")]
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
