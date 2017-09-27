using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 验证类型
    /// </summary>
    public enum VerfyType
    {
        /// <summary>
        /// 可以为NULL
        /// </summary>
        Will,
        /// <summary>
        /// 不可以为NULL
        /// </summary>
        NotNull,
        /// <summary>
        /// 不可以为NULL并且不能为""
        /// </summary>
        NotNullAndEmpty,
        /// <summary>
        /// 是电话号码
        /// </summary>
        IsPhoneNumber,
        /// <summary>
        /// 是IPv4
        /// </summary>
        IsIPv4,
        /// <summary>
        /// 是IPv4加端口号
        /// </summary>
        IsIPv4AndPort,
        /// <summary>
        /// 是邮箱地址
        /// </summary>
        IsEMail,
        /// <summary>
        /// 是实数
        /// </summary>
        IsRealNumber,
        /// <summary>
        /// 是正实数
        /// </summary>
        IsRealNumberPositive,
        /// <summary>
        /// 是负实数
        /// </summary>
        IsRealNumberNegative,
        /// <summary>
        /// 是整数
        /// </summary>
        IsInteger,
        /// <summary>
        /// 是正整数
        /// </summary>
        IsIntegerPositive,
        /// <summary>
        /// 是负整数
        /// </summary>
        IsIntegerNegative,
        /// <summary>
        /// 是URL地址
        /// </summary>
        IsURL,
        /// <summary>
        /// 是相对路径
        /// </summary>
        IsRelativePath,
        /// <summary>
        /// 是文件名
        /// </summary>
        IsFileName,
        /// <summary>
        /// 是日期
        /// </summary>
        IsDate,
        /// <summary>
        /// 是时间
        /// </summary>
        IsTime,
        /// <summary>
        /// 是日期+时间
        /// </summary>
        IsDateTime,
        /// <summary>
        /// 是字母
        /// </summary>
        IsLetter,
        /// <summary>
        /// 是字母+数字
        /// </summary>
        IsLetterOrNumber,
        /// <summary>
        /// 是小写字母
        /// </summary>
        IsLowerLetterr,
        /// <summary>
        /// 是小写字母+数字
        /// </summary>
        IsLowerLetterrOrNumber,
        /// <summary>
        /// 是大写字母
        /// </summary>
        IsUpperLetterr,
        /// <summary>
        /// 是大写字母+数字
        /// </summary>
        IsUpperLetterrOrNumber,
        /// <summary>
        /// 是中文
        /// </summary>
        IsChinese,
        /// <summary>
        /// 是中文或字母或数字
        /// </summary>
        IsChineseOrLetterOrNumber,
        /// <summary>
        /// 是日文
        /// </summary>
        IsJapanese,
        /// <summary>
        /// 是日文或者字母或数字
        /// </summary>
        IsJapaneseOrLetterOrNumber,
        /// <summary>
        /// 中国身份证号
        /// </summary>
        IsIDCardForChina
    }
}
