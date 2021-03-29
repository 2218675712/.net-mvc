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
            return View();
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

        /// <summary>
        /// 通用搜索
        /// </summary>
        /// <param name="_search"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Search(string _search)
        {
            Result result = new Result();
            JsonResult jsonResult = new JsonResult();
            Info_User_BLL infoUserBll = new Info_User_BLL();
            List<Info_User> infoUsers = infoUserBll.GetList()
                .FindAll(x => x.UserName.Contains(_search) || x.Phone.Contains(_search));
            result.data = infoUsers;
            jsonResult.Data = result;
            return jsonResult;
        }
/// <summary>
/// 分页接口
/// </summary>
/// <param name="pageNumber">当前页</param>
/// <param name="pageSize">页码</param>
/// <param name="sortOrder">排序(升序or降序)</param>
/// <returns></returns>
[HttpPost]
        public JsonResult Pagination(int pageNumber,int pageSize,string sortOrder)
        {
            Result result = new Result();
            JsonResult jsonResult = new JsonResult();
            Info_User_BLL infoUserBll = new Info_User_BLL();
            int count = infoUserBll.GetEntitiesCount();
            IEnumerable<Info_User> infoUsers=infoUserBll.GetEntitiesForPaging(pageNumber, pageSize, sortOrder);
            result.data = new {infoUsers,count};
            jsonResult.Data = result;
            return jsonResult;
        }
    }
}