using ClientAPI.Database;
using ClientAPI.Interfaces;
using ClientAPI.Models;
using System.Linq.Expressions;

namespace ClientAPI.Services.BaseClass
{
    public class RepoService<T> : IRepo<T> where T : class
    {
        public readonly ClientDbContext _context;

        public RepoService(ClientDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            if (predicate == null)
                return _context.Set<T>();

            return _context.Set<T>().Where(predicate);
        }

        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T? FirstOrDefault(Expression<Func<T, bool>>? predicate)
        {
            if (predicate == null)
                return _context.Set<T>().FirstOrDefault();

            return _context.Set<T>().FirstOrDefault(predicate);
        }
    }
}
