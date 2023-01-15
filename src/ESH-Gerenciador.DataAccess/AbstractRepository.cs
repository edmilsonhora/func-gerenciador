using Dommel;
using ESH_Gerenciador.DomainModel.Models;
using System.Data.SQLite;

namespace ESH_Gerenciador.DataAccess
{
    public abstract class AbstractRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        public AbstractRepository(string conn)
        {
            Connection = conn;
        }

        public string Connection { get; }

        public async Task<long> CountAsync()
        {
            using (var db = new SQLiteConnection(Connection))
            {
                return await db.CountAsync<T>();
            }
        }

        public async Task ExcluirAsync(T entity)
        {
            using (var db = new SQLiteConnection(Connection))
            {
                await db.DeleteAsync(entity);
            }
        }

        public async Task<IEnumerable<T>> ObterPaginadoAsync(int pageIndex, int pageSize)
        {
            using (var db = new SQLiteConnection(Connection))
            {
                return await db.GetPagedAsync<T>(pageIndex, pageSize);
            }
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            using (var db = new SQLiteConnection(Connection))
            {
                return await db.GetAsync<T>(id);
            }
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            using (var db = new SQLiteConnection(Connection))
            {
                return await db.GetAllAsync<T>();
            }
        }

        public async Task SalvarAsync(T entity)
        {
            using (var db = new SQLiteConnection(Connection))
            {
                if (entity.Id == 0)
                {
                    await db.InsertAsync<T>(entity);
                }
                else
                {
                    await db.UpdateAsync<T>(entity);
                }
            }
        }
    }
}
