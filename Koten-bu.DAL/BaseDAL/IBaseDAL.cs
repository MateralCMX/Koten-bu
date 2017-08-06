using Koten_bu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koten_bu.DAL
{
    interface IBaseDAL<TModel, TQueryModel>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">要添加的对象</param>
        /// <returns>刚刚添加的对象唯一标识</returns>
        int Add(TModel model);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">要修改的对象</param>
        void Update(TModel model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">要删除的对象</param>
        void Delete(TModel model);
        /// <summary>
        /// 根据唯一标识获得信息
        /// </summary>
        /// <param name="ID">唯一标识</param>
        /// <returns>信息</returns>
        TModel GetInfoByID(int ID);
        /// <summary>
        /// 根据查询条件获得列表
        /// </summary>
        /// <param name="qModel">查询对象</param>
        /// <returns>列表</returns>
        List<TModel> GetInfoByWhere(TQueryModel qModel);
        /// <summary>
        /// 根据查询条件获得分页数据
        /// </summary>
        /// <param name="qModel">查询条件</param>
        /// <param name="pageM">分页数据</param>
        /// <returns>分页数据对象</returns>
        PagingData<TModel> GetInfoByWhere(TQueryModel qModel, PagingModel pageM);
    }
}
