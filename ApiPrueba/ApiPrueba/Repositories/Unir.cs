using ApiPrueba.ConText;
using ApiPrueba.Models;

namespace ApiPrueba.Repositories
{
    public class Unir:IUnir
    {
        private AppDbContext _dbContext;

        private IDinamicoRepsotirio<Producto> _producto;

        private IDinamicoRepsotirio<Proovedor> _proovedor;
        private IDinamicoRepsotirio<ProductoProovedor> _productoProovedor;

        public Unir(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDinamicoRepsotirio<Producto> Producto
        {
            get
            {
                return _producto == null ?
                    _producto = new DinamicoRepositorio<Producto>(_dbContext) :
                    _producto;
            }
        }

        public IDinamicoRepsotirio<Proovedor> Proovedor
        {
            get
            {
                return _proovedor == null ?
                    _proovedor = new DinamicoRepositorio<Proovedor>(_dbContext) :
                    _proovedor;
            }
        }

        public IDinamicoRepsotirio<ProductoProovedor> ProductoProovedor
        {
            get
            {
                return _productoProovedor == null ?
                    _productoProovedor = new DinamicoRepositorio<ProductoProovedor>(_dbContext) :
                    _productoProovedor;
            }
        }

        

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
