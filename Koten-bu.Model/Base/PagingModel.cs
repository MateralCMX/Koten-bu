using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Model
{

    /// <summary>
    /// 分页模型
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// 查询页面
        /// </summary>
        public int PagingIndex { get; set; }
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PagingSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PagingCount { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int DataCount { get; set; }
    }
    /// <summary>
    /// 分页数据模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class PagingData<T>
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        PagingModel PageInfo { get; set; }
        /// <summary>
        /// 数据信息
        /// </summary>
        List<T> Data { get; set; }
    }
}
