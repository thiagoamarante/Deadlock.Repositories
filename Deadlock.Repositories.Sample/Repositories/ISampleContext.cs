using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.Sample.Repositories
{
    public interface ISampleContext : IContext
    {
        ITestRepository Tests { get; }
    }
}
