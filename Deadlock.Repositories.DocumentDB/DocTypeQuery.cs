using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.DocumentDB
{
    public interface DocTypeQuery
    {
        [JsonProperty("DocType")]
        string DocType { get; set; }
    }
}
