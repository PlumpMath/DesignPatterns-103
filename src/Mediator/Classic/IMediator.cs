﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Mediator.Classic
{
    /// <summary>
    /// 抽象中介者接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMediator<T>
    {
        /// <summary>
        /// 提供给IColleague的触发方法
        /// </summary>
        void Change();

        /// <summary>
        /// 建立协作关系的方法
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="consumers"></param>
        void Introduce(IColleague<T> provider, IEnumerable<IColleague<T>> consumers);
        void Introduce(IColleague<T> provider, IColleague<T> consumer);
        void Introduce(IColleague<T> provider, params IColleague<T>[] consumers);
    }
}
