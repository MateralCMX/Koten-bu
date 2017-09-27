using MateralTools.MVerify.Model;
using System;
using System.Collections.Generic;

namespace MateralTools.MVerify
{
    /// <summary>
    /// 验证码管理器
    /// </summary>
    public class VerifyCodeManager
    {
        /// <summary>
        /// 采用的类型
        /// </summary>
        public List<VerifyCodeType> HasType { get; set; }
        /// <summary>
        /// 采用类型
        /// </summary>
        private VerifyCodeType UseType;
        /// <summary>
        /// 文本类型配置对象
        /// </summary>
        public VerifyCodeTextConfigModel TextConfigM { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public VerifyCodeManager()
        {
            HasType = new List<VerifyCodeType>
            {
                VerifyCodeType.Text
            };
            TextConfigM = new VerifyCodeTextConfigModel();
        }
        /// <summary>
        /// 获得验证码模型
        /// </summary>
        /// <returns>验证码模型</returns>
        public VerifyCodeModel GetVeifyCodeModel()
        {
            ChoiceType();
            VerifyCodeModel resM;
            switch (UseType)
            {
                case VerifyCodeType.Text:
                    resM = GetVeifyCodeTextModel();
                    break;
                case VerifyCodeType.ProblemAnswer:
                    resM = GetVeifyCodeTextModel();
                    break;
                case VerifyCodeType.FillInBlanks:
                    resM = GetVeifyCodeTextModel();
                    break;
                case VerifyCodeType.Select:
                    resM = GetVeifyCodeTextModel();
                    break;
                default:
                    resM = GetVeifyCodeTextModel();
                    break;
            }
            return resM;
        }
        /// <summary>
        /// 选择一个类型使用
        /// </summary>
        private void ChoiceType()
        {
            int Count = HasType.Count;
            if (Count > 0)
            {
                Random rd = new Random();
                UseType = HasType[rd.Next(0, Count)];
            }
            else
            {
                throw new VerifyCodeException("请先配置想使用的类型");
            }
        }
        /// <summary>
        /// 获得文字验证码对象
        /// </summary>
        /// <returns></returns>
        private VerifyCodeTextModel GetVeifyCodeTextModel()
        {
            VerifyCodeTextModel vctM = new VerifyCodeTextModel(TextConfigM);
            return vctM;
        }
    }
}
