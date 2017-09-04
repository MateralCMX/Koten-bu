using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Model
{
    /// <summary>
    /// 父模型
    /// </summary>
    public abstract class BaseModel : ICloneable
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 克隆该对象
        /// </summary>
        /// <returns>克隆对象结果</returns>
        public abstract object Clone();

        /// <summary>
        /// 验证对象是否合法
        /// </summary>
        /// <returns></returns>
        public abstract bool Validation();
    }
}
