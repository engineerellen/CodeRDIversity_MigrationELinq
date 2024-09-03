using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        AnimalServices _services;
        AnimalContext _context;

        public AnimaisController(AnimalContext context)
        {
            _context = context;
            _services = new AnimalServices(_context);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            try
            {
                return _services.ObterAnimais(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            try
            {
                Animal animal = new Animal { ID = id };
                return _services.ObterAnimal(animal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            try
            {
                 _services.InserirAnimal(animal);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Animal animal)
        {
            try
            {
                _services.AtualizarAnimal(animal);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _services.RemoverAnimal(id);
                return Ok("Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
