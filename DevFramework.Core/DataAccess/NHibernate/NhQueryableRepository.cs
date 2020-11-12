using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T>
        where T : class, IEntity, new()
    {
        private NHibernateHelper _nHihabernateHelper;

        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHihabernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _nHihabernateHelper.OpernSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}
