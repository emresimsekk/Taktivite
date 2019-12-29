using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taktivite.BL;
using Taktivite.DAL;
using Taktivite.Entity;
using Taktivite.Entity.ValueObject;


namespace EtkinlikUI.Controllers
{
    public class PostController : Controller
    {
        private ManagemetUser managemetUser = new ManagemetUser();
        private ManagementPostEvent managementPostEvent = new ManagementPostEvent();
        private ManagementParticipant managementParticipant = new ManagementParticipant();
        private ManagementState managementState = new ManagementState();
        private ManagementActivity managementActivity = new ManagementActivity();
        private ManagementActivityJoin managementActivityJoin = new ManagementActivityJoin();

        public ActionResult Index()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }

            // Category List Start
            List<Category> categories = new List<Category>();

            foreach (Category ct in managementPostEvent.List())
            {

                categories.Add(ct);

            }
            SelectList category = new SelectList(categories, "Id", "CategoryName");

            ViewData["categories"] = category;
            // Category List End


            // State List Start
            List<State> states = new List<State>();

            foreach (State st in managementState.List())
            {

                states.Add(st);

            }
            SelectList state = new SelectList(states, "Id", "StateName");
            ViewData["states"] = state;
            // State List End


            // Participant List Start
            List<Participant> participants = new List<Participant>();

            foreach (Participant pt in managementParticipant.List())
            {

                participants.Add(pt);

            }
            SelectList participant = new SelectList(participants, "Id", "ParticipantName");

            ViewData["participants"] = participant;
            //Participant List Start


            return View();
        }
        [HttpPost]
        public ActionResult Index(ActivityViewModel activityViewModel)
        {
            activityViewModel.UserID = CurrentSession.User.Id;


            if (ModelState.IsValid)
            {

                BusinessLayerResult<Activity> res = managementActivity.ActivityInsert(activityViewModel);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));

                }
                return RedirectToAction("ListFilter", "Post");

            }

            return View(activityViewModel);
        }

     
        public ActionResult ListFilter()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }

            // category list start
            List<Category> categories = new List<Category>();

            foreach (Category ct in managementPostEvent.List())
            {

                categories.Add(ct);

            }
            SelectList category = new SelectList(categories, "Id", "CategoryName");
                
            ViewData["categories"] = category;
            // category list end
            return View();
        }
      
        public ActionResult ActivityList(EventListViewModel eventListViewModel)
        {

            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }


            double range = eventListViewModel.RangeID / 100;
            double Latitude = Convert.ToDouble(eventListViewModel.Latitude.Replace('.', ','));
            double Longitude = Convert.ToDouble(eventListViewModel.Longitude.Replace('.', ','));
            DatabaseContext db = new DatabaseContext();

            ActivityJoin acJoin = managementActivityJoin.Find(x => x.UserID == CurrentSession.User.Id);
            

            List<Activity> activities = new List<Activity>();
            List<ActivityJoin> activityJoins = new List<ActivityJoin>();

           foreach (Activity hess in managementActivity.List())
            {
                if (hess.UserID != CurrentSession.User.Id)
                {
                    if ((Convert.ToDouble(hess.Latitude) > Latitude - range && Convert.ToDouble(hess.Latitude) < Latitude + range) &&
                        (Convert.ToDouble(hess.Longitude) > Longitude - range && Convert.ToDouble(hess.Longitude) < Longitude + range) &&
                         hess.CategoryID == eventListViewModel.CategoryID)
                    {

                      
                        foreach (ActivityJoin hes in managementActivityJoin.List())
                        {
                            if (hes.ActivityID != hess.Id)
                            {

                                activities.Add(hess);



                            }
                        }

                        

                    }


                }
            }


            return View(activities);
        }

        
        public ActionResult ActivityListJoin(Activity activity)
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }

            activity.UserID = CurrentSession.User.Id;


            Response.Write(

                activity.UserID + "  " + activity.Id
                );

            if (ModelState.IsValid)
            {

                BusinessLayerResult<ActivityJoin> res = managementActivityJoin.ActivityJoinInsert(activity);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));

                }


            }
            
            return View(activity);

        }
        //public JsonResult GetMapLocations()
        //{
        //    return Json();
        //}
        //public JsonResult GetMapLocations()
        //{
        //    DatabaseContext db = new DatabaseContext();
        //    // Markerlar için custom image kullanacağız. Bu url resmin yer aldığı       yerdir. Sizler de örnek olarak bir image url veriniz.
        //    string markerImageUrl = "samedefe.com/examples/custom_marker.png";

        //    // Verileri db'den okuyoruz. Burada "Context" için kendi Entity Frame       work context nesnenizi kullanacaksınız.
        //    var model = db.Activitys.ToList();

        //    // DB'den okuduğumuz MapLocation nesnelerini dynamic türünde bir gene       ricList'e ekliyoruz.    
        //    List<dynamic> json = new List<dynamic>();
        //    foreach (var item in model)
        //    {
        //        dynamic mark = new JObject();
        //        mark.name = item.Latitude.ToString();
        //        mark.lat = item.Longitude.ToString();
        //        json.Add(mark);
        //    }
        //    return Json(
        //         JsonConvert.SerializeObject(json), JsonRequestBehavior.AllowGet
        //    );
        //}
    }
}