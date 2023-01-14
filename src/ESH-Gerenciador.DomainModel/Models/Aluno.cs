using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.DomainModel.Models
{
    public class Aluno:EntityBase
    {
        public string Nome { get; set; } = null!;
        public string RA { get; set; } = null!;
        public int TurmaId { get; set; }
        public override void Validar()
        {
            CampoTextoObrigatorio("Nome", Nome);
            CampoTextoObrigatorio("RA", RA);
            CampoNumericoObrigatorio("Turma Id", TurmaId);
            base.Validar();
        }
    }

    public interface IAlunoRepository : IRepositoryBase<Aluno> { }
}
