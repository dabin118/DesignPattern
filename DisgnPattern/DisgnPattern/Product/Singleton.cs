using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Product
{
    class Singleton
    {
        // 定义一个静态变量来保存类的实例
        private static Singleton uniqueInstance;

        //定义私有构造函数，让外界不能创建该类的实例
        private Singleton()
        { }

        #region  版本1
        ////单例模式的实现在单线程下确实是完美的,然而在多线程的情况下会得到多个Singleton实例,
        ////因为在两个线程同时运行GetInstance方法时，此时两个线程判断(uniqueInstance ==null)这个条件时都返回真
        ////多线程的解决方案自然就是使GetInstance方法在同一时间只运行一个线程运行
        ////线程同步
        //public static Singleton GetInstance()
        //{
        //    if (uniqueInstance == null)
        //    {
        //        uniqueInstance = new Singleton();
        //    }
        //    return uniqueInstance;
        //}

        #endregion

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        #region 版本2

        //// 问题：对于每个线程都会对 线程辅助对象locker加锁之后再判断实例是否存在，完全没有必要，增加了额外的开销
        ////因为当第一个线程创建了实例了之后，后面的线程只要 判断 uniqueInstance==null 为 false ，没有必要对 locker加锁之后再去判断
        //public static Singleton GetInstance()
        //{
        //    lock (locker)
        //    {
        //        if (uniqueInstance == null)
        //        {
        //            uniqueInstance = new Singleton();

        //        }
        //    }
        //    return uniqueInstance;
        //}

        #endregion

        //版本3
        //只要在lock语句前面加一句（uniqueInstance==null）的判断就可以避免锁所增加的额外开销，这种实现方式我们就叫它 “双重锁定”
        public static Singleton GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            //双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();

                    }
                }
            }
            return uniqueInstance;
        }


    }
}
