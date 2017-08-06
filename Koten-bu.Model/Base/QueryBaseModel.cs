using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Model
{
    /// <summary>
    /// 查询父模型
    /// </summary>
    public abstract class QueryBaseModel
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int? ID { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IfDelete { get; set; }
        /// <summary>
        /// 排序列表
        /// </summary>
        public GroupModel GroupM { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public QueryBaseModel()
        {
            SpecialWhereStr = string.Empty;
            IfDelete = false;
        }
        /// <summary>
        /// 特殊条件语句
        /// </summary>
        public string SpecialWhereStr { get; set; }
        /// <summary>
        /// 获得查询条件语句
        /// </summary>
        /// <param name="OnlySpecialWhere">只包含特殊条件语句</param>
        /// <returns>查询T-Sql语句</returns>
        public abstract string GetWhereStr(bool OnlySpecialWhere);
        /// <summary>
        /// 获得排序语句
        /// </summary>
        /// <returns>排序T-Sql语句</returns>
        public string GetGroupStr()
        {
            return GroupM.GetGroupStr();
        }
        /// <summary>
        /// 获得完整的查询语句
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="hasWhere">包含条件语句</param>
        /// <param name="OnlySpecialWhere">只包含特殊条件语句</param>
        /// <param name="hasGroup">包含排序语句</param>
        /// <returns></returns>
        public abstract string GetQuerySQL(string sql, bool hasWhere = true, bool OnlySpecialWhere = false, bool hasGroup = true);
    }
    /// <summary>
    /// 排序类型
    /// </summary>
    public enum GroupType
    {
        /// <summary>
        /// 升序
        /// </summary>
        Asc,
        /// <summary>
        /// 降序
        /// </summary>
        Desc
    }
    /// <summary>
    /// 排序模型
    /// </summary>
    public class GroupModel
    {
        /// <summary>
        /// 排序类型
        /// </summary>
        public GroupType GroupType { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public string GroupColumName { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public GroupModel()
        {
            GroupType =  GroupType.Asc;
            GroupColumName = "ID";
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="groupType">排序类型</param>
        public GroupModel(GroupType groupType)
        {
            GroupType = groupType;
            GroupColumName = "ID";
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="groupType">排序类型</param>
        /// <param name="groupColum">排序列</param>
        public GroupModel(GroupType groupType,string groupColum)
        {
            GroupType = groupType;
            GroupColumName = groupColum;
        }
        /// <summary>
        /// 获得排序语句
        /// </summary>
        /// <returns>排序T-Sql语句</returns>
        public string GetGroupStr()
        {
            throw new NotImplementedException();
        }
    }
}
