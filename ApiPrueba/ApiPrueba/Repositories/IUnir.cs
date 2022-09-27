using ApiPrueba.ConText;
using ApiPrueba.Models;

namespace ApiPrueba.Repositories
{
    public interface IUnir
    {
        public IDinamicoRepsotirio<Producto> Producto { get; }

        public IDinamicoRepsotirio<Proovedor> Proovedor { get; }

        public IDinamicoRepsotirio<ProductoProovedor> ProductoProovedor { get;}

        public void Save();
    } 
}
