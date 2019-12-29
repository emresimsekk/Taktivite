using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taktivite.Entity;
using Taktivite.Entity.ValueObject;

namespace Taktivite.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Activity> Activitys { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ActivityJoin> ActivityJoins { get; set; }

        







        public DatabaseContext()
        {
            Database.SetInitializer(new ExampleData());
        }

        
    }
}
