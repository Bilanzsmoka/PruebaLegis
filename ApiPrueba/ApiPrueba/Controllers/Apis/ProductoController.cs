using ApiPrueba.Models;
using ApiPrueba.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers.Apis
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IUnir _context;

        public ProductoController(IUnir context)
        {
            _context = context;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                return Ok(await _context.Producto.TodosRegistros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/<ProductoController>/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<Producto>> GetProducto(int Id)
        {
            try
            {
                var result = await _context.Producto.Buscar(Id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult<Producto>> Post([FromBody] Producto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest();
                var producto1 = new Producto();
                producto1 = producto;
                var result = await _context.Producto.Crear(producto);
                _context.Save();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<ProductoController>/5
        [HttpPut]
        public async Task<ActionResult<Producto>> Put(Producto Producto)
        {
            try
            {
                var ProductoToUpdate = await _context.Producto.Buscar(Producto.Id);
                if (ProductoToUpdate == null)
                    return NotFound($"No existe un Registro con el Id = {Producto.Id}");
                var response = await _context.Producto.Modificar(Producto);
                _context.Save();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int Id)
        {
            try
            {
                var ProductoToDelete = await _context.Producto.Buscar(Id);
                if (ProductoToDelete == null)
                    return NotFound($"No se pudo encontrar el genero con Id = {Id}");
                await _context.Producto.Borrar(Id);
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

