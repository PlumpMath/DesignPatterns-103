using System;
using System.Diagnostics;
using System.Linq;
using MedikzWorks.PracticalPattern.CoR.NoChain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.CoR;

namespace CoR.Tests.NoChain
{
    [TestClass]
    public class HandlerFixture
    {
        const double OriginalPrice = 100;
        Request mailRequest;

        [TestInitialize]
        public void Initialize()
        {
            mailRequest = new Request
            {
                Option = RequestOptions.Purchase,
                Price = 100,
                Type = PurchaseType.Mail
            };
        }

        /// <summary>
        /// 验证购买过程处理CoR
        /// </summary>
        [TestMethod]
        public void TestPurchaseHandlerCoR()
        {
            Trace.Write("验证购买过程处理CoR");
            var head = new HandlerCoRFactory().CreateHandlerCoR(RequestOptions.Purchase);
            Assert.AreEqual<int>(4, head.Count());
            head.ToList().ForEach(x => x.HandleRequest(mailRequest));
            Assert.AreEqual<double>(OriginalPrice * 1.3, mailRequest.Price);
        }

        /// <summary>
        /// 验证退货情况
        /// </summary>
        [TestMethod]
        public void TestReturnHandlerCoR()
        {
            Trace.WriteLine("验证退货过程处理CoR");
            var head = new HandlerCoRFactory().CreateHandlerCoR(RequestOptions.Return);
            Assert.AreEqual<int>(4, head.Count());
            head.ToList().ForEach(x => x.HandleRequest(mailRequest));
            Assert.AreEqual<double>(OriginalPrice, mailRequest.Price);
        }

        
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestCannotReturnHandlerCoR()
        {
            Trace.Write("验证不能退货的情况CoR");
            var discountRequest = new Request()
            {
                Option = RequestOptions.Return,
                Price = OriginalPrice,
                Type = PurchaseType.Discount
            };
            new HandlerCoRFactory().CreateHandlerCoR(RequestOptions.Return).ToList()
                .ForEach(x => x.HandleRequest(discountRequest));
        }
    }
}
