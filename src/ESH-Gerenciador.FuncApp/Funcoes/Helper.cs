using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_Gerenciador.FuncApp.Funcoes
{
    static class Helper
    {
        public static T ConvertToView<T>(Stream stream)
        {
            string requestBody = new StreamReader(stream).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(requestBody);
        }
    }
}
