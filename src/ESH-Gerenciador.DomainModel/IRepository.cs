using ESH_Gerenciador.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.DomainModel
{
    public interface IRepository
    {
        IAlunoRepository Alunos { get; }
    }
}
