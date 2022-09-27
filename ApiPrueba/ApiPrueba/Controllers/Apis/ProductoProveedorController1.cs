using ApiPrueba.Models;
using ApiPrueba.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers.Apis
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ProductoProovedorController : Controller
    {
        private readonly IUnir _context;

        public ProductoProovedorController(IUnir context)
        {
            _context = context;
        }

        // GET: api/<ProductoProovedorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoProovedor>>> GetProductoProovedors()
        {
            try
            {
                return Ok(await _context.ProductoProovedor.TodosRegistros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/<ProductoProovedorController>/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductoProovedor>> GetProductoProovedor(int Id)
        {
            try
            {
                var result = await _context.ProductoProovedor.Buscar(Id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/<ProductoProovedorController>
        [HttpPost]
        public async Task<ActionResult<ProductoProovedor>> Post([FromBody] ProductoProovedor ProductoProovedor)
        {
            try
            {
                if (ProductoProovedor == null)
                    return BadRequest();
                var ProductoProovedor1 = new ProductoProovedor();
                ProductoProovedor1 = ProductoProovedor;
                var result = await _context.ProductoProovedor.Crear(ProductoProovedor);
                _context.Save();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<ProductoProovedorController>/5
        [HttpPut]
        public async Task<ActionResult<ProductoProovedor>> Put(ProductoProovedor ProductoProovedor)
        {
            try
            {
                var ProductoProovedorToUpdate = await _context.ProductoProovedor.Buscar(ProductoProovedor.Id);
                if (ProductoProovedorToUpdate == null)
                    return NotFound($"No existe un Registro con el Id = {ProductoProovedor.Id}");
                var response = await _context.ProductoProovedor.Modificar(ProductoProovedor);
                _context.Save();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoProovedorController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ProductoProovedor>> DeleteProductoProovedor(int Id)
        {
            try
            {
                var ProductoProovedorToDelete = await _context.ProductoProovedor.Buscar(Id);
                if (ProductoProovedorToDelete == null)
                    return NotFound($"No se pudo encontrar el genero con Id = {Id}");
                await _context.ProductoProovedor.Borrar(Id);
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
