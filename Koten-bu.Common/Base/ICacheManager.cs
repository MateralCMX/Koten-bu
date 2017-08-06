using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Common
{
    /// <summary>
    /// 缓存接口
    /// 用于保存一些常用数据不必反复从数据库读取
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 保存缓存内容
        /// </summary>
        /// <param name="key">缓存唯一标识</param>
        /// <param name="value">缓存的内容</param>
        /// <returns>成功结果</returns>
        bool SaveCache(string key, object value);
        /// <summary>
        /// 获得保存的缓存内容
        /// </summary>
        /// <param name="key">缓存唯一标识</param>
        /// <returns>缓存的内容</returns>
        object GetCache(string key);
        /// <summary>
        /// 获得保存的缓存内容
        /// </summary>
        /// <typeparam name="T">缓存内容的</typeparam>
        /// <param name="key">缓存唯一标识</param>
        /// <returns>缓存的内容</returns>
        T GetCache<T>(string key);
    }
}
