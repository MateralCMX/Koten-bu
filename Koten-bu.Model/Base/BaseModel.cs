using MateralTools.Base;
using System;

namespace Koten_bu.Model
{
    /// <summary>
    /// 父模型
    /// </summary>
    public abstract class BaseModel : MBaseModel
    {
        #region 成员
        /// <summary>
        /// 唯一标识
        /// </summary>
        [ColumnModel("ID", "uniqueidentifier")]
        public Guid ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [ColumnModel("CreateTime", "datetime")]
        public DateTime CreateTime { get; set; }
        #endregion
        #region 方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseModel()
        {
            ID = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
        /// <summary>
        /// 验证对象是否合法
        /// </summary>
        /// <returns>验证结果</returns>
        public bool Validation()
        {
            string msg = "";
            return Validation(ref msg);
        }
        /// <summary>
        /// 验证对象是否合法
        /// </summary>
        /// <param name="msg">验证消息</param>
        /// <returns>验证结果</returns>
        public abstract bool Validation(ref string msg);
        #endregion
    }
}
