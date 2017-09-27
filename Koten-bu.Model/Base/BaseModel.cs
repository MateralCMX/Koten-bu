using MateralTools.Base;
using System;

namespace Koten_bu.Model
{
    /// <summary>
    /// 父模型
    /// </summary>
    public abstract class BaseModel : MBaseModel
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 验证对象是否合法
        /// </summary>
        /// <returns></returns>
        public abstract bool Validation();
    }
}
