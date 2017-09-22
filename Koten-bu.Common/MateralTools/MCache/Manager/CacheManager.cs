using MateralTools.MEnum;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace MateralTools.MCache
{
    /// <summary>
    /// 缓存管理类
    /// </summary>
    public static class CacheManager
    {
        /// <summary>
        /// 缓存键值
        /// </summary>
        private static List<string> _cacheKeys = new List<string>();
        /// <summary>
        /// 缓存对象
        /// </summary>
        private static ObjectCache _cacheM = MemoryCache.Default;
        /// <summary>
        /// 默认保存时间(秒)
        /// </summary>
        private static int _defaultSaveTime = 30;
        /// <summary>
        /// 默认保存时间(秒)
        /// </summary>
        public static int DefaultSaveTime {
            get
            {
                return _defaultSaveTime;
            }
            set
            {
                _defaultSaveTime = value;
            }
        }
        /// <summary>
        /// 保存时间类型
        /// </summary>
        public static TimeType _saveTimeType = TimeType.Minutes;
        /// <summary>
        /// 保存时间类型
        /// </summary>
        public static TimeType SaveTimeType
        {
            get
            {
                return _saveTimeType;
            }
            set
            {
                _saveTimeType = value;
            }
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">Key 唯一</param>
        /// <param name="value">值</param>
        /// <param name="cacheOffset">超时时间</param>
        public static void Set(string key, object value, DateTimeOffset cacheOffset)
        {
            if (_cacheKeys.Contains(key))
            {
                Remove(key);
            }
            _cacheKeys.Add(key);
            _cacheM.Add(key, value, cacheOffset);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">Key 唯一</param>
        /// <param name="value">值</param>
        /// <param name="saveTime">保存时间</param>
        public static void Set(string key,object value,int? saveTime = null)
        {
            if (saveTime == null)
            {
                saveTime = DefaultSaveTime;
            }
            DateTimeOffset cacheOffset;
            switch (SaveTimeType)
            {
                case TimeType.Years:
                    cacheOffset = DateTimeOffset.Now.AddYears(saveTime.Value);
                    break;
                case TimeType.Months:
                    cacheOffset = DateTimeOffset.Now.AddMonths(saveTime.Value);
                    break;
                case TimeType.Day:
                    cacheOffset = DateTimeOffset.Now.AddDays(saveTime.Value);
                    break;
                case TimeType.Hours:
                    cacheOffset = DateTimeOffset.Now.AddHours(saveTime.Value);
                    break;
                case TimeType.Minutes:
                    cacheOffset = DateTimeOffset.Now.AddMinutes(saveTime.Value);
                    break;
                case TimeType.Seconds:
                    cacheOffset = DateTimeOffset.Now.AddSeconds(saveTime.Value);
                    break;
                case TimeType.Milliseconds:
                    cacheOffset = DateTimeOffset.Now.AddMilliseconds(saveTime.Value);
                    break;
                default:
                    cacheOffset = DateTimeOffset.Now.AddMinutes(saveTime.Value);
                    break;
            }
            Set(key, value, cacheOffset);
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            if (_cacheKeys.Contains(key))
            {
                return _cacheM[key];
            }
            return null;
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            object obj = Get(key);
            if (obj != null && obj is T)
            {
                return (T)obj;
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">Key</param>
        public static void Remove(string key)
        {
            if (_cacheKeys.Contains(key))
            {
                _cacheKeys.Remove(key);
                _cacheM.Remove(key);
            }
        }
        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public static void Clear()
        {
            foreach (string value in _cacheKeys)
            {
                _cacheM.Remove(value);
            }
            _cacheKeys.Clear();
        }
    }
}
