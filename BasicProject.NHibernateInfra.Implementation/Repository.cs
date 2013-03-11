using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.Infra.Interface;
using NHibernate;
using NHibernate.Linq;

namespace BasicProject.NHibernateInfra.Implementation {
    public class Repository<T> : ILongKeyedRepository<T> where T : class{
        private readonly ISession _session;

        public Repository(ISession session) {
            _session = session;
        }

        public T FindBy(long id) {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All() {
            return _session.Query<T>();
        }

        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
            throw new NotImplementedException();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
            return All().Where(expression).AsQueryable();
        }

        public void Add(T entity) {
            _session.Save(entity);
        }

        public void Add(IEnumerable<T> entities) {
            foreach (var entity in entities) {
                _session.Save(entity);    
            }
        }

        public void Update(T entity) {
            _session.Update(entity);
        }

        public void Delete(T entity) {
            _session.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities) {
            foreach (var entity in entities) {
                _session.Save(entity);
            }
        }
    } //end class
}
