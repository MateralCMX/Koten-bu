using System;

namespace MateralTools.MDataBase
{
    /// <summary>
    /// 表模型
    /// </summary>
    public class TableModelAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="PrimaryKeyName">主键名称</param>
        public TableModelAttribute(string TableName, string PrimaryKeyName)
        {
            DBTableName = TableName;
            PrimaryKey = PrimaryKeyName;
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string DBTableName { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey { get; set; }
    }
}
