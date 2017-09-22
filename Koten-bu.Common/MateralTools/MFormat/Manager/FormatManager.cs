using MateralTools.MVerify;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MateralTools.MFormat
{
    /// <summary>
    /// 字符串格式化
    /// </summary>
    public class FormatManager
    {
        #region String
        /// <summary>
        /// URL格式化
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <returns>格式化后的URL</returns>
        public static string URLFormat(string InputStr)
        {
            if (VerifyManager.IsURL(InputStr))
            {
                ReplaceStringModel rsm = new ReplaceStringModel(@"\", @"/");
                return Replace(InputStr, rsm);
            }
            return string.Empty;
        }
        /// <summary>
        /// 相对路径格式化
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>格式化后的Path</returns>
        public static string RelativePathFormat(string InputStr)
        {
            if (VerifyManager.IsRelativePath(InputStr))
            {
                return PathFormat(InputStr);
            }
            return string.Empty;
        }

        /// <summary>
        /// 绝对路径格式化
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>格式化后的Path</returns>
        public static string AbsolutePathFormat(string InputStr)
        {
            if (VerifyManager.IsAbsolutePath(InputStr))
            {
                return PathFormat(InputStr);
            }
            return string.Empty;
        }

        /// <summary>
        /// 路径格式化
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>格式化后的Path</returns>
        public static string PathFormat(string InputStr)
        {
            if (VerifyManager.IsAbsolutePath(InputStr) || VerifyManager.IsRelativePath(InputStr))
            {
                ReplaceStringModel rsm = new ReplaceStringModel(@"/", @"\");
                InputStr = Replace(InputStr, rsm);
                return RemvoePathLastChar(InputStr);
            }
            return string.Empty;
        }

        /// <summary>
        /// 移除路径最后的\字符
        /// </summary>
        /// <param name="InputStr">需要移除的对象</param>
        private static string RemvoePathLastChar(string InputStr)
        {
            int Length = InputStr.Length;
            if (InputStr.Last() == '\\')
            {
                InputStr.Remove(Length - 1);
            }
            return InputStr;
        }
        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <param name="rsm">需要替换的对象</param>
        /// <returns>替换后的字符串</returns>
        public static string Replace(string InputStr, ReplaceStringModel rsm)
        {
            return InputStr.Replace(rsm.OldStr, rsm.NewStr);
        }
        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <param name="rsms">需要替换的对象</param>
        /// <returns>替换后的字符串</returns>
        public static string Replace(string InputStr, List<ReplaceStringModel> rsms)
        {
            return Replace(InputStr, rsms.ToArray());
        }
        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <param name="rsms">需要替换的对象</param>
        /// <returns>替换后的字符串</returns>
        public static string Replace(string InputStr, ReplaceStringModel[] rsms)
        {
            foreach (ReplaceStringModel rsm in rsms)
            {
                InputStr = Replace(InputStr, rsm);
            }
            return InputStr;
        }
        #endregion
        #region Json
        /// <summary>
        /// Json格式化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatJsonString(string str)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    serializer.Serialize(jsonWriter, obj);
                    return textWriter.ToString();
                }
                else
                {
                    return str;
                }
        }
        /// <summary>
        /// 压缩Json
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressJsonString(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            return str;
        }
        #endregion
    }
}
