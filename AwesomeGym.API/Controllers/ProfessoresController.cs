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
        public IActionResult Get(int id)
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

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _awesomeGymDbContext.Professores.SingleOrDefault(u => u.Id == id);

            if (professor == null)
            {
                return NotFound();
            }

            _awesomeGymDbContext.Entry(professor).State = EntityState.Deleted;
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }
    }
}
