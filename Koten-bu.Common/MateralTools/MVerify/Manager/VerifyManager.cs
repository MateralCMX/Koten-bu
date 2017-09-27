using MateralTools.MVerify.Data;
using MateralTools.MVerify.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MateralTools.MVerify
{
    /// <summary>
    /// 验证管理类
    /// </summary>
    public class VerifyManager
    {
        #region 方法
        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="InputStr">要验证的字符串</param>
        /// <param name="REGStr">验证正则表达式</param>
        /// <param name="Perfect">验证整个字符串</param>
        /// <returns></returns>
        public static bool VerifyStr(string InputStr, string REGStr, bool Perfect = false)
        {
            if (!string.IsNullOrEmpty(InputStr) && !string.IsNullOrEmpty(REGStr))
            {
                if (Perfect)
                {
                    return Regex.IsMatch(InputStr, VerifyData.GetPerfectRegStr(REGStr));
                }
                else
                {
                    return Regex.IsMatch(InputStr, REGStr);
                }
            }
            return false;
        }
        /// <summary>
        /// 获得所有匹配的字符串
        /// </summary>
        /// <param name="InputStr">要验证的字符串</param>
        /// <param name="REGStr">验证正则表达式</param>
        /// <param name="Perfect">验证整个字符串</param>
        /// <returns></returns>
        public static MatchCollection GetVerifyStr(string InputStr, string REGStr, bool Perfect = false)
        {
            if (VerifyInputStr(InputStr, REGStr))
            {
                if (Perfect)
                {
                    return Regex.Matches(InputStr, VerifyData.GetPerfectRegStr(REGStr));
                }
                else
                {
                    return Regex.Matches(InputStr, REGStr);
                }
            }
            return null;
        }
        /// <summary>
        /// 验证输入字符串和正则表达式是否为空
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <param name="REGStr">正则表达式</param>
        /// <returns></returns>
        private static bool VerifyInputStr(string InputStr, string REGStr)
        {
            bool IsOK = false;
            if (!string.IsNullOrEmpty(InputStr))
            {
                if (!string.IsNullOrEmpty(REGStr))
                {
                    IsOK = true;
                }
            }
            return IsOK;
        }
        #endregion
        #region 简单验证
        /// <summary>
        /// 验证输入字符串是否为IPv4地址(无端口号)
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是IPv4地址(无端口号)
        /// false不是IPv4地址(无端口号)
        /// </returns>
        public static bool IsIPv4(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_IPv4, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的IPv4地址(无端口号)
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的IPv4地址(无端口号)
        /// </returns>
        public static MatchCollection GetIPv4InStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_IPv4, false);
        }
        /// <summary>
        /// 验证输入字符串是否为IPv4地址(带端口号)
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是IPv4地址(带端口号)
        /// false不是IPv4地址(带端口号)
        /// </returns>
        public static bool IsIPv4AndPort(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_IPv4_Port, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的IPv4地址(带端口号)
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的IPv4地址(带端口号)
        /// </returns>
        public static MatchCollection GetIPv4AndPortInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_IPv4_Port, false);
        }
        /// <summary>
        /// 验证输入字符串是否为邮箱
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是邮箱
        /// false不是邮箱
        /// </returns>
        public static bool IsEMail(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_EMail, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的邮箱
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的邮箱
        /// </returns>
        public static MatchCollection GetEMailInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_EMail, false);
        }
        /// <summary>
        /// 验证输入字符串是否为实数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是实数
        /// false不是实数
        /// </returns>
        public static bool IsRealNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_RealNumber, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的实数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的实数
        /// </returns>
        public static MatchCollection GetRealNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_RealNumber, false);
        }
        /// <summary>
        /// 验证输入字符串是否为正实数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是正实数
        /// false不是正实数
        /// </returns>
        public static bool IsRealNumberPositive(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_RealNumber_Positive, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的正实数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的正实数
        /// </returns>
        public static MatchCollection GetRealNumberPositiveInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_RealNumber_Positive, false);
        }
        /// <summary>
        /// 验证输入字符串是否为负实数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是负实数
        /// false不是负实数
        /// </returns>
        public static bool IsRealNumberNegative(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_RealNumber_Negative, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的负实数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的负实数
        /// </returns>
        public static MatchCollection GetRealNumberNegativeInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_RealNumber_Negative, false);
        }
        /// <summary>
        /// 验证输入字符串是否为整数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是整数
        /// false不是整数
        /// </returns>
        public static bool IsInteger(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Integer, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的整数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的整数
        /// </returns>
        public static MatchCollection GetIntegerInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Integer, false);
        }
        /// <summary>
        /// 验证输入字符串是否为正整数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是正整数
        /// false不是正整数
        /// </returns>
        public static bool IsIntegerPositive(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Integer_Positive, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的正整数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的正整数
        /// </returns>
        public static MatchCollection GetIntegerPositiveInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Integer_Positive, false);
        }
        /// <summary>
        /// 验证输入字符串是否为负整数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是负整数
        /// false不是负整数
        /// </returns>
        public static bool IsIntegerNegative(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Integer_Negative, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的负整数
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的负整数
        /// </returns>
        public static MatchCollection GetIntegerNegativeInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Integer_Negative, false);
        }
        /// <summary>
        /// 验证输入字符串是否为URL地址
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是URL地址
        /// false不是URL地址
        /// </returns>
        public static bool IsURL(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_URL, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的URL地址
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的URL地址
        /// </returns>
        public static MatchCollection GetURLInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_URL, false);
        }
        /// <summary>
        /// 验证输入字符串是否为相对路径
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是相对路径
        /// false不是相对路径
        /// </returns>
        public static bool IsRelativePath(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_RelativePath, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的相对路径
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的相对路径
        /// </returns>
        public static MatchCollection GetRelativePathInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_RelativePath, false);
        }
        /// <summary>
        /// 验证输入字符串是否为文件名
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是文件名
        /// false不是文件名
        /// </returns>
        public static bool IsFileName(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_FileName, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的文件名
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的文件名
        /// </returns>
        public static MatchCollection GetFileNameInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_FileName, false);
        }
        /// <summary>
        /// 验证输入字符串是否为手机号码
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是手机号码
        /// false不是手机号码
        /// </returns>
        public static bool IsPhoneNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_PhoneNumber, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的手机号码
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的手机号码
        /// </returns>
        public static MatchCollection GetPhoneNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_PhoneNumber, false);
        }
        /// <summary>
        /// 验证输入字符串是否为日期
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是日期
        /// false不是日期
        /// </returns>
        public static bool IsDate(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Date, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的日期
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的日期
        /// </returns>
        public static MatchCollection GetDateInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Date, false);
        }
        /// <summary>
        /// 验证输入字符串是否为时间
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是时间
        /// false不是时间
        /// </returns>
        public static bool IsTime(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Time, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的时间
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的时间
        /// </returns>
        public static MatchCollection GetTimeInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Time, false);
        }
        /// <summary>
        /// 验证输入字符串是否为日期和时间
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是日期和时间
        /// false不是日期和时间
        /// </returns>
        public static bool IsDateTime(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_DateTime, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的日期和时间
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的日期和时间
        /// </returns>
        public static MatchCollection GetDateTimeInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_DateTime, false);
        }
        /// <summary>
        /// 验证输入字符串是否为字母
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是字母
        /// false不是字母
        /// </returns>
        public static bool IsLetter(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Letter, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的字母
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的字母
        /// </returns>
        public static MatchCollection GetLetterInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Letter, false);
        }
        /// <summary>
        /// 验证输入字符串是否为字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是字母或数字
        /// false不是字母或数字
        /// </returns>
        public static bool IsLetterOrNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Letter_Number, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的字母或数字
        /// </returns>
        public static MatchCollection GetLetterOrNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Letter_Number, false);
        }
        /// <summary>
        /// 验证输入字符串是否为小写字母
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是字母
        /// false不是字母
        /// </returns>
        public static bool IsLowerLetterr(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_LowerLetter, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的小写字母
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的字母
        /// </returns>
        public static MatchCollection GetLowerLetterInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_LowerLetter, false);
        }
        /// <summary>
        /// 验证输入字符串是否为小写字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是字母
        /// false不是字母
        /// </returns>
        public static bool IsLowerLetterrOrNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_LowerLetter_Number, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的小写字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的字母
        /// </returns>
        public static MatchCollection GetLowerLetterOrNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_LowerLetter_Number, false);
        }
        /// <summary>
        /// 验证输入字符串是否为大写字母
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是字母
        /// false不是字母
        /// </returns>
        public static bool IsUpperLetterr(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_UpperLetter, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的大写字母
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的字母
        /// </returns>
        public static MatchCollection GetUpperLetterInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_UpperLetter, false);
        }
        /// <summary>
        /// 验证输入字符串是否为大写字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是字母
        /// false不是字母
        /// </returns>
        public static bool IsUpperLetterrOrNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_UpperLetter_Number, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的大写字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的字母
        /// </returns>
        public static MatchCollection GetUpperLetterOrNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_UpperLetter_Number, false);
        }
        /// <summary>
        /// 验证输入字符串是否为中文
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是中文
        /// false不是中文
        /// </returns>
        public static bool IsChinese(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Chinese, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的中文
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的中文或数字
        /// </returns>
        public static MatchCollection GetChineseInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Chinese, false);
        }
        /// <summary>
        /// 验证输入字符串是否为中文或字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是中文或字母或数字
        /// false不是中文或字母或数字
        /// </returns>
        public static bool IsChineseOrLetterOrNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Chinese_Letter_Number, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的中文或字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的中文或字母或数字
        /// </returns>
        public static MatchCollection GetChineseOrLetterOrNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Chinese_Letter_Number, false);
        }
        /// <summary>
        /// 验证输入字符串是否为日文
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是日文
        /// false不是日文
        /// </returns>
        public static bool IsJapanese(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Japanese, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的日文
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的日文或数字
        /// </returns>
        public static MatchCollection GetJapaneseInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Japanese, false);
        }
        /// <summary>
        /// 验证输入字符串是否为日文或字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是日文或字母或数字
        /// false不是日文或字母或数字
        /// </returns>
        public static bool IsJapaneseOrLetterOrNumber(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_Japanese_Letter_Number, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的日文或字母或数字
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的日文或字母或数字
        /// </returns>
        public static MatchCollection GetJapaneseOrLetterOrNumberInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_Japanese_Letter_Number, false);
        }
        #endregion
        #region 复杂验证
        /// <summary>  
        /// 验证输入字符串是否为(中国)身份证 
        /// </summary>  
        /// <param name="InputStr">输入的字符串</param>
        /// <param name="Accurate">详细验证</param>  
        /// <returns>
        /// true是(中国)身份证
        /// false不是(中国)身份证
        /// </returns>
        public static bool IsIDCardForChina(string InputStr, bool Accurate = false)
        {
            if (!string.IsNullOrEmpty(InputStr))
            {
                if (InputStr.Length == 18)
                {
                    if (Accurate)
                    {
                        return CheckIDCard18(InputStr);
                    }
                    else
                    {
                        return IsIDCard18ForChina(InputStr);
                    }
                }
                else if (InputStr.Length == 15)
                {
                    if (Accurate)
                    {
                        return CheckIDCard15(InputStr);
                    }
                    else
                    {
                        return IsIDCard15ForChina(InputStr);
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 验证输入字符串是否为(中国)身份证18位
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是(中国)身份证18位
        /// false不是(中国)身份证18位
        /// </returns>
        public static bool IsIDCard18ForChina(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_IDCard_18_China, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的(中国)身份证18位
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的(中国)身份证18位
        /// </returns>
        public static MatchCollection GetIDCard18ForChinaInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_IDCard_18_China, false);
        }
        /// <summary>
        /// 验证输入字符串是否为(中国)身份证15位
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// true是(中国)身份证15位
        /// false不是(中国)身份证15位
        /// </returns>
        public static bool IsIDCard15ForChina(string InputStr)
        {
            return VerifyStr(InputStr, VerifyData.REG_IDCard_15_China, true);
        }
        /// <summary>
        /// 获取输入字符串中所有的(中国)身份证15位
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的(中国)身份证15位
        /// </returns>
        public static MatchCollection GetIDCard15ForChinaInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_IDCard_15_China, false);
        }
        /// <summary>  
        /// 18位身份证号码验证  
        /// </summary>  
        /// <param name="IDNumber">身份证号码</param>
        /// <returns>
        ///     true验证成功
        ///     false验证失败
        /// </returns>
        private static bool CheckIDCard18(string IDNumber)
        {
            long n = 0;
            if (long.TryParse(IDNumber.Remove(17), out n) == false
                || n < Math.Pow(10, 16) || long.TryParse(IDNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证  
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(IDNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = IDNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证  
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = IDNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != IDNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证  
            }
            return true;//符合GB11643-1999标准  
        }
        /// <summary>  
        /// 15位身份证号码验证  
        /// </summary>  
        /// <param name="IDNumber">身份证号码</param>
        /// <returns>
        ///     true验证成功
        ///     false验证失败
        /// </returns> 
        private static bool CheckIDCard15(string IDNumber)
        {
            long n = 0;
            if (long.TryParse(IDNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证  
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(IDNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = IDNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证  
            }
            return true;
        }
        /// <summary>
        /// 验证输入字符串是否为磁盘根目录
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <param name="IsReal">验证真实的磁盘路径</param>
        /// <returns>
        /// true是磁盘根目录
        /// false不是磁盘根目录
        /// </returns>
        public static bool IsDiskPath(string InputStr, bool IsReal = false)
        {
            bool IsOk = false;
            if (VerifyStr(InputStr, VerifyData.REG_DiskPath, true))
            {
                if (IsReal)
                {
                    if (InputStr.Length == 2)
                    {
                        InputStr += "\\";
                    }
                    else if (InputStr.Last() != '\\')
                    {
                        InputStr = InputStr.Substring(0, 2) + "\\";
                    }
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    foreach (DriveInfo Disk in allDrives)
                    {
                        if (Disk.Name == InputStr)
                        {
                            IsOk = true;
                            break;
                        }
                    }
                }
                else
                {
                    IsOk = true;
                }
            }
            return IsOk;
        }
        /// <summary>
        /// 获取输入字符串中所有的磁盘根目录
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的磁盘根目录
        /// </returns>
        public static MatchCollection GetDiskPathInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_DiskPath, false);
        }

        /// <summary>
        /// 验证输入字符串是否为绝对路径
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <param name="IsReal">验证真实的磁盘路径</param>
        /// <returns>
        /// true是绝对路径
        /// false不是绝对路径
        /// </returns>
        public static bool IsAbsolutePath(string InputStr, bool IsReal = false)
        {
            bool IsOK = false;
            if (VerifyStr(InputStr, VerifyData.REG_AbsolutePath, true))
            {
                int Length = InputStr.Length;
                string DiskPath;
                if (Length >= 3)
                {
                    DiskPath = InputStr.Substring(0, 3);
                }
                else
                {
                    DiskPath = InputStr;
                }
                IsOK = IsDiskPath(DiskPath, IsReal);
            }
            return IsOK;
        }
        /// <summary>
        /// 获取输入字符串中所有的绝对路径
        /// </summary>
        /// <param name="InputStr">输入的字符串</param>
        /// <returns>
        /// 字符串中所有的绝对路径
        /// </returns>
        public static MatchCollection GetAbsolutePathInStr(string InputStr)
        {
            return GetVerifyStr(InputStr, VerifyData.REG_AbsolutePath, false);
        }
        #endregion
        #region 验证输入
        /// <summary>
        /// 验证传入对象不是NULL
        /// 字符串：不是NULL或为""
        /// </summary>
        /// <param name="inputObj">输入对象</param>
        /// <returns>验证结果</returns>
        public static bool IsNotNullOrEmpty(object inputObj)
        {
            if (inputObj != null)
            {
                if (inputObj is String)
                {
                    if (!String.IsNullOrEmpty((String)inputObj))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        ///// <summary>
        ///// 验证Request参数是否合法
        ///// </summary>
        ///// <param name="Request">Http</param>
        ///// <param name="WhiteListVerfyType">验证类型</param>
        ///// <param name="WhiteList">白名单</param>
        ///// <param name="ErrorMessages">对应报错信息</param>
        ///// <param name="ErrorMessage">反馈信息</param>
        ///// <returns>验证结果</returns>
        //public static bool VerifyInput(HttpRequestBase Request, VerfyType WhiteListVerfyType, string[] WhiteList, string[] ErrorMessages, out string ErrorMessage)
        //{
        //    ErrorMessage = "通过验证";
        //    bool IsOK = true;
        //    int count = WhiteList.Length;
        //    if (count == ErrorMessages.Length)
        //    {
        //        for (int i = 0; i < count; i++)
        //        {
        //            switch (WhiteListVerfyType)
        //            {
        //                case VerfyType.NotNull:
        //                    if (Request.Params[WhiteList[i]] == null)
        //                    {
        //                        IsOK = false;
        //                        ErrorMessage = ErrorMessages[i];
        //                        break;
        //                    }
        //                    break;
        //                case VerfyType.NotNullAndEmpty:
        //                    if (!IsNotNullOrEmpty(Request.Params[WhiteList[i]]))
        //                    {
        //                        IsOK = false;
        //                        ErrorMessage = ErrorMessages[i];
        //                        break;
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    return IsOK;
        //}
        ///// <summary>
        ///// 验证Request参数是否合法
        ///// </summary>
        ///// <param name="Request">Http请求</param>
        ///// <param name="WhiteListVerfyType">验证类型</param>
        ///// <param name="VerfyM">需要验证的实体</param>
        ///// <param name="ErrorMessage">反馈信息</param>
        ///// <returns>验证结果</returns>
        //public static bool VerifyInput(HttpRequestBase Request, VerfyType WhiteListVerfyType, List<VerifyModel> VerfyM, out string ErrorMessage)
        //{
        //    ErrorMessage = "通过验证";
        //    bool IsOK = true;
        //    int count = VerfyM.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        switch (WhiteListVerfyType)
        //        {
        //            case VerfyType.NotNull:
        //                if (Request.Params[VerfyM[i].Name] == null)
        //                {
        //                    IsOK = false;
        //                    ErrorMessage = VerfyM[i].ErrorMessage;
        //                    break;
        //                }
        //                break;
        //            case VerfyType.NotNullAndEmpty:
        //                if (!IsNotNullOrEmpty(Request.Params[VerfyM[i].Name]))
        //                {
        //                    IsOK = false;
        //                    ErrorMessage = VerfyM[i].ErrorMessage;
        //                    break;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return IsOK;
        //}
        ///// <summary>
        ///// 验证模型对象参数是否合法
        ///// </summary>
        ///// <param name="obj">模型对象</param>
        ///// <param name="WhiteListVerfyType">验证类型</param>
        ///// <param name="VerfyM">需要验证的实体</param>
        ///// <param name="ErrorMessage">反馈信息</param>
        ///// <returns>验证结果</returns>
        //public static bool VerifyModelObject<T>(T obj, VerfyType WhiteListVerfyType, List<VerifyModel> VerfyM, out string ErrorMessage)
        //{
        //    ErrorMessage = "通过验证";
        //    bool IsOK = true;
        //    int count = VerfyM.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        object value = obj.GetType().GetProperty(VerfyM[i].Name).GetValue(obj, null);
        //        switch (WhiteListVerfyType)
        //        {
        //            case VerfyType.NotNull:
        //                if (value == null)
        //                {
        //                    IsOK = false;
        //                    ErrorMessage = VerfyM[i].ErrorMessage;
        //                    break;
        //                }
        //                break;
        //            case VerfyType.NotNullAndEmpty:
        //                if (!IsNotNullOrEmpty(value))
        //                {
        //                    IsOK = false;
        //                    ErrorMessage = VerfyM[i].ErrorMessage;
        //                    break;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return IsOK;
        //}
        #endregion
    }
}
