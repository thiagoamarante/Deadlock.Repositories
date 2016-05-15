using Deadlock.Repositories.DocumentDB;
using Deadlock.Repositories.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.Sample.Repositories.DocumentDB
{
    public class TestRepository : DefaultRepository<Test>, ITestRepository
    {

    }
}
