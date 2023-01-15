namespace ESH_Gerenciador.ApplicationService.Views
{
    public class AlunoView : ViewBase
    {
        public string Nome { get; set; } = null!;
        public string RA { get; set; } = null!;
        public int TurmaId { get; set; }
    }

    public interface IAlunoFacade : IFacadeBase<AlunoView> { }
}
