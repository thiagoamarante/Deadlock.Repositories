using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Repositories
{
    public abstract class Context : IContext
    {
        #region Fields
        private static List<Type> _ContextTypes = new List<Type>();
        private Dictionary<Type, IRepository> _Repositories = new Dictionary<Type, IRepository>();
        #endregion

        public Context()
        {

        }

        public Context(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        #region Methods Abstract
        public abstract void Commit();
        #endregion

        #region Methods Public
        public void Dispose()
        {
            foreach (IRepository repository in this._Repositories.Values)
                repository.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Methods Protected
        protected T GetRepository<T>()
            where T : IRepository
        {
            if (!this._Repositories.ContainsKey(typeof(T)))
            {
                var repository = Activator.CreateInstance<T>();
                repository.Context = this;
                this._Repositories.Add(typeof(T), repository);
                return repository;
            }
            else
                return (T)this._Repositories[typeof(T)];
        }
        #endregion

        #region Methods Static
        public static void Register<T>()
            where T : Context
        {
            if (!_ContextTypes.Contains(typeof(T)))
                _ContextTypes.Add(typeof(T));
        }

        public static C Create<C>(IConfiguration configuration = null)
            where C : IContext
        {
            Type contextType = _ContextTypes.FirstOrDefault(o => typeof(C).IsAssignableFrom(o));
            if (contextType == null)
                throw new Exception("Repository context not registered");

            return (C)Activator.CreateInstance(contextType, configuration != null ? new[] { configuration } : null);
        }
        #endregion
    }
}
