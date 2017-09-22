using System;
using System.Windows;

namespace MateralTools.MMath
{
    /// <summary>
    /// 圆模型
    /// </summary>
    public class CircularModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="P">圆心点</param>
        /// <param name="R">半径</param>
        public CircularModel(Point P, double R)
        {
            Central = P;
            Radius = R;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="X">圆心点X坐标</param>
        /// <param name="Y">圆心点Y坐标</param>
        /// <param name="R">半径</param>
        public CircularModel(int X, int Y, double R)
        {
            Central = new Point(X, Y);
            Radius = R;
        }
        /// <summary>
        /// 圆心
        /// </summary>
        public Point Central { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public double Radius { get; set; }
        /// <summary>
        /// 周长
        /// </summary>
        public double Perimeter
        {
            get
            {
                return Math.PI * Radius * 2;
            }
        }
        /// <summary>
        /// 面积
        /// </summary>
        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }
    }
}
