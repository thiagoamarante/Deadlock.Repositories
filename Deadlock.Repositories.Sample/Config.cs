using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.Sample
{
    public class Config
    {
        public string EndpointUrl { get; set; }

        public string DataBaseName { get; set; }

        public string CollectionDefault { get; set; }

        public string AuthorizationKey { get; set; }
    }
}
