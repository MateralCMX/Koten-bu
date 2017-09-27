using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 文本验证码模型
    /// </summary>
    public class VerifyCodeTextConfigModel : VerifyCodeConfigModel
    {
        /// <summary>
        /// 文字大小
        /// </summary>
        public int FontSize { get; set; }
        /// <summary>
        /// 文本仓库
        /// </summary>
        public List<string> TextLibrary { get; set; }
        /// <summary>
        /// 值数量
        /// </summary>
        public int ValueCount { get; set; }
        /// <summary>
        /// 混淆数量
        /// </summary>
        public int ConfusionCount { get; set; }
        /// <summary>
        /// 图片混淆方式
        /// </summary>
        public List<VerifyCodeImageObfuscationType> ImageObfuscationTypes { get; set; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public Size ImageSize { get; set; }
        /// <summary>
        /// 允许随机汉字
        /// </summary>
        public bool AllowRandomChinese { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public VerifyCodeTextConfigModel():base()
        {
            /*文本仓库初始化*/
            TextLibrary = new List<string>
            {
                "abcdefghijklmnopqrstuvwxyz",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789"
            };
            ValueCount = 4;
            ConfusionCount = 20;
            ImageObfuscationTypes = new List<VerifyCodeImageObfuscationType>
            {
                VerifyCodeImageObfuscationType.FalseValue,
                VerifyCodeImageObfuscationType.Stripe
            };
            AllowRandomChinese = false;
            ImageSize = new Size(200, 80);
            FontSize = 20;
        }
    }
}
