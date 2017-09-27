using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 文本验证码模型
    /// </summary>
    public class VerifyCodeTextModel : VerifyCodeModel
    {
        /// <summary>
        /// 配置对象
        /// </summary>
        private VerifyCodeTextConfigModel _config;
        /// <summary>
        /// 文本仓库
        /// </summary>
        public List<char> TextLib { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="config">文本验证码配置对象</param>
        public VerifyCodeTextModel(VerifyCodeTextConfigModel config)
        {
            _config = config;
            CreateTextLib();
            ScreenKey();
            DrawImage();
        }
        /// <summary>
        /// 创建文本仓库
        /// </summary>
        private void CreateTextLib()
        {
            TextLib = new List<char>();
            foreach (string text in _config.TextLibrary)
            {
                TextLib.AddRange(text.ToArray());
            }
        }
        /// <summary>
        /// 筛选值
        /// </summary>
        private void ScreenKey()
        {
            if (!_config.AllowRandomChinese)
            {
                int Count = TextLib.Count;
                if (Count > 0)
                {
                    Random rd = new Random();
                    int Index = 0;
                    for (int i = 0; i < _config.ValueCount; i++)
                    {
                        Index = rd.Next(0, Count);
                        Value += TextLib[Index];
                    }
                }
                else
                {
                    throw new VerifyCodeException("文本仓库不能为空");
                }
            }
            else
            {
                Encoding gb = Encoding.GetEncoding("gb2312");
                object[] bytes = CreateRandChieseCode(_config.ValueCount);
                for (int i = 0; i < _config.ValueCount; i++)
                {
                    Value += gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                }
            }
        }
        /// <summary>
        /// 绘制图片
        /// </summary>
        private void DrawImage()
        {
            Images = new List<Bitmap>();
            Bitmap img = new Bitmap(_config.ImageSize.Width, _config.ImageSize.Height);
            Graphics graphics = Graphics.FromImage(img);
            Random rd = new Random();
            graphics.FillRectangle(new SolidBrush(_config.BackgroundColors[rd.Next(0, _config.BackgroundColors.Count)]), new Rectangle(new Point(0, 0), _config.ImageSize));
            if (_config.BackIsImage && !string.IsNullOrEmpty(_config.ImageBackgroundPath))
            {
                string[] filsName = Directory.GetFiles(_config.ImageBackgroundPath);
                int Index = rd.Next(0, filsName.Length);
                graphics.DrawImage(Image.FromFile(filsName[Index]), new Point(0, 0));
            }
            Point p;
            Color fontColor;
            int alpha;
            int min = 0;
            int max = 0;
            foreach (VerifyCodeImageObfuscationType item in _config.ImageObfuscationTypes)
            {
                switch (item)
                {
                    case VerifyCodeImageObfuscationType.Stripe:
                        for (int i = 0; i < _config.ConfusionCount; i++)
                        {
                            fontColor = _config.ValueColors[rd.Next(0, _config.ValueColors.Count)];
                            alpha = rd.Next(50, 130);
                            p = new Point(rd.Next(0, img.Width), rd.Next(0, img.Height));
                            Point p2 = new Point(rd.Next(0, img.Width), rd.Next(0, img.Height));
                            DrawLine(img, fontColor, p, p2, alpha);
                        }
                        break;
                    case VerifyCodeImageObfuscationType.FalseValue:
                        char value;
                        Encoding gb = Encoding.GetEncoding("gb2312");
                        for (int i = 0; i < _config.ConfusionCount; i++)
                        {
                            alpha = rd.Next(50, 130);
                            if (!_config.AllowRandomChinese)
                            {
                                value = TextLib[rd.Next(0, TextLib.Count)];
                            }
                            else
                            {
                                object[] bytes = CreateRandChieseCode(1);
                                value = gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[])))[0];
                            }
                            min = i * (_config.ImageSize.Width / Value.Length);
                            min += rd.Next(0, _config.FontSize / 3);
                            max = _config.ImageSize.Height - (_config.FontSize * 2);
                            if (max <= 0)
                            {
                                if (_config.FontSize > _config.ImageSize.Height)
                                {
                                    max = _config.ImageSize.Height;
                                }
                                else
                                {
                                    max = Convert.ToInt32(_config.ImageSize.Height - (_config.FontSize * 1.5));
                                }
                            }
                            max = rd.Next(0, max);
                            min = rd.Next(0, min);
                            max = rd.Next(0, max);
                            bool IsNegative = Convert.ToBoolean(rd.Next(0, 2));
                            if (IsNegative)
                            {
                                min *= -1;
                            }
                            IsNegative = Convert.ToBoolean(rd.Next(0, 2));
                            if (IsNegative)
                            {
                                max *= -1;
                            }
                            p = new Point(min, max);
                            fontColor = _config.ValueColors[rd.Next(0, _config.ValueColors.Count)];
                            DrawText(img, value.ToString(), "宋体", _config.FontSize, fontColor, p, alpha);
                        }
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < Value.Length; i++)
            {
                bool IsNegative = Convert.ToBoolean(rd.Next(0, 2));
                min = i * (_config.ImageSize.Width / Value.Length);
                if (IsNegative)
                {
                    min -= rd.Next(0, _config.FontSize / 3);
                }
                else
                {
                    min += rd.Next(0, _config.FontSize / 3);
                }
                max = _config.ImageSize.Height - (_config.FontSize * 2);
                if (max <= 0)
                {
                    if (_config.FontSize > _config.ImageSize.Height)
                    {
                        max = _config.ImageSize.Height ;
                    }
                    else
                    {
                        max = Convert.ToInt32(_config.ImageSize.Height - (_config.FontSize * 1.5));
                    }
                }
                max = rd.Next(0, max);
                IsNegative = Convert.ToBoolean(rd.Next(0, 2));
                if (IsNegative)
                {
                    max *= -1;
                }
                p = new Point(min, max);
                fontColor = _config.ValueColors[rd.Next(0, _config.ValueColors.Count)];
                DrawText(img, Value[i].ToString(), "微软雅黑", _config.FontSize, fontColor, p, 255);
            }
            Images.Add(img);
        }
        /// <summary>
        /// 创建随机汉字
        /// </summary>
        /// <param name="strlength">数量</param>
        /// <returns></returns>
        private object[] CreateRandChieseCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素 
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            //定义一个object数组用来 
            object[] bytes = new object[strlength];
            /*每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bject数组中 
             每个汉字有四个区位码组成 
             区位码第1位和区位码第2位作为字节数组第一个元素 
             区位码第3位和区位码第4位作为字节数组第二个元素 
            */
            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位 
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();
                //区位码第2位 
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机数发生器的种子避免产生重复值
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位 
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();
                //区位码第4位 
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();
                //定义两个字节变量存储产生的随机汉字区位码 
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //将两个字节变量存储在字节数组中 
                byte[] str_r = new byte[] { byte1, byte2 };
                //将产生的一个汉字的字节数组放入object数组中 
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }
    }
}
