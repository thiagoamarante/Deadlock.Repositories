using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.DocumentDB
{
    public interface TypeQuery
    {
        [JsonProperty("Type")]
        string Type { get; set; }
    }
}
