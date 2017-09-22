using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MateralTools.MDataBase
{
    /// <summary>
    /// TSQL模型
    /// </summary>
    public class TSQLModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public TSQLModel()
        {
            SQLParameters = new List<TSQLParameter>();
        }
        /// <summary>
        /// SQL语句
        /// </summary>
        public string SQLStr { get; set; }
        /// <summary>
        /// 参数组
        /// </summary>
        public List<TSQLParameter> SQLParameters { get; set; }
        /// <summary>
        /// 获得SQLServer参数组
        /// </summary>
        /// <param name="parameterNames">包含的参数组，为空则全部添加</param>
        /// <returns></returns>
        public SqlParameter[] GetMSSQLParameter(string[] parameterNames = null)
        {
            List<SqlParameter> mssqlParameter = new List<SqlParameter>();
            foreach (TSQLParameter item in SQLParameters)
            {
                if (parameterNames == null)
                {
                    mssqlParameter.Add(new SqlParameter(item.ParameterName, item.Value));
                }
                else
                {
                    if (parameterNames.Contains(item.ParameterName))
                    {
                        mssqlParameter.Add(new SqlParameter(item.ParameterName, item.Value));
                    }
                }
            }
            return mssqlParameter.ToArray();
        }
        /// <summary>
        /// 获得SQL参数组
        /// </summary>
        /// <typeparam name="T">参数对象</typeparam>
        /// <returns></returns>
        public T[] GetSQLParameters<T>()
        {
            List<T> listM = new List<T>();
            Type tType = typeof(T);
            Type[] pType = new Type[2];
            pType[0] = typeof(string);
            pType[1] = typeof(object);
            ConstructorInfo constructor = tType.GetConstructor(pType);
            if (constructor != null)
            {
                T model;
                object[] objs;
                foreach (TSQLParameter item in this.SQLParameters)
                {
                    objs = new object[2];
                    objs[0] = item.ParameterName;
                    objs[1] = item.Value;
                    model = (T)constructor.Invoke(objs);
                    listM.Add(model);
                }
            }
            return listM.ToArray();
        }
    }
    /// <summary>
    /// TSQL参数模型
    /// </summary>
    public class TSQLParameter
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="parameterName">名称</param>
        /// <param name="value">值</param>
        public TSQLParameter(string parameterName, object value)
        {
            this.ParameterName = parameterName;
            this.Value = value;
        }
    }
}
