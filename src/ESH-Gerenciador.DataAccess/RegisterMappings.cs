using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using ESH_Gerenciador.DataAccess.Mappings;

namespace ESH_Gerenciador.DataAccess
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new AlunoMap());
                config.ForDommel();
            });
        }
    }
}
