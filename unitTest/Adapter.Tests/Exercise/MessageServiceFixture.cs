using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Adapter.Tests.Exercise
{
    /// <summary>
    /// 队列访问接口
    /// </summary>
    interface IQueue
    {
        XmlDocument Peek();
        XmlDocument Dequeue();
    }

    /// <summary>
    /// 各在线业务数据实体的基类
    /// </summary>
    abstract class EntryBase { }

    interface IEntryDataConverter
    {
        DataRow ToDataRow(EntryBase entry);
    }

    /// <summary>
    /// 数据库访问接口
    /// </summary>
    interface IDatabase
    {
        IEntryDataConverter DataConverter { get; set; }
        void Write(EntryBase entry);
        void Write(IEnumerable<EntryBase> entries);
    }

    [TestClass]
    public class MessageServiceFixture
    {
        #region 模拟用的队列产品及其适配器
        class Msmq
        {
            string current;

            /// <summary>
            /// 不兼容的接口，相当于Peek()
            /// </summary>
            public string Head
            {
                get
                {
                    Trace.WriteLine("Msmq.Head");
                    current = Guid.NewGuid().ToString();
                    return current;
                }
            }

            /// <summary>
            /// 不兼容的接口，相当于Dequeue()
            /// </summary>
            /// <returns></returns>
            public string GetHead()
            {
                Trace.WriteLine("Msmq.GetHead()");
                var result = current;
                current = string.Empty;
                return result;
            }
        }

        class MsmqAdapter:IQueue
        {
            Msmq queue = new Msmq();
            
            public XmlDocument Peek()
            {
                Trace.WriteLine("MsmqAdapter.Peek()");
                Trace.WriteLine(queue.Head);
                return null;
            }

            public XmlDocument Dequeue()
            {
                Trace.WriteLine("MsmqAdapter.Dequeue()");
                Trace.WriteLine("queue.GetHead()");
                return null;
            }
        }

        class IbmMq:Queue<string>
        {
            string lastest;

            public new string Peek()
            {
                lastest = Guid.NewGuid().ToString();
                base.Enqueue(lastest);
                Trace.WriteLine("IbmMq.Peek()");
                return base.Peek();
            }

            public new string Dequeue()
            {
                Trace.WriteLine("IbmMq.Dequeue()");
                return base.Dequeue();
            }
        }

        class IbmMqAdapter:IQueue
        {
            IbmMq queue = new IbmMq();
            
            public XmlDocument Peek()
            {
                Trace.WriteLine("IbmMqAdapter.Peek()");
                Trace.WriteLine("Message:"+queue.Peek());
                return null;
            }

            public XmlDocument Dequeue()
            {
                Trace.WriteLine("IbmMqAdapter.Dequeue()");
                Trace.WriteLine("Message:"+queue.Dequeue());
                return null;
            }
        }

        #endregion

        #region 模拟用的数据库产品接口
        class OracleDB
        {
            public void WriteData(string[][] data)
            {
                Trace.WriteLine("OracleDb.WriteData(string[][] data)");
            }
        }

        class SqlServer
        {
            public void ExecuteNonSql(DataSet data)
            {
                Trace.WriteLine("SqlServer.ExecuteNonSql(DataSet data)");
            }

            public void InsertOneRecord(DataRow data)
            {
                Trace.WriteLine("SqlServer.InsertOneRecord(DataRow data)");
            }
        }

        class MySqlDatabase
        {
            public void ExecuteCommand(string sql)
            {
                Trace.WriteLine("MySqlDatabase.ExecuteCommand(string sql)");
            }
        }

        #endregion

        #region 模拟用的各类示例的业务实体
        class Order : EntryBase { }
        class DeliveryOrder : EntryBase { }
        class WarehouseEntry : EntryBase { }
        class InventoryList : EntryBase { }

        #endregion

        #region 模拟的数据适配接口以及面向个人业务实体类型的实体数据适配类型

        interface IMessageConverter
        {
            IEnumerable<EntryBase> ConvertMessageToQuerable(XmlDocument message);
        }

        abstract class DatabaseAdapterBase:IDatabase
        {
            public IEntryDataConverter DataConverter { get; set; }

            public abstract void WriteData(DataRow row);
            public abstract void WriteData(IEnumerable<DataRow> rows);

            public virtual void Write(EntryBase entry)
            {
                if (DataConverter == null)
                    throw new NullReferenceException("DataConverter");
                Trace.WriteLine("DatabaseAdapterBase.Write(EntryBase entry)");

                WriteData(new DataTable().NewRow());
            }

            public virtual void Write(IEnumerable<EntryBase> entries)
            {
                if (DataConverter == null)
                    throw new NullReferenceException("DataConverter");
                Trace.WriteLine("DatabaseAdapterBase.Write(IEnumerable<EntryBase> entries");

                WriteData(new List<DataRow>());
            }
        }

        /*class OracleAdapter:DatabaseAdapterBase
        {
            OracleDB db = new OracleDB();
            public override void WriteData(DataRow row)
            {
                Trace.WriteLine("OralceAdapter.WriteData(DataRow row)");
                //  将datarow变成string[0][], 然后提交OracleDb.WriteData(string[][] data)
                Trace.WriteLine("DataRow -> string[][]");
                db.WriteData(null);
            }
        }*/

        #endregion

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
