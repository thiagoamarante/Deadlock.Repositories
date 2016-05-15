using Deadlock.Repositories.DocumentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.Sample.Repositories.DocumentDB
{
    public class SampleContext : DocumentDBContext, ISampleContext
    {
        public SampleContext(Configuration configuration)
            :base(configuration)            
        {

        }

        public ITestRepository Tests { get { return this.GetRepository<TestRepository>(); } }
    }
}
