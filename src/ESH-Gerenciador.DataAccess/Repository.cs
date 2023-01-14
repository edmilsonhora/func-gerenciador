using ESH_Gerenciador.DataAccess.Repositories;
using ESH_Gerenciador.DomainModel;
using ESH_Gerenciador.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.DataAccess
{
    public class Repository : IRepository
    {
        private readonly string conn;
        public Repository()
        {
            conn = @"Data Source=Data\Gerenciador.db; Version = 3; New = True; Compress = True;";
        }

        private IAlunoRepository _alunos;
        public IAlunoRepository Alunos => _alunos ?? (_alunos = new AlunoRepository(conn));
    }
}
