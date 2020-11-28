using Microsoft.EntityFrameworkCore;
using Processo.WebApi.Data;
using Processo.WebApi.Repositories.Interface;
using System;
using System.Linq;

namespace Processo.WebApi.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private ContextDb _context;

        public BaseRepository(ContextDb context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }
        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void Edit(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Save(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
