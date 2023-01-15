namespace ESH_Gerenciador.DomainModel.Models
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task SalvarAsync(T entity);
        Task ExcluirAsync(T entity);
        Task<T> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ObterPaginadoAsync(int pageIndex, int pageSize);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<long> CountAsync();
    }
}
