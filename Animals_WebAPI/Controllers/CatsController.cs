using AnimalsAppLibrary.Abstractions;
using AnimalsAppLibrary.Models;
using AnimalsAppLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animals_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {

        private IGenericRepository<Cat> _repository;

        public CatsController(IGenericRepository<Cat> repository)
        {
            _repository = repository;
        }


        [HttpGet("GetAllCats")]
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

        [HttpGet("GetCatById{id}")]
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
        [HttpPost("Add-Cat")]
       // [ValidateAntiForgeryToken]
        public IActionResult AddRecord([FromBody] Cat obj)
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

        [HttpPut("Update-Cat-by-Id{id}")]
       // [ValidateAntiForgeryToken]
        public IActionResult UpdateRec(int id, [FromBody] Cat obj)
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
        [HttpDelete("Remove-Cat-By-Id{id}")]
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
