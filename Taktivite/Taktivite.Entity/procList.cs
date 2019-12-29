using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taktivite.Entity
{
    public partial class procList :DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.OrnekSP",
                p => new
                {

                },
                body:
                    @"Select * from Activity"
            );

        }

        public override void Down()
        {
            DropStoredProcedure("dbo.OrnekSP");
        }

      

    }
}
