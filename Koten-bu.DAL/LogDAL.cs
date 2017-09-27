using Koten_bu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MateralTools.MResult;
using MateralTools.MDataBase;
using System.Data;
using MateralTools.MConvert;
using System.Data.SqlClient;

namespace Koten_bu.DAL
{
    /// <summary>
    /// 日志数据操作类
    /// </summary>
    public class LogDAL : IBaseDAL<LogModel, LogQueryModel>
    {
        /// <summary>
        /// 添加一条日志
        /// </summary>
        /// <param name="model">要添加的日志对象</param>
        /// <returns>添加结果</returns>
        public void Add(LogModel model)
        {
            model.ID = Guid.NewGuid();
            SQLServerManager.Insert(model);
        }
        /// <summary>
        /// 删除一条日志
        /// </summary>
        /// <param name="model">要删除的日志对象</param>
        public void Delete(LogModel model)
        {
            SQLServerManager.Delete(model);
        }
        /// <summary>
        /// 修改一条日志
        /// </summary>
        /// <param name="model">要修改的日志对象</param>
        public void Update(LogModel model)
        {
            SQLServerManager.Update(model);
        }
        /// <summary>
        /// 根据唯一标识获取日志信息
        /// </summary>
        /// <param name="ID">唯一标识</param>
        /// <returns>日志信息</returns>
        public LogModel GetInfoByID(Guid ID)
        {
            LogQueryModel qModel = new LogQueryModel
            {
                ID = ID
            };
            List<LogModel> listM = GetInfoByWhere(qModel);
            return listM.FirstOrDefault();
        }
        /// <summary>
        /// 根据条件查询日志信息
        /// </summary>
        /// <param name="qModel">查询条件</param>
        /// <returns>日志信息</returns>
        public List<LogModel> GetInfoByWhere(LogQueryModel qModel)
        {
            DataSet ds = SQLServerManager.ExecuteQuery(qModel.GetQuerySQL(), qModel.ListParams.ToArray());
            return ConvertManager.DataTableToList<LogModel>(ds.Tables[0], true);
        }
        /// <summary>
        /// 根据条件查询日志分页信息
        /// </summary>
        /// <param name="qModel">查询条件</param>
        /// <param name="pageM">分页对象</param>
        /// <returns>日志信息</returns>
        public MPagingData<List<LogModel>> GetInfoByWhere(LogQueryModel qModel, MPagingModel pageM)
        {
            DataSet ds = SQLServerManager.Pagination(qModel.GetQuerySQL(false), qModel.GetGroupStr(), pageM.PagingIndex, pageM.PagingSize);
            MPagingData<List<LogModel>> resM = new MPagingData<List<LogModel>>();
            resM.Data = ConvertManager.DataTableToList<LogModel>(ds.Tables[0]);
            pageM.PagingIndex = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            pageM.DataCount = Convert.ToInt32(ds.Tables[1].Rows[0][1]);
            pageM.PagingCount = Convert.ToInt32(ds.Tables[1].Rows[0][2]);
            resM.PageInfo = pageM;
            return resM;
        }
    }
}
