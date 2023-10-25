using proj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proj1.Controllers
{
    public class LoginController : Controller
    {
        agri1Entities Db = new agri1Entities();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public JsonResult SaveData(string n,string ad,string m,string e, string p)
        {
            bool res = false;
            try
            {
                Registration_tbl2 reg = new Registration_tbl2();
                tbl_Login lg = new tbl_Login();
                reg.Name = n;
                reg.Address = ad;
                reg.Mobile = m;
                reg.Email = e;
                lg.email = e;
                reg.Password = p;
                lg.password = p;
                Db.Registration_tbl2.Add(reg);
                Db.tbl_Login.Add(lg);
                Db.SaveChanges();
                res = true;
            }catch(Exception ex)
            {

            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckData( string email, string pass)
        {
            //Login
            bool res = false;
            var user = Db.tbl_Login.FirstOrDefault(x => x.email.Equals(email) && x.password.Equals(pass));
            if (user != null)
            {
                res = true;
            }
            
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}