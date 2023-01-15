using ESH_Gerenciador.DomainModel.Models;

namespace ESH_Gerenciador.DomainModel
{
    public interface IRepository
    {
        IAlunoRepository Alunos { get; }
    }
}
