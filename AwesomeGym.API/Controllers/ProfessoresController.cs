using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/professores")]
    public class ProfessoresController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;

        public ProfessoresController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _awesomeGymDbContext.Professores.ToList();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professores = _awesomeGymDbContext.Professores.SingleOrDefault(u => u.Id == id);

            if (professores == null)
            {
                return NotFound();
            }
            return Ok(professores);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            _awesomeGymDbContext.Professores.Add(professor);
            _awesomeGymDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), professor, new { id = professor.Id });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor professor)
        {
            if (!_awesomeGymDbContext.Professores.Any(a => a.Id == id))
            {
                return NotFound();
            }

            _awesomeGymDbContext.Professores.Update(professor);
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _awesomeGymDbContext.Professores.SingleOrDefault(u => u.Id == id);

            if (professor == null)
            {
                return NotFound();
            }

            _awesomeGymDbContext.Remove(professor);
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }
    }
}
