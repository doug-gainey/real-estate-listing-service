using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SWRELS.Domain;

namespace SWRELS.Facade
{
    public partial class SwrelsFacade : IDisposable
    {
        private static ISession Session
        {
            get
            {
                return NHibernateHelper.GetCurrentSession();
            }
        }

        public T Get<T>(object entityId)
        {
            return Session.Get<T>(entityId);
        }

        public IList<T> GetList<T>()
        {
            return Session.CreateCriteria(typeof(T)).List<T>();
        }

        public Reference GetReference(string what)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Reference));
            criteria.Add(Restrictions.Eq("What", what));
            return criteria.UniqueResult<Reference>();
        }

        public void Save(Object entity)
        {
            if (entity == null) return;
            Session.SaveOrUpdate(entity);
        }

        public void Delete(Object entity)
        {
            if (entity == null) return;
            Session.Delete(entity);
        }

        #region IDisposable Members

        public void Dispose()
        {
            //Session.Flush();
            NHibernateHelper.CloseSession();
        }

        #endregion
    }
}