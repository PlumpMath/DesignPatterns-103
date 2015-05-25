using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.FluentInterface
{
    public class Currency
    {
        /// <summary>
        /// 货币代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 货币名称
        /// </summary>
        public string Name { get; set; }
    }

    public interface IDataFacade
    {
        /// <summary>
        /// 根据筛选条件执行查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<Currency> ExecuteQuery(Func<Currency, bool> filter);

        /// <summary>
        /// 追加新的货币记录
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IDataFacade AddNewCurrency(string code, string name);
    }
}
