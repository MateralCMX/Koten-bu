using System;

namespace MateralTools.MEnum
{
    /// <summary>
    /// 枚举显示名称属性
    /// </summary>
    public sealed class EnumShowNameAttribute : Attribute
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName { get; private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="showName">要显示的名字</param>
        public EnumShowNameAttribute(string showName)
        {
            this.ShowName = showName;
        }
    }
}
