using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MedikzWorks.PracticalPattern.CoR.Classic;
using MedikzWorks.PracticalPattern.CoR;

namespace CoR.Tests
{
    [TestClass]
    public class HandlerFixture
    {
        [TestMethod]
        public void Test()
        {
            Trace.WriteLine("Process via whole CoR");
            // 生成并组装链式的结构 internal->discount->mail->regular->null
            var head = new InternalHandler()
            {
                Successor = new DiscountHandler()
                {
                    Successor = new MailHandler()
                    {
                        Successor = new RegularHandler()
                    }
                }
            };

            var request = new Request { Price = 20, Type = PurchaseType.Mail };
            head.HandleRequest(request);
            Assert.AreEqual<double>(20 * 1.3, request.Price);
            request = new Request() { Price = 20, Type = PurchaseType.Discount };
            head.HandleRequest(request);
            Assert.AreEqual<double>(20 * 0.9, request.Price);

            Trace.WriteLine("\n\nProcess via rearranged CoR");
            var discountHandler = head.Successor;
            head.Successor = head.Successor.Successor;
            discountHandler = null;
            request = new Request() { Price = 20, Type = PurchaseType.Discount };
            head.HandleRequest(request);

            Assert.AreEqual<double>(20, request.Price);
        }
    }
}
