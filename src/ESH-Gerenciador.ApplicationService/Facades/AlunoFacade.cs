using ESH_Gerenciador.ApplicationService.Adapters;
using ESH_Gerenciador.ApplicationService.Views;
using ESH_Gerenciador.DomainModel;
using ESH_Gerenciador.DomainModel.Models;

namespace ESH_Gerenciador.ApplicationService.Facades
{
    internal class AlunoFacade : IAlunoFacade
    {
        private readonly IRepository _repository;

        public AlunoFacade(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task ExcluirAsync(int id)
        {
            var obj = await _repository.Alunos.ObterPorIdAsync(id);
            if (obj is not null)
            {
                await _repository.Alunos.ExcluirAsync(obj);
            }
        }

        public async Task<List<AlunoView>> ObterPaginadoAsync(int pageIndex, int pageSize)
        {
            var res = await _repository.Alunos.ObterPaginadoAsync(pageIndex, pageSize);
            return res.ConvertToView();
        }

        public async Task<AlunoView> ObterPorIdAsync(int id)
        {
            var res = await _repository.Alunos.ObterPorIdAsync(id);
            return res.ConvertToView();
        }

        public async Task<List<AlunoView>> ObterTodosAsync()
        {
            var res = await _repository.Alunos.ObterTodosAsync();
            return res.ConvertToView();
        }

        public async Task SalvarAsync(AlunoView view)
        {
            var obj = view.Id == 0 ? new Aluno() : _repository.Alunos.ObterPorIdAsync(view.Id).Result;
            obj.Nome = view.Nome;
            obj.RA = view.RA;
            obj.TurmaId = view.TurmaId;

            obj.Validar();

            await _repository.Alunos.SalvarAsync(obj);
        }
    }
}
