using MateralTools.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MConvert
{
    /// <summary>
    /// 转换管理类
    /// </summary>
    public class ConvertManager
    {
        #region 列表、动态列表
        /// <summary>
        /// 将列表转换为动态数据集合
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="listM">列表</param>
        /// <returns>动态数据集</returns>
        public static ObservableCollection<T> ListToObservableCollection<T>(List<T> listM)
        {
            ObservableCollection<T> obsM = new ObservableCollection<T>();
            foreach (T item in listM)
            {
                obsM.Add(item);
            }
            return obsM;
        }
        /// <summary>
        /// 将动态数据集合转换为列表
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="obsM">动态数据集合</param>
        /// <returns>列表</returns>
        public static List<T> ObservableCollectionToList<T>(ObservableCollection<T> obsM)
        {
            return obsM.ToList();
        }
        #endregion
        #region 对象、数据行之间转换
        /// <summary>
        /// 模型转换为数据表
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <returns></returns>
        public static DataTable ModelToDataTable<T>()
        {
            Type TType = typeof(T);
            Type colType;
            ConstructorInfo[] cis = TType.GetConstructors();
            DataTable dt = new DataTable();
            if (cis.Length > 0)
            {
                object[] obj = new object[0];
                PropertyInfo[] props = typeof(T).GetProperties();
                DataColumn dc;
                foreach (PropertyInfo item in props)
                {
                    colType = item.PropertyType;
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    dc = new DataColumn(item.Name, colType);
                    dt.Columns.Add(dc);
                }
                dt.TableName = TType.Name;
            }
            else
            {
                dt = null;
            }
            return dt;
        }
        /// <summary>
        /// 模型转换为数据行
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="instanceObject">要转换的实例对象</param>
        /// <param name="dt">模型转换的数据表</param>
        /// <returns>数据行</returns>
        public static DataRow ModelToDataTable<T>(T instanceObject, DataTable dt = null)
        {
            if (dt == null)
            {
                dt = ModelToDataTable<T>();
            }
            object Value;
            PropertyInfo[] props = typeof(T).GetProperties();
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo prop in props)
            {
                Value = prop.GetValue(instanceObject, null);
                if (Value == null)
                {
                    dr[prop.Name] = DBNull.Value;
                }
                else
                {
                    dr[prop.Name] = Value;
                }
            }
            return dr;
        }
        /// <summary>
        ///  数据列转换为对象(没有特性)
        /// </summary>
        /// <param name="Model">实例对象</param>
        /// <param name="dr">数据行</param>
        /// <param name="prop">属性</param>
        private static void DataRowToModelNotAttributes(object Model, DataRow dr, PropertyInfo prop)
        {
            PropertyInfo[] subProps;
            if (!(dr[prop.Name] is System.DBNull) && dr[prop.Name].GetType().Name == prop.PropertyType.Name)
            {
                prop.SetValue(Model, dr[prop.Name], null);
            }
            else
            {
                subProps = prop.PropertyType.GetProperties();
                if (!(dr[prop.Name] is System.DBNull) && subProps.Length == 2 && dr[prop.Name].GetType().Name == subProps[1].PropertyType.Name)
                {
                    prop.SetValue(Model, dr[prop.Name], null);
                }
            }
        }
        /// <summary>
        ///  数据列转换为对象(有特性)
        /// </summary>
        /// <param name="Model">实例对象</param>
        /// <param name="dr">数据行</param>
        /// <param name="prop">属性</param>
        private static void DataRowToModelHasAttributes(object Model, DataRow dr, PropertyInfo prop)
        {
            ColumnModelAttribute dma = null;
            foreach (Attribute attr in Attribute.GetCustomAttributes(prop))
            {
                if (attr.GetType() == typeof(ColumnModelAttribute))
                {
                    dma = attr as ColumnModelAttribute;
                    if (!(dr[dma.DBColumnName] is DBNull))
                    {
                        prop.SetValue(Model, dr[dma.DBColumnName], null);
                    }
                    break;
                }
            }
        }
        #endregion
        #region 列表、数据表
        /// <summary>
        /// 转换List为DataTable
        /// </summary>
        /// <typeparam name="T">转换模型</typeparam>
        /// <param name="listM">要转换的List</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> listM = null)
        {
            if (listM == null)
            {
                listM = new List<T>();
            }
            DataTable dt = ModelToDataTable<T>();
            foreach (T item in listM)
            {
                dt.Rows.Add(ModelToDataTable(item, dt));
            }
            return dt;
        }
        /// <summary>
        /// 把数据集转换为List
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="ds">数据集</param>
        /// <param name="IsAttribut">是否按照Attribut转换</param>
        /// <returns>转换后的List</returns>
        public static List<List<T>> DataSetToList<T>(DataSet ds, bool IsAttribut = false)
        {
            List<List<T>> listMs = new List<List<T>>();
            foreach (DataTable dt in ds.Tables)
            {
                listMs.Add(DataTableToList<T>(dt, IsAttribut));
            }
            return listMs;
        }
        /// <summary>
        /// 把数据表转换为List
        /// </summary>
        /// <typeparam name="T">要转换的类型(需要有一个没有参数的构造方法)</typeparam>
        /// <param name="dt">数据表</param>
        /// <param name="IsAttribut">是否按照Attribut转换</param>
        /// <returns>转换后的List</returns>
        public static List<T> DataTableToList<T>(DataTable dt, bool IsAttribut = false)
        {
            Type TType = typeof(T);
            List<T> listMs = new List<T>();
            object Model;
            ConstructorInfo[] cis = TType.GetConstructors();
            if (cis.Length > 0)
            {
                ConstructorInfo ci = cis[0];
                ParameterInfo[] pis = ci.GetParameters();
                if (pis.Length == 0)
                {
                    PropertyInfo[] props = TType.GetProperties();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model = ci.Invoke(new object[0]);
                        foreach (PropertyInfo prop in props)
                        {
                            if (dt.Columns.Contains(prop.Name))
                            {
                                if (IsAttribut)
                                {
                                    DataRowToModelHasAttributes(Model, dr, prop);
                                }
                                else
                                {
                                    DataRowToModelNotAttributes(Model, dr, prop);
                                }
                            }
                        }
                        listMs.Add((T)Model);
                    }
                }
            }
            return listMs;
        }
        #endregion
        #region Json
        /// <summary>
        /// 对象转换为Josn
        /// </summary>
        /// <param name="model">要转换的实体</param>
        /// <returns>转换后的Json字符串</returns>
        public static string ModelToJson<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }
        /// <summary>
        /// 列表转换为Json
        /// </summary>
        /// <param name="listM">要转换的实体</param>
        /// <returns>转换后的Json字符串</returns>
        public static string ListToJson<T>(List<T> listM)
        {
            return JsonConvert.SerializeObject(listM);
        }
        /// <summary>
        /// Json转换为对象
        /// </summary>
        /// <param name="jsonStr">Json字符串</param>
        public static T JsonToModel<T>(string jsonStr)
        {
            object model = null;
            ConstructorInfo[] cis = typeof(T).GetConstructors();
            if (cis.Length > 0)
            {
                ConstructorInfo ci = cis[0];
                ParameterInfo[] pis = ci.GetParameters();
                if (pis.Length == 0)
                {
                    model = JsonToModel(jsonStr, ci.Invoke(new object[0]));
                }
            }
            return (T)model;
        }
        /// <summary>
        /// Json转换为对象
        /// </summary>
        /// <param name="jsonStr">Json字符串</param>
        /// <param name="model">要赋予的对象</param>
        public static T JsonToModel<T>(string jsonStr, T model)
        {
            JsonConvert.PopulateObject(jsonStr, model);
            return model;
        }
        /// <summary>
        /// Json转换为对象
        /// </summary>
        /// <param name="jsonStr">Json字符串</param>
        public static List<T> JsonToList<T>(string jsonStr)
        {
            List<T> listM = new List<T>();
            JsonToList(jsonStr, listM);
            return listM;
        }
        /// <summary>
        /// Json转换为List
        /// </summary>
        /// <param name="jsonStr">Json字符串</param>
        /// <param name="listM">要赋予的对象</param>
        public static List<T> JsonToList<T>(string jsonStr, List<T> listM)
        {
            JsonConvert.PopulateObject(jsonStr, listM);
            return listM;
        }
        #endregion
        #region 属性复制
        /// <summary>
        /// 属性复制T1->T2
        /// </summary>
        /// <typeparam name="T1">被复制的模型</typeparam>
        /// <typeparam name="T2">复制的模型</typeparam>
        /// <param name="model">被复制的对象</param>
        /// <returns>复制的对象</returns>
        public static T2 CopyProperties<T1, T2>(T1 model)
        {
            object T2M = null;
            ConstructorInfo[] cis = typeof(T2).GetConstructors();
            if (cis.Length > 0)
            {
                ConstructorInfo ci = cis[0];
                ParameterInfo[] pis = ci.GetParameters();
                if (pis.Length == 0)
                {
                    CopyProperties(model, ci.Invoke(new object[0]));
                }
            }
            return (T2)T2M;
        }
        /// <summary>
        /// 属性复制T1->T2
        /// </summary>
        /// <typeparam name="T1">被复制的模型</typeparam>
        /// <typeparam name="T2">复制的模型</typeparam>
        /// <param name="model1">被复制的对象</param>
        /// <param name="model2">复制的对象</param>
        /// <returns>复制的对象</returns>
        public static void CopyProperties<T1, T2>(T1 model1, T2 model2)
        {
            PropertyInfo tempProp;
            PropertyInfo[] T1Props = typeof(T1).GetProperties();
            PropertyInfo[] T2Props = typeof(T2).GetProperties();
            foreach (PropertyInfo prop in T1Props)
            {
                tempProp = T2Props.Where(m => m.Name == prop.Name).FirstOrDefault();
                if (tempProp != null)
                {
                    prop.SetValue(model2, tempProp.GetValue(model1, null), null);
                }
            }
        }
        #endregion
        #region 对象、byte数组
        /// <summary>
        /// 将对象转换为byte数组
        /// </summary>
        /// <param name="obj">被转换对象</param>
        /// <returns>转换后byte数组</returns>
        public static byte[] ObjectToBytes(object obj)
        {
            byte[] buff;
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter iFormatter = new BinaryFormatter();
                iFormatter.Serialize(ms, obj);
                buff = ms.GetBuffer();
            }
            return buff;
        }
        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static object BytesToObject(byte[] buff)
        {
            object obj;
            using (MemoryStream ms = new MemoryStream(buff))
            {
                IFormatter iFormatter = new BinaryFormatter();
                obj = iFormatter.Deserialize(ms);
            }
            return obj;
        }
        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static T BytesToObject<T>(byte[] buff)
        {
            object obj = BytesToObject(buff);
            if (obj is T)
            {
                return (T)obj;
            }
            else
            {
                return default(T);
            }
        }
        #endregion
        #region 文本、二进制
        /// <summary>
        /// 文本转换为二进制字符
        /// </summary>
        /// <param name="InputStr">文本</param>
        /// <param name="digit">位数</param>
        /// <returns>二进制字符串</returns>
        public static string StrToBinaryStr(string InputStr, int digit = 8)
        {
            byte[] data = Encoding.UTF8.GetBytes(InputStr);
            StringBuilder resStr = new StringBuilder(data.Length * digit);
            foreach (var item in data)
            {
                resStr.Append(Convert.ToString(item, 2).PadLeft(digit, '0'));
            }
            return resStr.ToString();
        }
        /// <summary>
        /// 二进制字符转换为文本
        /// </summary>
        /// <param name="InputStr">二进制字符串</param>
        /// <param name="digit">位数</param>
        /// <returns>文本</returns>
        public static string BinaryStrToStr(string InputStr, int digit = 8)
        {
            StringBuilder resStr = new StringBuilder();
            int numOfBytes = InputStr.Length / digit;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                bytes[i] = Convert.ToByte(InputStr.Substring(digit * i, digit), 2);
            }
            return Encoding.UTF8.GetString(bytes);
        }
        #endregion
    }
}
