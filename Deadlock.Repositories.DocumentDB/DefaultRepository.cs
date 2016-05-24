using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.DocumentDB
{
    public abstract class DefaultRepository<T> : Repository
    {
        public virtual async Task<T> Save(T value)
        {
            return await base.Save<T>(value);
        }

        new public virtual async Task Delete(string id)
        {
            await base.Delete(id);

        }

        public virtual async Task<T> Get(string id)
        {
            return await base.Get<T>(id);
        }

        public virtual async Task<IEnumerable<T>> List(System.Linq.Expressions.Expression<Func<T, bool>> where = null)
        {
            return await base.List<T>(where);
        }
    }
}
