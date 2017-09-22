using MateralTools.Base;
using System;

namespace MateralTools.MEnum
{
    /// <summary>
    /// 枚举模型
    /// </summary>
    [Serializable]
    public class EnumModel : MBaseModel
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string EnumName { get; private set; }
        /// <summary>
        /// 绑定的枚举值
        /// </summary>
        public Enum EnumValue { get; private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="enumValue">要绑定的值</param>
        /// <param name="enumName">要显示的名称，如果为空则采用EnumShowNameAttribute绑定的值</param>
        public EnumModel(Enum enumValue, string enumName = null)
        {
            this.EnumValue = enumValue;
            if (EnumName == null)
            {
                this.EnumName = EnumManager.GetShowName(enumValue);
            }
            else
            {
                this.EnumName = enumName;
            }
        }
    }
}
