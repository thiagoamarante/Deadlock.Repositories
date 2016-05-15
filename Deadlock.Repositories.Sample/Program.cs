using Deadlock.Repositories.Sample.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();
        }

        static async Task Test()
        {
            Config config = JsonConvert.DeserializeObject<Config>(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.personal.json"));

            //Registering context DocumentDB 
            Context.Register<Repositories.DocumentDB.SampleContext>();

            //Setting access configuration of DocumentDB
            IConfiguration configuration = new Deadlock.Repositories.DocumentDB.Configuration()
            {
                EndpointUrl = config.EndpointUrl,
                AuthorizationKey = config.AuthorizationKey,
                DataBaseName = config.DataBaseName,
                CollectionDefault = config.CollectionDefault
            };

            //Using abstract Context
            using (var context = Context.Create<ISampleContext>(configuration))
            {
                await context.Tests.Save(new Models.Test()
                {
                    Id = "id",
                    Name = "test"
                });
            }
        }
    }
}
