using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.DomainModel.Models
{
    public class Turma :EntityBase
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
    }
}
