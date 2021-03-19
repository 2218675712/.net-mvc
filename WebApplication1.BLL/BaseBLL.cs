using System;
using System.Collections.Generic;
using WebApplication1.DAL;

namespace WebApplication1.BLL
{
    public class BaseBLL<T> where T : class, new()
    {
        private BaseDAL<T> dao = null;

        public BaseDAL<T> Dao
        {
            get
            {
                if (dao == null)
                {
                    throw new Exception("DAO is not implament");
                }

                return dao;
            }
        }

        public BaseBLL()
        {
            dao = new BaseDAL<T>();
        }

        #region 增删改查

        public virtual int GetCount()
        {
            return Dao.GetEntitiesCount(x => { return true; });
        }

        public virtual int GetCount(Func<T, bool> exp)
        {
            return Dao.GetEntitiesCount(exp);
        }

        public virtual IEnumerable<T> GetEntities(string sql)
        {
            return Dao.GetEntities(sql);
        }

        public virtual IEnumerable<T> GetEntities(Func<T, bool> exp)
        {
            return Dao.GetEntities(exp);
        }

        public virtual IEnumerable<U> GetEntities<U>(Func<T, bool> exp, Func<T, U> select)
        {
            return Dao.GetEntities(exp, select);
        }

        public virtual T GetEntity(Func<T, bool> exp)
        {
            return Dao.GetEntity(exp);
        }

        public virtual T GetLastOne(Func<T, bool> exp)
        {
            return Dao.GetLastOne(exp);
        }

        public virtual bool Insert(T data)
        {
            try
            {
                return Dao.Insert(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual T InsertReturn(T data)
        {
            try
            {
                return Dao.InsertReturn(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual bool Update(T data)
        {
            try
            {
                return Dao.Update(data);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual T UpdateReturn(T data)
        {
            try
            {
                return Dao.UpdateReturn(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual bool Delete(T data)
        {
            try
            {
                return Dao.Delete(data);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool Delete(Object ID)
        {
            try
            {
                return Dao.Delete(ID);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual IEnumerable<object> GetVMsBySql(Type t, string sql, params object[] parameters)
        {
            return dao.GetVMsBySql(t, sql, parameters);
        }

        public virtual IEnumerable<T> GetVMExsBySql(Type t, string sql, params object[] parameters)
        {
            return dao.GetVMExsBySql(t, sql, parameters);
        }

        public int ExcuteSqlCommand(string sql, params object[] parameters)
        {
            try
            {
                var result = Dao.ExcuteSqlCommand(sql, parameters);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object GetBySqlCommandSingle(Type t, string commandText, params object[] parameters)
        {
            return dao.GetBySqlCommandSingle(t, commandText, parameters);
        }

        #endregion

        public bool InsertBatch(IEnumerable<T> entities)
        {
            return Dao.InsertBatch(entities);
        }
    }
}