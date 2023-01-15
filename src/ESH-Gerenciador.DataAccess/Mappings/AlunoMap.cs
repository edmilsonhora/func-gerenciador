using Dapper.FluentMap.Dommel.Mapping;
using ESH_Gerenciador.DomainModel.Models;

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
