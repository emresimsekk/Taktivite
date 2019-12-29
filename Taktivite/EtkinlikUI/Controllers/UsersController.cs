using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taktivite.BL;
using Taktivite.Entity;
using Taktivite.Entity.ValueObject;

namespace EtkinlikUI.Controllers
{
    public class UsersController : Controller
    {
        private ManagemetUser managementUser = new ManagemetUser();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                BusinessLayerResult<User> res = managementUser.Login(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }

                Session["login"] = res.Result;
                return RedirectToAction("Index", "Profile");
            }


            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                BusinessLayerResult<User> res = managementUser.Register(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                return RedirectToAction("Login", "Users");

            }

            return View(model);
        }
    }
}
