using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Common
{
    /// <summary>
    /// 枚举管理器接口
    /// </summary>
    interface IEnumManager
    {
        /// <summary>
        /// 值转换为枚举对象
        /// </summary>
        /// <typeparam name="T1">值类型</typeparam>
        /// <param name="value">值</param>
        /// <returns>枚举对象</returns>
        Enum ValueToEnum<T1>(T1 value);
        /// <summary>
        /// 枚举对象转换为值
        /// </summary>
        /// <typeparam name="T1">值类型</typeparam>
        /// <param name="enumObj">枚举对象</param>
        /// <returns>值</returns>
        T1 EnumToValue<T1>(Enum enumObj);
    }
}
