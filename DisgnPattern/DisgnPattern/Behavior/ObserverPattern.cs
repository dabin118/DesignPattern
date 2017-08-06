using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Behavior
{
    //观察者模式定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象，这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己的行为。
    public class ObserverPattern
    {

        public static void Test()
        {

            //一般代码的实现观察者模式
            TenXun tenXun = new TenXunGame("腾讯游戏", "推送信息");

            // 添加订阅者
            tenXun.AddObserver(new Subscriber("Learning Hard"));
            tenXun.AddObserver(new Subscriber("Tom"));

            tenXun.Update();

            //用委托和时间来简化观察者模式

            TenXunDelegate tenXunDelegate = new TenXunGameDelegate("TenXun Game", "Have a new game published ....");
            SubscriberDelegate lh = new SubscriberDelegate("Learning Hard");
            SubscriberDelegate tom = new SubscriberDelegate("Tom");

            // 添加订阅者
            tenXunDelegate.AddObserver(new NotifyEventHandler(lh.ReceiveAndPrint));
            tenXunDelegate.AddObserver(new NotifyEventHandler(tom.ReceiveAndPrint));

            tenXunDelegate.Update();

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除Tom订阅者");
            tenXunDelegate.RemoveObserver(new NotifyEventHandler(tom.ReceiveAndPrint));
            tenXunDelegate.Update();



        }

    }

    //角色：
    //抽象主题角色（Subject）：抽象主题把所有观察者对象的引用保存在一个列表中，并提供增加和删除观察者对象的操作，抽象主题角色又叫做抽象被观察者角色，一般由抽象类或接口实现。
    //抽象观察者角色（Observer）：为所有具体观察者定义一个接口，在得到主题通知时更新自己，一般由抽象类或接口实现。
    //具体主题角色（ConcreteSubject）：实现抽象主题接口，具体主题角色又叫做具体被观察者角色。
    //具体观察者角色（ConcreteObserver）：实现抽象观察者角色所要求的接口，以便使自身状态与主题的状态相协调。



    //订阅者与订阅号逻辑：


    #region 代码实现
    // 订阅号抽象类
    public abstract class TenXun
    {
        // 保存订阅者列表
        private List<IObserver> observers = new List<IObserver>();
        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }
        #region 新增对订阅号列表的维护操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }
        #endregion

        public void Update()
        {
            // 遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }

    // 具体订阅号类：腾讯游戏订阅号
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info)
            : base(symbol, info)
        {
        }
    }

    // 订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    // 具体的订阅者类
    public class Subscriber : IObserver
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }


    #endregion


    #region 利用委托和事件来实现观察者模式

    // 委托充当订阅者接口类
    public delegate void NotifyEventHandler(object sender);

    public class TenXunDelegate
    {
        public NotifyEventHandler NotifyEvent;

        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXunDelegate(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        #region 新增对订阅号列表的维护操作
        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }
        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        #endregion

        public void Update()
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }


    // 具体订阅号类
    public class TenXunGameDelegate : TenXunDelegate
    {
        public TenXunGameDelegate(string symbol, string info)
            : base(symbol, info)
        {
        }
    }

    // 具体订阅者类
    public class SubscriberDelegate
    {
        public string Name { get; set; }
        public SubscriberDelegate(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(Object obj)
        {
            TenXunDelegate tenxun = obj as TenXunDelegate;

            if (tenxun != null)
            {
                Console.WriteLine("Notified Delegate {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
            }
        }
    }
    #endregion



}
