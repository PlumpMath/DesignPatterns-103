using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Common;

namespace Prototype.Tests.Common
{
    [TestClass]
    public class SerializedDeepCloneFixture
    {
        [Serializable]
        class UserInfo
        {
            public string Name;
            public IList<string> Education = new List<string>(); // 引用类型

            public UserInfo GetShallowCopy()
            {
                return (UserInfo)this.MemberwiseClone();
            }

            public UserInfo GetDeepCopy()
            {
                string graph = SerializationHelper.SerializeObjectToString(this);
                return SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
            }
        }

        /// <summary>
        /// 验证对可序列化类型进行浅表复制
        /// </summary>
        [TestMethod]
        public void ShallowCopyTest()
        {
            var user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            var user2 = user1.GetShallowCopy();
            // 验证可以完成某种程度的复制
            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            // 验证Shallow Copy方式下，没有对引用类型做出处理
            user2.Education[0] = "B";
            Assert.AreNotEqual<string>("A", user1.Education[0]);
        }

        
        [TestMethod]
        public void DeepCopyTest()
        {
            var user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            var user2 = user1.GetDeepCopy();
            // 验证可以完成某种程度的复制
            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            // 验证Deep Cope方式下，可以对引用类型作出处理
            user2.Education[0] = "B";
            Assert.AreEqual<string>("A", user1.Education[0]);
        }
    }
}
