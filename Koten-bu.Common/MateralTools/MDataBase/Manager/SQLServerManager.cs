using MateralTools.MConvert;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MateralTools.MDataBase
{
    /// <summary>
    /// SQLServer操作管理器
    /// </summary>
    public class SQLServerManager
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T">要添加的类型</typeparam>
        /// <param name="model">要添加的实体</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>影响的行数</returns>
        public static int Insert<T>(T model, string ConStrName = null)
        {
            TSQLModel tsqlM = TSQLManager.InsertTSQL(model);
            return ExecuteNonQuery(tsqlM.SQLStr, tsqlM.GetSQLParameters<SqlParameter>(), ConStrName);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">要修改的类型</typeparam>
        /// <param name="model">要修改的实体</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>影响的行数</returns>
        public static int Update<T>(T model, string ConStrName = null)
        {
            TSQLModel tsqlM = TSQLManager.UpdateTSQL(model);
            return ExecuteNonQuery(tsqlM.SQLStr, tsqlM.GetSQLParameters<SqlParameter>(), ConStrName);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">要删除的类型</typeparam>
        /// <param name="model">要删除的实体</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>影响的行数</returns>
        public static int Delete<T>(T model, string ConStrName = null)
        {
            TSQLModel tsqlM = TSQLManager.DeleteTSQL(model);
            return ExecuteNonQuery(tsqlM.SQLStr, tsqlM.GetSQLParameters<SqlParameter>(), ConStrName);
        }
        /// <summary>
        /// 执行非查询语句或存储过程
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] paras, string ConStrName = null)
        {
            return SqlServerHelper.ExecuteNonQuery(SqlServerHelper.GetConnection(ConStrName), CommandType.Text, sql, paras);
        }
        /// <summary>
        /// 执行非查询语句或存储过程
        /// </summary>
        /// <param name="tsqM">T-SQL对象</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>查询结果</returns>
        public static int ExecuteNonQuery(TSQLModel tsqM, string ConStrName = null)
        {
            return ExecuteNonQuery(tsqM.SQLStr, tsqM.GetMSSQLParameter());
        }
        /// <summary>
        /// 执行查询语句或存储过程
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>查询结果</returns>
        public static DataSet ExecuteQuery(string sql, SqlParameter[] paras, string ConStrName = null)
        {
            return SqlServerHelper.ExecuteDataset(SqlServerHelper.GetConnection(ConStrName), CommandType.Text, sql, paras);
        }
        /// <summary>
        /// 执行查询语句或存储过程
        /// </summary>
        /// <param name="tsqM">T-SQL对象</param>
        /// <param name="ConStrName">链接字符串</param>
        /// <returns>查询结果</returns>
        public static DataSet ExecuteQuery(TSQLModel tsqM, string ConStrName = null)
        {
            return ExecuteQuery(tsqM.SQLStr, tsqM.GetMSSQLParameter());
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">SQL查询语句</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="pageindex">起始页索引</param>
        /// <param name="pagesize">每页显示记录数</param>
        /// <returns></returns>
        public static DataSet Pagination(string query, string orderBy = "ID Asc", int pageindex = 1, int pagesize = 20)
        {
            string sql = @"EXEC	ListPage
		                        @p_tableName = '{0}',
		                        @p_columns = N'*',
		                        @sort = '{1}',
		                        @page = {2},
		                        @rows = {3},
		                        @p_totalRecords = 1,
		                        @p_totalPages = 1";
            sql = string.Format(sql, "( " + query + ") T_QueryTable", orderBy, pageindex, pagesize);
            return ExecuteQuery(sql, null);
        }
    }
}
