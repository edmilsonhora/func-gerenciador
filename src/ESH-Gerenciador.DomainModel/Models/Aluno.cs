namespace ESH_Gerenciador.DomainModel.Models
{
    public class Aluno : EntityBase
    {
        public string Nome { get; set; } = null!;
        public string RA { get; set; } = null!;
        public int TurmaId { get; set; }
        public Turma Turma { get; set; } = null!;
        public override void Validar()
        {
            CampoTextoObrigatorio("Nome", Nome);
            CampoTextoObrigatorio("RA", RA);
            CampoNumericoObrigatorio("Turma Id", TurmaId);
            base.Validar();
        }

        public void TurmaAddAluno()
        {
            if (Id == 0)
            {
                Turma.AddAluno();
            }
        }

        public void TurmaRemoveAluno()
        {
            Turma.RemoveAluno();
        }
    }

    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {

        Task<int> ObterQtdAlunosPorTurmaAsync(int turmaId);
    }
}
