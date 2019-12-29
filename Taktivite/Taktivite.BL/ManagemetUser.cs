using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taktivite.Entity;
using Taktivite.Entity.ValueObject;

namespace Taktivite.BL
{
    public class ManagemetUser : ManagementBase<User>
    {

        public BusinessLayerResult<User> Login(LoginViewModel data)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = Find(x => x.UserName == data.UserName && x.UserPassword == data.UserPassword);

            if (res.Result != null)
            {

            }
            else
            {
                res.Errors.Add("Kullanıcı Adı veya Şifre Hatalı");
            }


            return res;

        }


        public BusinessLayerResult<User> Register(RegisterViewModel data)
        {
            
           User user = Find(x => x.UserName ==data.UserName);

            BusinessLayerResult<User> layerResult = new BusinessLayerResult<User>();

            if (user != null)
            {
                if (user.UserName == data.UserName)
                {
                    layerResult.Errors.Add("Böyle Bir Kullanıcı Adı Kullanılmamaktadır");
                }
            }
            else
            {
                int dbResultUser = Insert(new User()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    UserName = data.UserName,
                    UserPassword = data.UserPassword,
                    UserImagesName = "ProfilResmi.png"

                });

                if (dbResultUser > 0)
                {
                    layerResult.Result = Find(x => x.UserName == data.UserName);
                }
            }


            return layerResult;

        }

        public   BusinessLayerResult<User> GetUserById(int id)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = Find(x => x.Id == id);

            if (res.Result == null)
            {
                //res.Errors.Add("Böyle Bir Kullanıcı Adı Kullanılmamaktadır");
            }

            return res;
        }


    }

}
