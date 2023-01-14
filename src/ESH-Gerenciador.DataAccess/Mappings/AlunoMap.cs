using Dapper.FluentMap.Dommel.Mapping;
using ESH_Gerenciador.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.DataAccess.Mappings
{
    internal class AlunoMap : DommelEntityMap<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Alunos");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.Nome).ToColumn("Nome");
            Map(x => x.RA).ToColumn("RA");
            Map(x => x.TurmaId).ToColumn("TurmaId");
        }
    }
}
