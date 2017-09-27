using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateralTools.MVerify.Model
{
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum VerifyCodeType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text,
        /// <summary>
        /// 问题答案
        /// </summary>
        ProblemAnswer,
        /// <summary>
        /// 填空
        /// </summary>
        FillInBlanks,
        /// <summary>
        /// 选择
        /// </summary>
        Select
    }
}
