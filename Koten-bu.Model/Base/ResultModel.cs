using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Model
{
    /// <summary>
    /// 返回对象类型
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 1,
        /// <summary>
        /// 错误
        /// </summary>
        Error = 2
    }
    /// <summary>
    /// 返回对象模型
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// 对象类型
        /// </summary>
        private ResultType _resultType;
        /// <summary>
        /// 对象类型
        /// </summary>
        public ResultType ResultType
        {
            get
            {
                return _resultType;
            }
        }
        /// <summary>
        /// 返回消息
        /// </summary>
        private string _message;
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
        }
        /// <summary>
        /// 获得一个返回对象
        /// </summary>
        /// <param name="resultType">返回对象类型</param>
        /// <param name="message">返回消息</param>
        /// <returns>返回对象</returns>
        public static ResultModel GetResultM(ResultType resultType, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static ResultModel GetSuccessResultM(string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static ResultModel GetFailResultM(string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static ResultModel GetErrorResultM(string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 返回Json字符串
        /// </summary>
        /// <returns>对象Json字符串</returns>
        public string GetJsonStr()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 携带数据的返回对象模型
    /// </summary>
    /// <typeparam name="T">保存数据类型</typeparam>
    public class ResultModel<T> : ResultModel
    {
        /// <summary>
        /// 携带数据
        /// </summary>
        private T _data;
        /// <summary>
        /// 携带数据
        /// </summary>
        public T Data
        {
            get
            {
                return Data;
            }
        }
        /// <summary>
        /// 获得一个返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="resultType">返回对象类型</param>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>返回对象</returns>
        public static ResultModel<T> GetResultM(ResultType resultType, T data, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static ResultModel<T> GetSuccessResultM(T data, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static ResultModel<T> GetFailResultM(T data, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static ResultModel<T> GetErrorResultM(T data, string message = "")
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 携带分页数据的返回对象
    /// </summary>
    /// <typeparam name="T">保存数据类型</typeparam>
    public class ResultPagingModel<T> : ResultModel<T>
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        private PagingModel _pagingInfo;
        /// <summary>
        /// 分页信息
        /// </summary>
        public PagingModel PagingInfo
        {
            get
            {
                return _pagingInfo;
            }
        }
        /// <summary>
        /// 获得一个返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="resultType">返回对象类型</param>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>返回对象</returns>
        public static ResultModel<T> GetResultM(ResultType resultType, T data, PagingModel pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="resultType">返回对象类型</param>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>返回对象</returns>
        public static ResultModel<T> GetResultM(ResultType resultType, PagingData<T> pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static ResultModel<T> GetSuccessResultM(T data, PagingModel pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static ResultModel<T> GetSuccessResultM(PagingData<T> pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static ResultModel<T> GetFailResultM(T data, PagingModel pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static ResultModel<T> GetFailResultM(PagingData<T> pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static ResultModel<T> GetErrorResultM(T data, PagingModel pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static ResultModel<T> GetErrorResultM(PagingData<T> pagingM, string message = "")
        {
            throw new NotImplementedException();
        }
    }
}
