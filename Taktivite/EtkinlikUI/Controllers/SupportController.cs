using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taktivite.BL;

namespace EtkinlikUI.Controllers
{
    public class SupportController : Controller
    {
      
        public ActionResult Assistance()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }
        public ActionResult Infomation()
        {
            if (CurrentSession.User == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }


    }
}
