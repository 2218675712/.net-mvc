using System.Collections.Generic;
using System.Web.Mvc;
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
            bool isOkAdd;
            model.IsDelete = false;
            if (model.ID == 0)
            {
                isOkAdd = infoUserBll.Insert(model);
                if (isOkAdd)
                {
                    result.message = "添加成功";
                }
            }
            else
            {
                isOkAdd = infoUserBll.Update(model);
                if (isOkAdd)
                {
                    result.message = "更新成功";
                }
            }

            jsonResult.Data = result;
            return jsonResult;
        }

        /// <summary>
        /// 获取用户相关信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetUserInfo(int userId)
        {
            Result result = new Result();
            JsonResult jsonResult = new JsonResult();
            Info_User_BLL infoUserBll = new Info_User_BLL();
            Info_User infoUser = infoUserBll.GetModelByID(userId);
            if (infoUser != null)
            {
                result.data = infoUser;
            }

            jsonResult.Data = result;
            return jsonResult;
        }
    }
}