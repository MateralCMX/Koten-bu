namespace MateralTools.MFormat
{
    /// <summary>
    /// 替换字符串模型
    /// </summary>
    public class ReplaceStringModel
    {
        /// <summary>
        /// 老的字符串
        /// </summary>
        public string OldStr { get; set; }
        /// <summary>
        /// 新的字符串
        /// </summary>
        public string NewStr { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReplaceStringModel()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="oldStr">老字符串</param>
        /// <param name="newStr">新字符串</param>
        public ReplaceStringModel(string oldStr, string newStr)
        {
            OldStr = oldStr;
            NewStr = newStr;
        }
    }
}
