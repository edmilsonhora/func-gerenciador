namespace ESH_Gerenciador.ApplicationService.Views
{
    public interface IFacadeBase<T> where T : ViewBase
    {
        Task SalvarAsync(T view);
        Task ExcluirAsync(int id);
        Task<T> ObterPorIdAsync(int id);
        Task<List<T>> ObterPaginadoAsync(int pageIndex, int pageSize);
        Task<List<T>> ObterTodosAsync();
    }
}
