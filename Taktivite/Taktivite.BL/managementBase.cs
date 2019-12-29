using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taktivite.DAL;

namespace Taktivite.BL
{
    public class ManagementBase<T> : IData<T> where T:class
    {
        private Repository<T> Repo = new Repository<T>();
        public virtual int Delete(T obj)
        {
            return Repo.Delete(obj);
        }

        public virtual T Find(Expression<Func<T, bool>> where)
        {
            return Repo.Find(where);
        }

        public virtual int Insert(T obj)
        {
            return Repo.Insert(obj);
        }

        public virtual List<T> List()
        {
            return Repo.List();
        }

        public virtual List<T> List(Expression<Func<T, bool>> where)
        {
            return Repo.List(where);
        }

        public virtual int Save()
        {
            return Repo.Save();
        }

        public virtual int Update(T obj)
        {
            return Repo.Update(obj);
        }
    }
}
