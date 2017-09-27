using MateralTools.Base;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MateralTools.MDataBase
{
    /// <summary>
    /// T-SQL管理类
    /// </summary>
    public class TSQLManager
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T">要添加的类型</typeparam>
        /// <param name="model">要添加的实体</param>
        /// <param name="returnInserID">返回刚刚添加的ID</param>
        /// <returns>T-SQL对象</returns>
        public static TSQLModel InsertTSQL<T>(T model, bool returnInserID = false)
        {
            TSQLModel tsqlM = new TSQLModel();
            Type tType = typeof(T);
            TableModelAttribute[] tableMAtts = (TableModelAttribute[])tType.GetCustomAttributes(typeof(TableModelAttribute), false);
            tsqlM.SQLStr = string.Format("Insert into {0} (", tableMAtts[0].DBTableName);
            string parameterName = "";
            string valuesStr = "values(";
            PropertyInfo[] props = tType.GetProperties();
            ColumnModelAttribute cma;
            foreach (PropertyInfo prop in props)
            {
                foreach (Attribute attr in Attribute.GetCustomAttributes(prop))
                {
                    if (attr.GetType() == typeof(ColumnModelAttribute))
                    {
                        cma = attr as ColumnModelAttribute;
                        parameterName = string.Format("@{0}", cma.DBColumnName);
                        tsqlM.SQLParameters.Add(new TSQLParameter(parameterName, prop.GetValue(model)));
                        if (!cma.AutoNumber)
                        {
                            tsqlM.SQLStr += string.Format("[{0}], ", cma.DBColumnName);
                            valuesStr += parameterName + ", ";
                        }
                    }
                }
            }
            int SQLLength = tsqlM.SQLStr.Length;
            int valuesLength = valuesStr.Length;
            tsqlM.SQLStr = tsqlM.SQLStr.Remove(SQLLength - 2) + ") " + valuesStr.Remove(valuesLength - 2) + ");";
            if (returnInserID)
            {
                tsqlM.SQLStr += "select @@IDENTITY;";
            }
            return tsqlM;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">要修改的类型</typeparam>
        /// <param name="model">要修改的实体</param>
        /// <returns>T-SQL对象</returns>
        public static TSQLModel UpdateTSQL<T>(T model)
        {
            TSQLModel tsqlM = new TSQLModel();
            Type tType = typeof(T);
            TableModelAttribute[] tableMAtts = (TableModelAttribute[])tType.GetCustomAttributes(typeof(TableModelAttribute), false);
            tsqlM.SQLStr = string.Format("Update {0} set ", tableMAtts[0].DBTableName);
            string parameterName = "";
            string whereStr = " where";
            PropertyInfo[] props = tType.GetProperties();
            ColumnModelAttribute cma;
            foreach (PropertyInfo prop in props)
            {
                foreach (Attribute attr in Attribute.GetCustomAttributes(prop))
                {
                    if (attr.GetType() == typeof(ColumnModelAttribute))
                    {
                        cma = attr as ColumnModelAttribute;
                        parameterName = string.Format("@{0}", cma.DBColumnName);
                        tsqlM.SQLParameters.Add(new TSQLParameter(parameterName, prop.GetValue(model)));
                        if (tableMAtts[0].PrimaryKey != cma.DBColumnName)
                        {
                            tsqlM.SQLStr += string.Format("[{0}] = ", cma.DBColumnName) + parameterName + ", ";
                        }
                        else
                        {
                            whereStr += string.Format("[{0}] = ", cma.DBColumnName) + parameterName;
                        }
                    }
                }
            }
            int Length = tsqlM.SQLStr.Length;
            tsqlM.SQLStr = tsqlM.SQLStr.Remove(Length - 2) + whereStr;
            return tsqlM;
        }
        /// <summary>
        /// 删除
        /// 模型需要特性 TableModelAttribute ColumnModelAttribute
        /// </summary>
        /// <typeparam name="T">要删除的类型</typeparam>
        /// <param name="model">要删除的实体</param>
        /// <returns>T-SQL对象</returns>
        public static TSQLModel DeleteTSQL<T>(T model)
        {
            TSQLModel tsqlM = new TSQLModel();
            Type tType = typeof(T);
            TableModelAttribute[] tableMAtts = (TableModelAttribute[])tType.GetCustomAttributes(typeof(TableModelAttribute), false);
            tsqlM.SQLStr = string.Format("Delete from {0} where ", tableMAtts[0].DBTableName);
            string parameterName = "";
            PropertyInfo[] props = tType.GetProperties();
            ColumnModelAttribute cma;
            bool isReady = false;
            foreach (PropertyInfo prop in props)
            {
                if (!isReady)
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(prop))
                    {
                        if (attr.GetType() == typeof(ColumnModelAttribute))
                        {
                            cma = attr as ColumnModelAttribute;
                            if (tableMAtts[0].PrimaryKey == cma.DBColumnName)
                            {
                                parameterName = string.Format("@{0}", cma.DBColumnName);
                                tsqlM.SQLParameters.Add(new TSQLParameter(parameterName, prop.GetValue(model)));
                                tsqlM.SQLStr += string.Format("[{0}] = ", cma.DBColumnName) + parameterName;
                                isReady = true;
                                break;
                            }
                        }
                    }
                }
            }
            return tsqlM;
        }
    }
}
