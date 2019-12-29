using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taktivite.DAL
{//singleton tasarı modeli
   public  class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lock = new object();
        public RepositoryBase()
        {
            createContext();
        }

        private static void createContext()
        {
            if (context==null)
            {
                lock (_lock)
                {
                    context = new DatabaseContext();
                }
                
            }
        }
    }
}
