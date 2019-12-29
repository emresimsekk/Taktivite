using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taktivite.Entity;
using Taktivite.Entity.ValueObject;

namespace Taktivite.BL
{
    public class ManagementActivity:ManagementBase<Activity>
    {
        public BusinessLayerResult<Activity> ActivityInsert(ActivityViewModel data)
        {

            BusinessLayerResult<Activity> layerResult = new BusinessLayerResult<Activity>();

           

            int dbActivity = Insert(new Activity()
            {
                CategoryID =data.CategoryID,
                UserID = data.UserID,
                StateID = data.StateID,
                ParticipantID =data.ParticipantID,
                Title = data.Title,
                Latitude = data.Latitude.Replace('.', ','),
                Longitude = data.Longitude.Replace('.', ','),
                Contents = data.Contents

            });

            if (dbActivity > 0)
            {
                layerResult.Result = Find(x => x.Id == data.Id);
            }



            return layerResult;

        }

    }
}
