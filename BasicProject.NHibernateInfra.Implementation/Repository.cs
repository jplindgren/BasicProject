using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.Infra.Interface;
using NHibernate;
using NHibernate.Linq;

namespace BasicProject.NHibernateInfra.Implementation {
    public abstract class Repository<T> : ILongKeyedRepository<T> where T : class{
        //private readonly ISession _session;

        //public Repository(ISession session) {
        //    _session = session;
        //}

        private ISessionFactory sessionFactory;
        /// <summary>
        /// Session factory for sub-classes.
        /// </summary>
        public ISessionFactory SessionFactory {
            protected get { return sessionFactory; }
            set { sessionFactory = value; }
        }

        /// <summary>
        /// Get's the current active session. Will retrieve session as managed by the 
        /// Open Session In View module if enabled.
        /// </summary>
        public ISession CurrentSession {
            get { return SessionFactory.GetCurrentSession(); }
        }


        public T FindBy(long id) {
            return CurrentSession.Get<T>(id);
        }

        public IQueryable<T> All() {
            return CurrentSession.Query<T>();
        }

        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
            throw new NotImplementedException();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
            return All().Where(expression).AsQueryable();
        }

        public void Add(T entity) {
            CurrentSession.Save(entity);
        }

        public void Add(IEnumerable<T> entities) {
            foreach (var entity in entities) {
                CurrentSession.Save(entity);    
            }
        }

        public void Update(T entity) {
            CurrentSession.Update(entity);
        }

        public void Delete(T entity) {
            CurrentSession.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities) {
            foreach (var entity in entities) {
                CurrentSession.Save(entity);
            }
        }
    } //end class
}
