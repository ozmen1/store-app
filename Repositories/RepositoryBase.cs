using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    //base class'ın new'lenmesini istemediğimiz için abstract olarak yarattık.
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new() //tipi kısıtlayan tanımlar
    {
        protected readonly RepositoryContext _context; //devraldığımız class'larda context'e ihtiyaç olursa kullanabilmek için private yerine protected yaptık.

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().Where(expression).SingleOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }
    }
}