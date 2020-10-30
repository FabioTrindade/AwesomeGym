using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/unidades")]
    public class UnidadesController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;

        public UnidadesController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var unidades = _awesomeGymDbContext.Unidades.ToList();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var unidades = _awesomeGymDbContext.Unidades.SingleOrDefault(u => u.Id == id);

            if (unidades == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById), unidades, new { id = unidades.Id });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Unidade unidade)
        {
            if (!ModelState.IsValid)
                return NotFound();

            _awesomeGymDbContext.Unidades.Add(unidade);
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Unidade unidade)
        {
            if (!_awesomeGymDbContext.Unidades.Any(a => a.Id == id))
            {
                return NotFound();
            }

            _awesomeGymDbContext.Unidades.Update(unidade);
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var unidades = _awesomeGymDbContext.Unidades.SingleOrDefault(u => u.Id == id);

            if (unidades == null)
            {
                return NotFound();
            }

            _awesomeGymDbContext.Remove(unidades);
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }
    }
}
