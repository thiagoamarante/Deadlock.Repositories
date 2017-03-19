using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories.DocumentDB
{
    public abstract class Repository : IRepository
    {
        public Context Context { get; set; }

        protected DocumentDBContext DocumentDBContext { get { return this.Context as DocumentDBContext; } }

        protected async Task<T> Save<T>(T value)
        {           
            var response = await this.DocumentDBContext.Client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(this.DocumentDBContext.Configuration.DataBaseName, this.DocumentDBContext.Configuration.CollectionDefault), this.DocumentDBContext.ToJObject(value));
            return JsonConvert.DeserializeObject<T>(response.Resource.ToString(), this.DocumentDBContext.SerializerSettings);
        }

        protected async Task Delete(string id)
        {
            await this.DocumentDBContext.Client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(this.DocumentDBContext.Configuration.DataBaseName, this.DocumentDBContext.Configuration.CollectionDefault, id));

        }

        protected async Task<T> Get<T>(string id)
        {
            T result = default(T);
            try
            {
                var response = await this.DocumentDBContext.Client.ReadDocumentAsync(UriFactory.CreateDocumentUri(this.DocumentDBContext.Configuration.DataBaseName, this.DocumentDBContext.Configuration.CollectionDefault, id));
                result = JsonConvert.DeserializeObject<T>(response.Resource.ToString(), this.DocumentDBContext.SerializerSettings);
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {

                }
            }
            return result;
        }

        protected async Task<FeedResponse<T>> List<T>(System.Linq.Expressions.Expression<Func<T, bool>> where = null)
        {
            var query = this.DocumentDBContext.Client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(this.DocumentDBContext.Configuration.DataBaseName, this.DocumentDBContext.Configuration.CollectionDefault))
                .Where(o => ((DocTypeQuery)o).DocType == this.DocumentDBContext.TypeName(typeof(T)));

            if (where != null)
                query = query.Where(where);

            var result = await query
                .AsDocumentQuery()            
                .ExecuteNextAsync<T>();
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
