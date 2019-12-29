using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;



namespace Taktivite.DAL
{
    public class Repository<T> :RepositoryBase,IData<T> where T:class
    {
        private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = context.Set<T>();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
          
                return _objectSet.FirstOrDefault(where);
            
          
        }

        public int Insert(T obj)
        {
            // date eklerken onje dönüşütme
            //EntityBase entity = obj as EntityBase;
            //DateTime now = DateTime.Now;
            // entity.Date = now;
            
            _objectSet.Add(obj);
            return Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Save()
        {
          
                return context.SaveChanges();

           
        
 
        }

        public int Update(T obj)
        {
            // date eklerken onje dönüşütme
            //EntityBase entity = obj as EntityBase;
            //DateTime now = DateTime.Now;
            // entity.Date = now;

            return Save();
        }
    }
}
