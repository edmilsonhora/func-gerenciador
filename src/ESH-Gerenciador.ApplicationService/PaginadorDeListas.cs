using ESH_Gerenciador.ApplicationService.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.ApplicationService
{
    public class PaginadorDeListas<T> where T : ViewBase
    {
        private PaginadorDeListas() { }
        public PaginadorDeListas(List<T> lista, long totalRegistros)
        {
            Lista = lista;
            TotalRegistros = totalRegistros;
        }
        public List<T> Lista { get; }
        public long TotalRegistros { get; }

    }
}
