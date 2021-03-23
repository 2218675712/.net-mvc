using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApplication1.BLL;
using WebApplication1.Entity;
using WebApplication1.Web.Models;

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

        /// <summary>
        /// 返回一个局部视图页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddUserPartialView()
        {
            return PartialView();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUser(Info_User model)
        {
            Result result = new Result();
            JsonResult jsonResult = new JsonResult();
            Info_User_BLL infoUserBll = new Info_User_BLL();
            model.IsDelete = false;
            bool isOkAdd=infoUserBll.Insert(model);
            if (isOkAdd)
            {
                result.message = "添加成功";
            }
            jsonResult.Data = result;
            return jsonResult;

        }
    }
}