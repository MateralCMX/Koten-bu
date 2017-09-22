using System;
using System.Windows;

namespace MateralTools.MMath
{
    /// <summary>
    /// 圆管理器
    /// </summary>
    public class CircularManager
    {
        /// <summary>
        /// 点P是否在圆上
        /// </summary>
        /// <param name="cirM">圆模型</param>
        /// <param name="p">点P</param>
        /// <returns></returns>
        public bool IsPointOnTheCircle(CircularModel cirM, Point p)
        {
            if(Math.Pow(p.X - cirM.Central.X, 2) + Math.Pow(p.Y - cirM.Central.Y, 2) == Math.Pow(cirM.Radius, 2))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 点P是否在圆内
        /// </summary>
        /// <param name="cirM">圆模型</param>
        /// <param name="p">点P</param>
        /// <returns></returns>
        public bool IsPointInTheCircle(CircularModel cirM, Point p)
        {
            if (Math.Pow(p.X - cirM.Central.X, 2) + Math.Pow(p.Y - cirM.Central.Y, 2) <= Math.Pow(cirM.Radius, 2))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 点P是否在圆内
        /// </summary>
        /// <param name="cirM">圆模型</param>
        /// <param name="X">点PX坐标</param>
        /// <param name="Y">点PY坐标</param>
        /// <returns></returns>
        public bool IsPointInTheCircle(CircularModel cirM, double X, double Y)
        {
            if (Math.Pow(X - cirM.Central.X, 2) + Math.Pow(Y - cirM.Central.Y, 2) <= Math.Pow(cirM.Radius, 2))
            {
                return true;
            }
            return false;
        }
    }
}
