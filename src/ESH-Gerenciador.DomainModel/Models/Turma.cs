namespace ESH_Gerenciador.DomainModel.Models
{
    public class Turma : EntityBase
    {
        public string Nome { get; set; } = null!;
        public int QtdMaxAlunos { get; set; }
        public int QtdAtualAlunos { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio("Nome", Nome);
            CampoNumericoObrigatorio("Qtd Max Alunos", QtdMaxAlunos);
            base.Validar();
        }

        public void AddAluno()
        {
            if (QtdAtualAlunos < QtdMaxAlunos)
            {
                QtdAtualAlunos++;
            }
            else
            {
                throw new ApplicationException($"A turma {Nome}, atingiu a quantidade máxima de alunos permitida.{Environment.NewLine}");
            }
        }

        public void RemoveAluno()
        {
            if (QtdAtualAlunos > 0)
                QtdAtualAlunos--;
        }

    }
}
