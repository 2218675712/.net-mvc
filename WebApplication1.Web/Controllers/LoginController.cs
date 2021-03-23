using System.Web.Mvc;
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
            return View();
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
            Result result = new Result();
            Info_User_BLL infoUserBll = new Info_User_BLL();
            Info_User infoUser = infoUserBll.Login(model.Phone, model.PassWord);
            if (infoUser != null)
            {
                result.message="登录成功";
                result.type="success";
                result.data=new {reutrnUrl=Url.Content("~/User/Index")};
            }
            else
            {
                result.message="登录失败,请检查用户名和密码";
                result.type="error";
            }

            jr.Data = result;
            return jr;
        }
    }
}