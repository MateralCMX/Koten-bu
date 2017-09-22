using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MateralTools.MDataBase
{
    /// <summary>
    /// MongoDB管理类
    /// </summary>
    /// <typeparam name="T">文档类型</typeparam>
    public class MongoDBManager<T>
    {
        /// <summary>
        /// 文档名
        /// </summary>
        private string _collectionName = string.Empty;
        /// <summary>
        /// 主键名称
        /// </summary>
        private string _PKName = string.Empty;
        /// <summary>
        /// MongoDB链接字符串
        /// </summary>
        private string _mongoDbConnectionStr = string.Empty;
        /// <summary>
        /// MongoDB链接字符串
        /// </summary>
        protected string MongoDbConnectionStr { get => _mongoDbConnectionStr; set => _mongoDbConnectionStr = value; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public MongoDBManager()
        {
            _mongoDbConnectionStr = string.Empty;
            Type TType = typeof(T);
            object[] objs = TType.GetCustomAttributes(typeof(TableModelAttribute), false);
            if (objs.Length > 0)
            {
                TableModelAttribute tma = objs[0] as TableModelAttribute;
                _PKName = tma.PrimaryKey;
                _collectionName = tma.DBTableName;
            }
            else
            {
                throw new ApplicationException(TType.Name + "没有特性TableModelAttribute");
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connectionStr">链接字符串</param>
        public MongoDBManager(string connectionStr)
        {
            _mongoDbConnectionStr = connectionStr;
            Type TType = typeof(T);
            object[] objs = TType.GetCustomAttributes(typeof(TableModelAttribute), false);
            if (objs.Length > 0)
            {
                TableModelAttribute tma = objs[0] as TableModelAttribute;
                _PKName = tma.PrimaryKey;
                _collectionName = tma.DBTableName;
            }
            else
            {
                throw new ApplicationException(TType.Name + "没有特性TableModelAttribute");
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connectionStr">链接字符串</param>
        /// <param name="collectionName ">表名</param>
        /// <param name="pkName">主键名称</param>
        public MongoDBManager(string connectionStr, string collectionName, string pkName)
        {
            _mongoDbConnectionStr = connectionStr;
            _collectionName = collectionName;
            _PKName = pkName;
        }
        /// <summary>
        /// 获得链接对象
        /// </summary>
        /// <param name="collectionName">文档名称</param>
        /// <returns>链接对象</returns>
        protected IMongoCollection<T> GetCollection(string collectionName = null)
        {
            if (!string.IsNullOrEmpty(_mongoDbConnectionStr))
            {
                MongoUrl mongoUrl = new MongoUrl(_mongoDbConnectionStr);
                MongoClient mongoClient = new MongoClient(mongoUrl);
                IMongoDatabase database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
                if (collectionName == null)
                {
                    collectionName = _collectionName;
                }
                return database.GetCollection<T>(collectionName);
            }
            else
            {
                throw new ApplicationException("连接字符串未配置,请配置属性" + nameof(MongoDbConnectionStr));
            }
        }
        /// <summary>
        /// 添加一个对象
        /// </summary>
        /// <param name="model">要添加的对象</param>
        public void Add(T model)
        {
            IMongoCollection<T> mongoDBCollection = GetCollection();
            mongoDBCollection.InsertOne(model);
        }
        /// <summary>
        /// 修改一个对象
        /// </summary>
        /// <param name="model"></param>
        public void Update(T model)
        {
            IMongoCollection<T> mongoDBCollection = GetCollection();
            FilterDefinition<T> targetM = null;
            UpdateDefinition<T> updateM = null;
            Type TType = typeof(T);
            PropertyInfo[] props = TType.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == _PKName)
                {
                    targetM = Builders<T>.Filter.Eq(prop.Name, prop.GetValue(model));
                }
                else
                {
                    if (updateM == null)
                    {
                        updateM = Builders<T>.Update.Set(prop.Name, prop.GetValue(model));
                    }
                    else
                    {
                        updateM = updateM.Set(prop.Name, prop.GetValue(model));
                    }
                }
            }
            if (targetM != null && updateM != null)
            {
                mongoDBCollection.UpdateOne(targetM, updateM);
            }
            else
            {
                throw new ApplicationException("未能识别模型，请重新该方法");
            }
        }
        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="model">要删除的对象</param>
        public void Delete(T model)
        {
            IMongoCollection<T> mongoDBCollection = GetCollection();
            Type TType = typeof(T);
            PropertyInfo[] props = TType.GetProperties();
            FilterDefinition<T> targetM = null;
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == _PKName)
                {
                    targetM = Builders<T>.Filter.Eq(prop.Name, prop.GetValue(model));
                    mongoDBCollection.DeleteOne(targetM);
                    break;
                }
            }
        }
        /// <summary>
        /// 获得所有对象信息
        /// </summary>
        /// <returns>所有对象信息</returns>
        public List<T> GetAllInfo()
        {
            IMongoCollection<T> mongoDBCollection = GetCollection();
            List<T> listM = mongoDBCollection.Find(m => true).ToList();
            return listM;
        }
        /// <summary>
        /// 根据主键获得对象信息
        /// </summary>
        /// <param name="pk">主键值</param>
        /// <returns>对象信息</returns>
        public T GetInfoByPK(ObjectId pk)
        {
            IMongoCollection<T> mongoDBCollection = GetCollection();
            Type TType = typeof(T);
            PropertyInfo[] props = TType.GetProperties();
            FilterDefinition<T> targetM;
            T model = default(T);
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == _PKName)
                {
                    targetM = Builders<T>.Filter.Eq(prop.Name, pk);
                    model = mongoDBCollection.Find(targetM).FirstOrDefault();
                    break;
                }
            }
            return model;
        }
    }
}
