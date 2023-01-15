using Dapper;
using ESH_Gerenciador.DomainModel.Models;
using System.Data;
using System.Data.SQLite;
using static Dapper.SqlMapper;

namespace ESH_Gerenciador.DataAccess.Repositories
{
    internal class AlunoRepository : AbstractRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(string conn) : base(conn)
        {
        }

        public async Task<int> ObterQtdAlunosPorTurmaAsync(int turmaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@TurmaId", turmaId, DbType.Int32);

            using (var db = new SQLiteConnection(Connection))
            {
                return await db.ExecuteScalarAsync<int>("SELECT Count(Id) FROM Alunos WHERE TurmaId=@TurmaId", parametros, commandType: CommandType.Text);
            }
        }
    }
}
