using MateralTools.MDataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.Model
{
    public class LogQueryModel : QueryBaseModel<LogModel>
    {
        #region 成员
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogTypeEnum? LogType { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDateTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateTime { get; set; }
        #endregion
        /// <summary>
        /// 获得查询条件语句
        /// </summary>
        /// <param name="hasParams">参数列表</param>
        /// <param name="OnlySpecialWhere">只包含特殊条件语句</param>
        /// <returns>查询T-Sql语句</returns>
        public override string GetWhereStr(bool hasParams = true, bool OnlySpecialWhere = false)
        {
            ListParams = new List<SqlParameter>();
            string whereStr = " where 1=1";
            if (!OnlySpecialWhere)
            {
                if (ID == null)
                {
                    if (LogType != null)
                    {
                        if (hasParams)
                        {
                            whereStr += string.Format(" and LogType={0}", "@LogType");
                            ListParams.Add(new SqlParameter("@ID", Convert.ToByte(LogType.Value)));
                        }
                        else
                        {
                            whereStr += string.Format(" and LogType=''{0}''", Convert.ToByte(LogType.Value));
                        }
                    }
                    if (StartDateTime != null)
                    {
                        if (hasParams)
                        {
                            whereStr += string.Format(" and CreateTime >= {0}", "@StartTime");
                            ListParams.Add(new SqlParameter("@ID", StartDateTime.Value));
                        }
                        else
                        {
                            whereStr += string.Format(" and CreateTime >= ''{0}''", StartDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss"));
                        }
                    }
                    if (EndDateTime != null)
                    {
                        if (hasParams)
                        {
                            whereStr += string.Format(" and CreateTime <= {0}", "@EndDateTime");
                            ListParams.Add(new SqlParameter("@ID", EndDateTime.Value));
                        }
                        else
                        {
                            whereStr += string.Format(" and CreateTime <= ''{0}''", EndDateTime.Value.ToString("yyyy/MM/dd HH:mm:ss"));
                        }
                    }
                }
                else
                {
                    if (hasParams)
                    {
                        whereStr += string.Format(" and ID={0}", "@ID");
                        ListParams.Add(new SqlParameter("@ID", ID.Value));
                    }
                    else
                    {
                        whereStr += string.Format(" and ID=''{0}''", ID.Value);
                    }
                }
            }
            else
            {
                whereStr += SpecialWhereStr;
            }
            return whereStr;
        }
    }
}
