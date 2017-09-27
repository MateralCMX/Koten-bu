using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 验证码配置模型
    /// </summary>
    public class VerifyCodeConfigModel
    {
        /// <summary>
        /// 值色库
        /// </summary>
        public List<Color> ValueColors { get; set; }
        /// <summary>
        /// 背景颜色库
        /// </summary>
        public List<Color> BackgroundColors { get; set; }
        /// <summary>
        /// 图片背景地址
        /// </summary>
        public string ImageBackgroundPath { get; set; }
        /// <summary>
        /// 背景是图片
        /// </summary>
        public bool BackIsImage { get; set; }
        /// <summary>
        /// 验证码配置模型
        /// </summary>
        public VerifyCodeConfigModel()
        {
            ValueColors = new List<Color>
            {
                Color.MediumVioletRed,
                Color.MediumSlateBlue,
                Color.Sienna
            };
            //ValueColors.Add(Color.LightSeaGreen);
            //ValueColors.Add(Color.YellowGreen);
            //ValueColors.Add(Color.Navy);
            //ValueColors.Add(Color.DimGray);
            //ValueColors.Add(Color.Linen);
            //ValueColors.Add(Color.RosyBrown);
            BackgroundColors = new List<Color>
            {
                Color.White,
                Color.Black
            };
            ImageBackgroundPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Content\Images";
        }
    }
}
