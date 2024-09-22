using System.Linq.Expressions;

namespace ClientAPI.Interfaces
{
    public interface IRepo<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate);
        void Create(T obj);
        void SaveChanges();
        T? FirstOrDefault(Expression<Func<T, bool>>? predicate);
    }
}
