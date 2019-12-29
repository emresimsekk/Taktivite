using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taktivite.BL;
using Taktivite.DAL;
using Taktivite.Entity;

namespace EtkinlikUI.Controllers
{
    public class ProfileController : Controller
    {
                
        ManagementActivity managementActivity = new ManagementActivity();
        ManagementActivityJoin managementActivityJoin = new ManagementActivityJoin();
        ManagemetUser managemetUser = new ManagemetUser();

        public ActionResult Index()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ActivityJoin acJoin=managementActivityJoin.Find(x => x.UserID == CurrentSession.User.Id);

            


            List<Activity> activities = new List<Activity>();
            List<ActivityJoin> activityJoins = new List<ActivityJoin>();

            foreach (ActivityJoin hes in managementActivityJoin.List())
            {
                if (hes.UserID == CurrentSession.User.Id )
                {
                    activityJoins.Add(hes);

                    foreach (Activity hess in managementActivity.List())
                    {
                        if (hess.Id == hes.ActivityID)
                        {
                            activities.Add(hess);
                           
                        }
                    }

                   
                }
            }




            return View(activities);
        }
        public ActionResult PleaseActivity()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }
            Activity acList = managementActivity.Find(x => x.UserID == CurrentSession.User.Id);

            List<Activity> activities = new List<Activity>();

            foreach (Activity hes in managementActivity.List())
            {
                if (hes.UserID == CurrentSession.User.Id )
                {
                    activities.Add(hes);
                }
            }

            return View(activities);
        }


        public ActionResult MyProfile()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }
            User user = managemetUser.Find(x => x.Id == CurrentSession.User.Id);

            List<User> users = new List<User>();

            foreach( User hes in managemetUser.List())
            {
                if (hes.Id == CurrentSession.User.Id)
                {
                    users.Add(hes);
                }
            }

            return View(users);
        }
    }
}
