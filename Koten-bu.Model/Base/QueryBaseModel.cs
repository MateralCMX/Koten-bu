using MateralTools.MDataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Koten_bu.Model
{
    /// <summary>
    /// 查询父模型
    /// </summary>
    public abstract class QueryBaseModel<T>
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid? ID { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool? IfDelete { get; set; }
        /// <summary>
        /// 排序列表
        /// </summary>
        public GroupModel GroupM { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<SqlParameter> ListParams { get; set; }
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
        /// <param name="hasParams">包含参数</param>
        /// <param name="OnlySpecialWhere">只包含特殊条件语句</param>
        /// <returns>查询T-Sql语句</returns>
        public abstract string GetWhereStr(bool hasParams = true, bool OnlySpecialWhere = false);
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
        /// <param name="hasParams">包含参数</param>
        /// <param name="hasWhere">包含条件语句</param>
        /// <param name="OnlySpecialWhere">只包含特殊条件语句</param>
        /// <param name="hasGroup">包含排序语句</param>
        /// <returns></returns>
        public string GetQuerySQL(bool hasParams = true, bool hasWhere = true, bool OnlySpecialWhere = false, bool hasGroup = true)
        {
            Type tType = typeof(T);
            TableModelAttribute[] tableMAtts = (TableModelAttribute[])tType.GetCustomAttributes(typeof(TableModelAttribute), false);
            string SQLStr = string.Format("select * from {0} {1}", tableMAtts[0].DBTableName, GetWhereStr(hasParams, OnlySpecialWhere));
            return SQLStr;
        }
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
            return GroupColumName + " " + GroupType.ToString();
        }
    }
}
