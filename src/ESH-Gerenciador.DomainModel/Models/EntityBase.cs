using System.Text;

namespace ESH_Gerenciador.DomainModel.Models
{
    public abstract class EntityBase
    {
        protected StringBuilder RegrasQuebradas = new StringBuilder();
        public int Id { get; set; }

        public virtual void Validar()
        {
            if (RegrasQuebradas.Length > 0)
            {
                throw new ApplicationException(RegrasQuebradas.ToString());
            }
        }

        protected void CampoTextoObrigatorio(string nomeDoCampo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                RegrasQuebradas.Append($"O campo {nomeDoCampo} é obrigatório.{Environment.NewLine}");
            }
        }

        protected void CampoNumericoObrigatorio(string nomeDoCampo, int valor)
        {
            if (valor < 1)
            {
                RegrasQuebradas.Append($"O campo {nomeDoCampo} é obrigatório.{Environment.NewLine}");
            }
        }
    }
}
