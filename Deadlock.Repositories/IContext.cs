using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories
{
    public interface IContext : IDisposable
    {
        IConfiguration Configuration { get; set; }

        void Commit();
    }
}
