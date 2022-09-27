namespace ApiPrueba.Repositories
{
    public interface IDinamicoRepsotirio<TEntity>
    {
       Task Borrar(int id);

       Task<IEnumerable<TEntity>> TodosRegistros();

        Task<TEntity> Buscar(int? id);
        Task<TEntity> Modificar(TEntity data);
        Task<TEntity> Crear(TEntity id);

        Task save();
    }
}
