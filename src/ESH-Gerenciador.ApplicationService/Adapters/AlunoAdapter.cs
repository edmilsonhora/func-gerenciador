using ESH_Gerenciador.ApplicationService.Views;
using ESH_Gerenciador.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.ApplicationService.Adapters
{
    internal static class AlunoAdapter
    {
        public static List<AlunoView> ConvertToView(this IEnumerable<Aluno> list)
        {
            var novaLista = new List<AlunoView>();
            foreach (var item in list)
            {
                novaLista.Add(item.ConvertToView());
            }
            return novaLista;
        }

        public static AlunoView ConvertToView(this Aluno item)
        {
            if (item is null) return new AlunoView();

            return new AlunoView
            {
                Id = item.Id,
                Nome = item.Nome,
                RA = item.RA,
                TurmaId = item.TurmaId,
            };
        }
    }
}
