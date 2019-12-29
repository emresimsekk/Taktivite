using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taktivite.Entity;
using Taktivite.Entity.ValueObject;

namespace Taktivite.BL
{
   public class ManagementActivityJoin: ManagementBase<ActivityJoin>
    {

        public BusinessLayerResult<ActivityJoin> ActivityJoinInsert(Activity data)
        {

            BusinessLayerResult<ActivityJoin> layerResult = new BusinessLayerResult<ActivityJoin>();



            int dbActivityJoin = Insert(new ActivityJoin()
            {
                ActivityID = data.Id,
                UserID = data.UserID
                
                

            });

            if (dbActivityJoin > 0)
            {
                layerResult.Result = Find(x => x.Id == data.Id);
            }



            return layerResult;

        }

    }
}
