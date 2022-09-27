using ApiPrueba.ConText;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.Repositories
{
    public class DinamicoRepositorio<TEntity> : IDinamicoRepsotirio<TEntity> where TEntity : class
    {
        private AppDbContext _appDbContext;
        private DbSet<TEntity> _dbset;
        public DinamicoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbset = appDbContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> TodosRegistros() => await _dbset.ToListAsync();

        public async Task Borrar(int id)
        {
            var DatosBorrar =await _dbset.FindAsync(id);
            _dbset.Remove(DatosBorrar);
        }

        public async Task<TEntity> Crear(TEntity data)
        {
            var result = await _dbset.AddAsync(data);
            return result.Entity;
        }

        public async Task<TEntity> Buscar(int? id) => await _dbset.FindAsync(id);

        public async Task<TEntity> Modificar(TEntity data)
        {
            _dbset.Attach(data);
            _appDbContext.Entry(data).State = EntityState.Modified;
            return data;
        }

        public async Task save() =>await _appDbContext.SaveChangesAsync();

        
    }
}
