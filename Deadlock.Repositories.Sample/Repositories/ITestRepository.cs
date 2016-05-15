using Deadlock.Repositories.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.Sample.Repositories
{
    public interface ITestRepository : IRepository
    {
        Task<Test> Get(string id);

        Task<Test> Save(Test value);

        Task Delete(string id);
    }
}
