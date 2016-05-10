using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.DocumentDB
{
    public abstract class DocumentDBContext : Context
    {
        public DocumentDBContext(Configuration configuration)
            : base(configuration)
        {
            this.Client = new DocumentClient(new Uri(this.Configuration.EndpointUrl), this.Configuration.AuthorizationKey);
            this.SerializerSettings = new DocumentDBJsonSerializerSettings()
            {
                ContractResolver = new CustomNamesContractResolver(),
                TypeNameHandling = TypeNameHandling.Auto                
            };
        }

        #region Properties
        public DocumentClient Client { get; private set; }

        public DocumentDBJsonSerializerSettings SerializerSettings { get; set; }

        new public Configuration Configuration { get { return base.Configuration as Configuration; } }
        #endregion

        #region Methods
        public JObject ToJObject(object value)
        {
            JObject obj = JObject.FromObject(value, Newtonsoft.Json.JsonSerializer.Create(this.SerializerSettings));
            if(this.SerializerSettings.CreatePropertyType)
                obj.Add(this.SerializerSettings.PropertyType, value.GetType().Name.ToLower());
            return obj;
        }

        public override void Commit()
        {

        }
        #endregion
    }
}
