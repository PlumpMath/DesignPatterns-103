﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Remoting.Messaging;

namespace MedikzWorks.PracticalPattern.Common
{
    public enum FormatterType
    {
        /// <summary>
        /// SOAP消息格式编码
        /// </summary>
        Soap,

        /// <summary>
        /// 二进制消息格式编码
        /// </summary>
        Binary
    }

    /// <summary>
    /// Utility for serialization
    /// </summary>
    public static class SerializationHelper
    {
        const FormatterType DefaultFormatterType = FormatterType.Binary;

        /// <summary>
        /// 按照串行化的编码要求，生成对应的编码器
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        static IRemotingFormatter GetFormatter(FormatterType formatterType)
        {
            switch(formatterType)
            {
                case FormatterType.Binary:
                    return new BinaryFormatter();
                case FormatterType.Soap:
                    return new SoapFormatter();
            }
            throw new NotSupportedException();
        }

        /// <summary>
        /// 把对象序列化转换为字符串
        /// </summary>
        /// <param name="graph">可串行化对象实例</param>
        /// <param name="formatter">消息格式编码类型(Soap或Binary类)</param>
        /// <returns></returns>
        /// <remarks>
        ///     调用BinaryFormatter或SoapFormatter的Serialize方法实现主要转换过程
        /// </remarks>
        public static string SerializeObjectToString(object graph, FormatterType formatterType = DefaultFormatterType)
        {
            using(var memoryStream = new MemoryStream())
            {
                var formatter = GetFormatter(formatterType);
                formatter.Serialize(memoryStream, graph);
                var arrGraph = memoryStream.ToArray();
                return Convert.ToBase64String(arrGraph);
            }
        }

        public static T DeserializeStringToObject<T>(string graph,FormatterType formatterType = DefaultFormatterType)
        {
            var arrGraph = Convert.FromBase64String(graph);
            using(var memoryStream = new MemoryStream(arrGraph))
            {
                var formatter = GetFormatter(formatterType);
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}
