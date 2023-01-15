using Newtonsoft.Json;
using System.IO;

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
