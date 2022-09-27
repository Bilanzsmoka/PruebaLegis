using ApiPrueba.Models;
using ApiPrueba.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers.Apis
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ProovedorController : Controller
    {
        private readonly IUnir _context;

        public ProovedorController(IUnir context)
        {
            _context = context;
        }

        // GET: api/<ProovedorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proovedor>>> GetProovedors()
        {
            try
            {
                return Ok(await _context.Proovedor.TodosRegistros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/<ProovedorController>/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<Proovedor>> GetProovedor(int Id)
        {
            try
            {
                var result = await _context.Proovedor.Buscar(Id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<ProovedorController>
        [HttpPost]
        public async Task<ActionResult<Proovedor>> Post([FromBody] Proovedor Proovedor)
        {
            try
            {
                if (Proovedor == null)
                    return BadRequest();
                var Proovedor1 = new Proovedor();
                Proovedor1 = Proovedor;
                var result = await _context.Proovedor.Crear(Proovedor);
                _context.Save();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<ProovedorController>/5
        [HttpPut]
        public async Task<ActionResult<Proovedor>> Put(Proovedor Proovedor)
        {
            try
            {
                var ProovedorToUpdate = await _context.Proovedor.Buscar(Proovedor.Id);
                if (ProovedorToUpdate == null)
                    return NotFound($"No existe un Registro con el Id = {Proovedor.Id}");
                var response = await _context.Proovedor.Modificar(Proovedor);
                _context.Save();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProovedorController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Proovedor>> DeleteProovedor(int Id)
        {
            try
            {
                var ProovedorToDelete = await _context.Proovedor.Buscar(Id);
                if (ProovedorToDelete == null)
                    return NotFound($"No se pudo encontrar el genero con Id = {Id}");
                await _context.Proovedor.Borrar(Id);
                _context.Save();
                return Ok("Registro Elminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
