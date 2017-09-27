using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 验证码模型
    /// </summary>
    public class VerifyCodeModel
    {
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 图片组
        /// </summary>
        public List<Bitmap> Images { get; set; }
        /// <summary>
        /// 验证码类型
        /// </summary>
        public VerifyCodeType Types { get; set; }
        /// <summary>
        /// 绘制文本
        /// </summary>
        /// <param name="img">背景图</param>
        /// <param name="txt">文本</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="p">位置</param>
        /// <param name="alpha">透明度</param>
        protected void DrawText(Bitmap img, string txt, string fontName,float fontSize,Color fontColor, Point p, int alpha = 255)
        {
            Graphics graphics = Graphics.FromImage(img);
            Color drawColor = Color.FromArgb(alpha, fontColor.R, fontColor.G, fontColor.B);
            graphics.DrawString(txt, new Font(fontName, fontSize), new SolidBrush(drawColor), p);
        }
        /// <summary>
        /// 绘制直线
        /// </summary>
        /// <param name="img">背景图</param>
        /// <param name="fontColor">直线颜色</param>
        /// <param name="p1">起点</param>
        /// <param name="p2">终点</param>
        /// <param name="alpha">透明度</param>
        protected void DrawLine(Bitmap img, Color fontColor,Point p1,Point p2,int alpha)
        {
            Graphics graphics = Graphics.FromImage(img);
            Color drawColor = Color.FromArgb(alpha, fontColor.R, fontColor.G, fontColor.B);
            Pen pen = new Pen(drawColor);
            Random rd = new Random();
            graphics.DrawLine(pen, p1, p2);
        }
    }
}
