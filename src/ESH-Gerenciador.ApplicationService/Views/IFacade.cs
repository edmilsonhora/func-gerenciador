using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.ApplicationService.Views
{
    public interface IFacade
    {
        IAlunoFacade Alunos { get; }    
    }
}
