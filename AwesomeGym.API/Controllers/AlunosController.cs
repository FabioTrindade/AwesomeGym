using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;

        public AlunosController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _awesomeGymDbContext.Alunos.ToList();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alunos = _awesomeGymDbContext.Alunos.SingleOrDefault(u => u.Id == id);

            if (alunos == null)
            {
                return NotFound();
            }
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            _awesomeGymDbContext.Alunos.Add(aluno);
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
            var alunos = _awesomeGymDbContext.Alunos.SingleOrDefault(u => u.Id == id);

            if (alunos == null)
            {
                return NotFound();
            }

            _awesomeGymDbContext.Entry(alunos).State = EntityState.Deleted;
            _awesomeGymDbContext.SaveChanges();

            return NoContent();
        }
    }
}
