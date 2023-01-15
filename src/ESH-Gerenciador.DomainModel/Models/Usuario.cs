using ESH_Gerenciador.Common__Place.Helpers;

namespace ESH_Gerenciador.DomainModel.Models
{
    public class Usuario : EntityBase
    {
        public string NomeCompleto { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string ConfirmaSenha { get; set; } = null!;
        public string Perfil { get; set; } = null!;
        public bool Ativo { get; set; }


        public override void Validar()
        {
            CampoTextoObrigatorio("Nome Completo", NomeCompleto);
            CampoTextoObrigatorio("User Name", UserName);
            CampoTextoObrigatorio("Email", Email);
            CampoTextoObrigatorio("Senha", Senha);
            CampoTextoObrigatorio("Confirma Senha", ConfirmaSenha);
            if (this.Id.Equals(0))
            {
                if (Senha != ConfirmaSenha)
                    RegrasQuebradas.Append($"Senha não confere!{Environment.NewLine}");
                else
                {
                    Salt = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                    Senha = HelperAesCrypto.Encrypt(Senha, Salt);
                }
            }
            base.Validar();
        }


        public void AutenticarPor(string senha)
        {
            if (Id == 0)
                throw new ApplicationException("Usuário não existe!");

            if (this.Senha != HelperAesCrypto.Encrypt(senha, Salt))
                throw new ApplicationException("Usuário ou Senha Incorreto!");

            if (!Ativo)
                throw new ApplicationException("Usuário Inativo!");
        }

    }
}
