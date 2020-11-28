using System.Linq;

namespace Processo.WebApi.Repositories.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(int id);
        IQueryable<T> FindAll();
        void Delete(T item);
        void Edit(T item);
        void Save(T item);
    }
}
