using ESH_Gerenciador.ApplicationService.Facades;
using ESH_Gerenciador.ApplicationService.Views;
using ESH_Gerenciador.DataAccess;
using ESH_Gerenciador.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
