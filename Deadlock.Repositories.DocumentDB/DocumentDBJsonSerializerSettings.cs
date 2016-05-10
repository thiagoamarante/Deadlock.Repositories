using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.DocumentDB
{
    public class DocumentDBJsonSerializerSettings : JsonSerializerSettings
    {
        public string PropertyType { get; set; } = "Type";

        public bool CreatePropertyType { get; set; } = true;
    }
}
