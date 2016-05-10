using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories
{
    public interface IRepository : IDisposable
    {
        Context Context { get; set; }
    }
}
