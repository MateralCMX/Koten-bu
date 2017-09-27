using Microsoft.VisualStudio.TestTools.UnitTesting;
using Koten_bu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koten_bu.Model;
using MateralTools.MResult;

namespace Koten_bu.DAL.Tests
{
    [TestClass()]
    public class LogDALTests
    {
        private LogDAL logDal = new LogDAL();
        [TestMethod()]
        public void AddTest()
        {
            LogModel logM = new LogModel(LogTypeEnum.OperationLog, "测试日志", "测试添加日志");
            logDal.Add(logM);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            LogModel logM = new LogModel()
            {
                ID = Guid.Parse("1C138D33-8E51-4A2F-BD09-1944F2163E36")
            };
            logDal.Delete(logM);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            LogModel logM = new LogModel(LogTypeEnum.OperationLog, "测试日志", "测试修改日志")
            {
                ID = Guid.Parse("1C138D33-8E51-4A2F-BD09-1944F2163E36")
            };
            logDal.Update(logM);
        }

        [TestMethod()]
        public void GetInfoByIDTest()
        {
            LogModel logM = logDal.GetInfoByID(Guid.Parse("37689F18-E5F2-42AE-9610-273DA251A80B"));
        }

        [TestMethod()]
        public void GetInfoByWhereTest()
        {
            LogQueryModel qModel = new LogQueryModel
            {
                ID = Guid.Parse("37689F18-E5F2-42AE-9610-273DA251A80B")
            };
            List<LogModel> listM = logDal.GetInfoByWhere(qModel);
        }

        [TestMethod()]
        public void GetInfoByWhereTest1()
        {
            LogQueryModel qModel = new LogQueryModel
            {
                ID = Guid.Parse("37689F18-E5F2-42AE-9610-273DA251A80B"),
                GroupM = new GroupModel(GroupType.Asc, "CreateTime")
            };
            MPagingModel pageM = new MPagingModel()
            {
                PagingIndex = 1,
                PagingSize = 20
            };
            MPagingData<List<LogModel>> listM = logDal.GetInfoByWhere(qModel, pageM);
        }
    }
}