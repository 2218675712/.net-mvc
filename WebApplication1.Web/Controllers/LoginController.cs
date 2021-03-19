using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using WebApplication1.BLL;
using WebApplication1.Entity;
using WebApplication1.Web.Models;

namespace WebApplication1.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Info_User_Model infoUserModel1 = new Info_User_Model
            {
                ID = 1,
                UserName = "小米",
                PassWord = "121212",
                Phone = "110",
                Sex = true
            };
            Info_User_Model infoUserModel2 = new Info_User_Model
            {
                ID = 2,
                UserName = "小红",
                PassWord = "4564864",
                Phone = "120",
                Sex = false
            };
            List<Info_User_Model> infoUserModels = new List<Info_User_Model>();
            infoUserModels.Add(infoUserModel1);
            infoUserModels.Add(infoUserModel2);
            ViewData["userList"] = infoUserModels;
            return View(new Info_User_Model());
        }

        /// <summary>
        /// 利用用户名进行登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLoginByPhone(Info_User_Model model)
        {
            JsonResult jr = new JsonResult();
            Object obj = null;
            Info_User_BLL infoUserBll = new Info_User_BLL();
            Info_User infoUser = infoUserBll.Login(model.Phone, model.PassWord);
            if (infoUser != null)
            {
                obj = new {code = "200", message = "登录成功", type = "success"};
            }
            else
            {
                obj = new {code = "200", message = "登录失败,请检查用户名和密码", type = "error"};
            }

            jr.Data = obj;
            return jr;
        }
    }
}