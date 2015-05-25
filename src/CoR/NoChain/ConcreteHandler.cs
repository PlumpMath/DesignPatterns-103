using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.CoR.NoChain
{
    public class InternalHandler:HandlerBase
    {
        public InternalHandler()
        {
            Type = PurchaseType.Internal;
            Option = RequestOptions.Purchase | RequestOptions.Return;
        }
        public override void Process(Request request)
        {
            request.Price *= 0.6;
        }
    }

    public class MailPurcahseHandler:HandlerBase
    {
        public MailPurcahseHandler()
        {
            Type = PurchaseType.Mail;
            Option = RequestOptions.Purchase;
        }
        public override void Process(Request request)
        {
            request.Price *= 1.3;
        }
    }

    public class MailReturnHandler:HandlerBase
    {
        public MailReturnHandler()
        {
            Type = PurchaseType.Mail;
            Option = RequestOptions.Return;
        }
    }

    public class DiscountPurchaseHandler:HandlerBase
    {
        public DiscountPurchaseHandler()
        {
            Type = PurchaseType.Discount;
            Option = RequestOptions.Purchase;
        }
        public override void Process(Request request)
        {
            request.Price *= 0.9;
        }
    }

    public class DiscountReturnHandler:HandlerBase
    {
        public DiscountReturnHandler()
        {
            Type = PurchaseType.Discount;
            Option = RequestOptions.Return;
        }
        public override void Process(Request request)
        {
            throw new NotSupportedException();
        }
    }

    public class RegularHandler:HandlerBase
    {
        public RegularHandler()
        {
            Type = PurchaseType.Regular;
            Option = RequestOptions.Purchase | RequestOptions.Return;
        }


    }
}
