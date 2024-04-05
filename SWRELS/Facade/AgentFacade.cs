using NHibernate;
using NHibernate.Criterion;
using SWRELS.Domain;

namespace SWRELS.Facade
{
    public partial class SwrelsFacade
    {
        public Agent GetAgentByLogin(string userName, string password)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Agent));
            criteria.Add(Restrictions.Eq("LoginName", userName));
            criteria.Add(Restrictions.Eq("LoginPass", password));
            return criteria.UniqueResult<Agent>();
        }
    }
}