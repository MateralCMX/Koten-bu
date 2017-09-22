using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace MateralTools.Base
{
    /// <summary>
    /// 初始类型
    /// </summary>
    [Serializable]
    public class MBaseModel : ICloneable
    {
        /// <summary>
        /// 克隆对象
        /// 需要特性:[Serializable]
        /// </summary>
        /// <returns>克隆的对象</returns>
        public object Clone()
        {
            object resM = null;
            Type thisType = this.GetType();
            if ((thisType.Attributes & TypeAttributes.Serializable) == TypeAttributes.Serializable)
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, this);
                ms.Position = 0;
                resM = bf.Deserialize(ms);
            }
            else
            {
                throw new ApplicationException("该类型不支持序列化，请添加[Serializable]特性");
            }
            return resM;
        }
    }
}
