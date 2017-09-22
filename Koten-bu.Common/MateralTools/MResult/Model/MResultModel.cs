﻿using MateralTools.MConvert;
using MateralTools.MEnum;

namespace MateralTools.MResult
{

    /// <summary>
    /// 返回对象类型
    /// </summary>
    public enum MResultType
    {
        /// <summary>
        /// 成功
        /// </summary>
        [EnumShowName("成功")]
        Success = 0,
        /// <summary>
        /// 失败
        /// </summary>
        [EnumShowName("失败")]
        Fail = 1,
        /// <summary>
        /// 错误
        /// </summary>
        [EnumShowName("错误")]
        Error = 2
    }
    /// <summary>
    /// 返回对象模型
    /// </summary>
    public class MResultModel
    {
        /// <summary>
        /// 对象类型
        /// </summary>
        private MResultType _resultType;
        /// <summary>
        /// 对象类型
        /// </summary>
        public MResultType ResultType
        {
            get
            {
                return _resultType;
            }
        }
        /// <summary>
        /// 对象类型
        /// </summary>
        public string ResultTypeStr
        {
            get
            {
                return EnumManager.GetShowName(_resultType);
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
        /// 构造函数
        /// </summary>
        /// <param name="resultType">返回类型</param>
        /// <param name="message">返回消息</param>
        public MResultModel(MResultType resultType, string message = "")
        {
            _resultType = resultType;
            _message = message;
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static MResultModel GetSuccessResultM(string message = "")
        {
            return new MResultModel(MResultType.Success, message);
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static MResultModel GetFailResultM(string message = "")
        {
            return new MResultModel(MResultType.Fail, message);
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static MResultModel GetErrorResultM(string message = "")
        {
            return new MResultModel(MResultType.Error, message);
        }
        /// <summary>
        /// 返回Json字符串
        /// </summary>
        /// <returns>对象Json字符串</returns>
        public string GetJsonStr()
        {
            return ConvertManager.ModelToJson(this);
        }
    }
    /// <summary>
    /// 携带数据的返回对象模型
    /// </summary>
    /// <typeparam name="T">保存数据类型</typeparam>
    public class MResultModel<T> : MResultModel
    {
        /// <summary>
        /// 携带数据
        /// </summary>
        private T _data;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resultType">返回类型</param>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        public MResultModel(MResultType resultType, T data, string message = "") : base(resultType, message)
        {
            _data = data;
        }

        /// <summary>
        /// 携带数据
        /// </summary>
        public T Data
        {
            get
            {
                return _data;
            }
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static MResultModel<T> GetSuccessResultM(T data, string message = "")
        {
            return new MResultModel<T>(MResultType.Success, data, message);
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static MResultModel<T> GetFailResultM(T data = default(T), string message = "")
        {
            return new MResultModel<T>(MResultType.Fail, data, message);
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static MResultModel<T> GetErrorResultM(T data = default(T), string message = "")
        {
            return new MResultModel<T>(MResultType.Error, data, message);
        }
    }
    /// <summary>
    /// 携带分页数据的返回对象
    /// </summary>
    /// <typeparam name="T">保存数据类型</typeparam>
    public class MResultPagingModel<T> : MResultModel<T>
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        private MPagingModel _pagingInfo;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="resultType">返回对象类型</param>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        public MResultPagingModel(MResultType resultType, T data, MPagingModel pagingM, string message = "") : base(resultType, data, message)
        {
            _pagingInfo = pagingM;
        }

        /// <summary>
        /// 分页信息
        /// </summary>
        public MPagingModel PagingInfo
        {
            get
            {
                return _pagingInfo;
            }
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static MResultPagingModel<T> GetSuccessResultM(T data, MPagingModel pagingM, string message = "")
        {
            return new MResultPagingModel<T>(MResultType.Success, data, pagingM, message);
        }
        /// <summary>
        /// 获得一个成功返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>成功返回对象</returns>
        public static MResultPagingModel<T> GetSuccessResultM(MPagingData<T> pagingM, string message = "")
        {
            if (pagingM == null)
            {
                pagingM = new MPagingData<T>();
            }
            return new MResultPagingModel<T>(MResultType.Success, pagingM.Data, pagingM.PageInfo, message);
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static MResultPagingModel<T> GetFailResultM(T data = default(T), MPagingModel pagingM = null, string message = "")
        {
            return new MResultPagingModel<T>(MResultType.Fail, data, pagingM, message);
        }
        /// <summary>
        /// 获得一个失败返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>失败返回对象</returns>
        public static MResultPagingModel<T> GetFailResultM(MPagingData<T> pagingM = null, string message = "")
        {
            if (pagingM == null)
            {
                pagingM = new MPagingData<T>();
            }
            return new MResultPagingModel<T>(MResultType.Fail, pagingM.Data, pagingM.PageInfo, message);
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据对象</param>
        /// <param name="pagingM">分页信息</param>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static MResultPagingModel<T> GetErrorResultM(T data = default(T), MPagingModel pagingM = null, string message = "")
        {
            return new MResultPagingModel<T>(MResultType.Error, data, pagingM, message);
        }
        /// <summary>
        /// 获得一个错误返回对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="pagingM">分页数据对象</param>
        /// <param name="message">返回消息</param>
        /// <returns>错误返回对象</returns>
        public static MResultPagingModel<T> GetErrorResultM(MPagingData<T> pagingM = null, string message = "")
        {
            if (pagingM == null)
            {
                pagingM = new MPagingData<T>();
            }
            return new MResultPagingModel<T>(MResultType.Fail, pagingM.Data, pagingM.PageInfo, message);
        }
    }
}
