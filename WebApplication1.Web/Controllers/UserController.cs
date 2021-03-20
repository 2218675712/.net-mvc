using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BLL;
using WebApplication1.Entity;

namespace WebApplication1.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            ViewData["list"] = GetList();
            return View();
        }

        public List<Info_User> GetList()
        {
            Info_User_BLL infoUserBll = new Info_User_BLL();
            var list = infoUserBll.GetList();
            return list;
        }
    }
}