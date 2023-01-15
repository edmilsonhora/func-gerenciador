using ESH_Gerenciador.ApplicationService.Facades;
using ESH_Gerenciador.ApplicationService.Views;
using ESH_Gerenciador.DataAccess;
using ESH_Gerenciador.DomainModel;

namespace ESH_Gerenciador.ApplicationService
{
    public class Facade : IFacade
    {
        private IRepository repository;
        public Facade()
        {
            RegisterMappings.Register();
            repository = new Repository();
        }

        private IAlunoFacade _alunos;
        public IAlunoFacade Alunos => _alunos ?? (_alunos = new AlunoFacade(repository));
    }
}
