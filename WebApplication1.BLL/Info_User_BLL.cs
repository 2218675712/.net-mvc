using System.Collections.Generic;
using System.Linq;
using WebApplication1.Entity;

namespace WebApplication1.BLL
{
    public class Info_User_BLL : BaseBLL<Info_User>
    {
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <returns></returns>
        public List<Info_User> GetList()
        {
            return Dao.GetEntities(x => x.IsDelete == false).ToList();
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            bool isOk = false;
            Info_User model = Dao.GetEntities(x => x.ID == ID).FirstOrDefault();
            if (model.ID > 0)
            {
                isOk = Dao.Delete(model);
            }

            return isOk;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(Info_User model)
        {
            bool isOk = false;
            if (model.ID > 0)
            {
                isOk = Dao.Update(model);
            }

            return isOk;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Info_User model)
        {
            bool isOk = false;
            if (model.ID > 0)
            {
                isOk = Dao.Insert(model);
            }

            return isOk;
        }
        /// <summary>
        /// 根据id获取model
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Info_User GetModelByID(int ID)
        {
            return Dao.GetEntities(x => x.ID == ID).FirstOrDefault();
        }

        /// <summary>
        /// 根据手机号及密码进行登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public Info_User Login(string phone,string pwd)
        {
            return Dao.GetEntity(x => x.Phone == phone && x.PassWord == pwd);
        }
    }
}