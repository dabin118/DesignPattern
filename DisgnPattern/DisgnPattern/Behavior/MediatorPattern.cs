using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Behavior
{
    ///　中介者模式，定义了一个中介对象来封装一系列对象之间的交互关系。
    ///　中介者使各个对象之间不需要显式地相互引用，从而使耦合性降低，而且可以独立地改变它们之间的交互行为。

    public class MediatorPattern
    {
        public static void Test()
        {
            #region  一般实现方法

            Console.WriteLine("=================一般实现方法=================");
            AbstractCardPartner A = new ParterA();
            A.MoneyCount = 20;
            AbstractCardPartner B = new ParterB();
            B.MoneyCount = 20;

            // A 赢了则B的钱就减少
            A.ChangeCount(5, B);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            // B赢了A的钱也减少
            B.ChangeCount(10, A);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount); // 应该是15
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25

            #endregion

            #region 中介者实现方法

            Console.WriteLine("=================中介者实现方法=================");

            AbstractMediatorCardPartner a = new ParterMediatorA();
            AbstractMediatorCardPartner b = new ParterMediatorB();
            // 初始钱
            a.MoneyCount = 20;
            b.MoneyCount = 20;

            AbstractMediator mediator = new MediatorPater(a, b);

            // A赢了
            a.ChangeCount(5, mediator);
            Console.WriteLine("A 现在的钱是：{0}", a.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", b.MoneyCount); // 应该是15

            // B 赢了
            b.ChangeCount(10, mediator);
            Console.WriteLine("A 现在的钱是：{0}", a.MoneyCount);// 应该是15
            Console.WriteLine("B 现在的钱是：{0}", b.MoneyCount); // 应该是25
            Console.Read();
            #endregion


            #region  利用观察者模式和状态者模式来完善中介者模式


            Console.WriteLine("=====利用观察者模式和状态者模式来完善中介者模式====");
            AbstractStateCardPartner Aa = new ParterStateA();
            AbstractStateCardPartner Bb = new ParterStateB();
            // 初始钱
            Aa.MoneyCount = 20;
            Bb.MoneyCount = 20;

            AbstractMediatorState mediatorState = new MediatorPaterState(new InitState());

            // A,B玩家进入平台进行游戏
            mediatorState.Enter(Aa);
            mediatorState.Enter(Bb);

            // A赢了
            mediatorState.State = new AWinState(mediatorState);
            mediatorState.ChangeCount(5);
            Console.WriteLine("A 现在的钱是：{0}", Aa.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", Bb.MoneyCount); // 应该是15

            // B 赢了
            mediatorState.State = new BWinState(mediatorState);
            mediatorState.ChangeCount(10);
            Console.WriteLine("A 现在的钱是：{0}", Aa.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", Bb.MoneyCount); // 应该是15
            Console.Read();
            #endregion

        }
    }


    #region 一般模式实现

    // 抽象牌友类
    public abstract class AbstractCardPartner
    {
        public int MoneyCount { get; set; }

        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }

        public abstract void ChangeCount(int Count, AbstractCardPartner other);
    }

    // 牌友A类
    public class ParterA : AbstractCardPartner
    {
        public override void ChangeCount(int Count, AbstractCardPartner other)
        {
            this.MoneyCount += Count;
            other.MoneyCount -= Count;
        }
    }

    // 牌友B类
    public class ParterB : AbstractCardPartner
    {
        public override void ChangeCount(int Count, AbstractCardPartner other)
        {
            this.MoneyCount += Count;
            other.MoneyCount -= Count;
        }
    }


    #endregion


    #region 中介者模式 实现


    // 抽象牌友类
    public abstract class AbstractMediatorCardPartner
    {
        public int MoneyCount { get; set; }

        public AbstractMediatorCardPartner()
        {
            MoneyCount = 0;
        }

        public abstract void ChangeCount(int Count, AbstractMediator mediator);
    }

    // 牌友A类
    public class ParterMediatorA : AbstractMediatorCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.AWin(Count);
        }
    }

    // 牌友B类
    public class ParterMediatorB : AbstractMediatorCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.BWin(Count);
        }
    }

    // 抽象中介者类
    public abstract class AbstractMediator
    {
        protected AbstractMediatorCardPartner A;
        protected AbstractMediatorCardPartner B;
        public AbstractMediator(AbstractMediatorCardPartner a, AbstractMediatorCardPartner b)
        {
            A = a;
            B = b;
        }

        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }

    // 具体中介者类
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(AbstractMediatorCardPartner a, AbstractMediatorCardPartner b)
            : base(a, b)
        {
        }

        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }

        public override void BWin(int count)
        {
            B.MoneyCount += count;
            A.MoneyCount -= count;
        }
    }
    #endregion


    #region 利用观察者模式和状态者模式来完善中介者模式

    // 抽象牌友类
    public abstract class AbstractStateCardPartner
    {
        public int MoneyCount { get; set; }

        public AbstractStateCardPartner()
        {
            MoneyCount = 0;
        }

        public abstract void ChangeCount(int Count, AbstractMediatorState mediator);
    }

    // 牌友A类
    public class ParterStateA : AbstractStateCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediatorState mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    // 牌友B类
    public class ParterStateB : AbstractStateCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediatorState mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    // 抽象状态类
    public abstract class PlayState
    {
        protected AbstractMediatorState meditor;
        public abstract void ChangeCount(int count);
    }

    // A赢状态类
    public class AWinState : PlayState
    {
        public AWinState(AbstractMediatorState concretemediator)
        {
            this.meditor = concretemediator;
        }

        public override void ChangeCount(int count)
        {
            foreach (AbstractStateCardPartner p in meditor.list)
            {
                ParterStateA a = p as ParterStateA;
                // 
                if (a != null)
                {
                    a.MoneyCount += count;
                }
                else
                {
                    p.MoneyCount -= count;
                }
            }
        }
    }

    // B赢状态类
    public class BWinState : PlayState
    {
        public BWinState(AbstractMediatorState concretemediator)
        {
            this.meditor = concretemediator;
        }

        public override void ChangeCount(int count)
        {
            foreach (AbstractStateCardPartner p in meditor.list)
            {
                ParterStateB b = p as ParterStateB;
                // 如果集合对象中时B对象，则对B的钱添加
                if (b != null)
                {
                    b.MoneyCount += count;
                }
                else
                {
                    p.MoneyCount -= count;
                }
            }
        }
    }

    // 初始化状态类
    public class InitState : PlayState
    {
        public InitState()
        {
            Console.WriteLine("游戏才刚刚开始,暂时还有玩家胜出");
        }

        public override void ChangeCount(int count)
        {
            // 
            return;
        }
    }

    // 抽象中介者类
    public abstract class AbstractMediatorState
    {
        public List<AbstractStateCardPartner> list = new List<AbstractStateCardPartner>();

        public PlayState State { get; set; }

        public AbstractMediatorState(PlayState state)
        {
            this.State = state;
        }

        public void Enter(AbstractStateCardPartner partner)
        {
            list.Add(partner);
        }

        public void Exit(AbstractStateCardPartner partner)
        {
            list.Remove(partner);
        }

        public void ChangeCount(int count)
        {
            State.ChangeCount(count);
        }
    }

    // 具体中介者类
    public class MediatorPaterState : AbstractMediatorState
    {
        public MediatorPaterState(PlayState initState)
            : base(initState)
        { }
    }

    #endregion



    //中介者模式具有以下几点优点：
    //简化了对象之间的关系，将系统的各个对象之间的相互关系进行封装，将各个同事类解耦，使得系统变为松耦合。
    //提供系统的灵活性，使得各个同事对象独立而易于复用。

    //缺点
    //中介者模式中，中介者角色承担了较多的责任，所以一旦这个中介者对象出现了问题，整个系统将会受到重大的影响。
    //新增加一个同事类时，不得不去修改抽象中介者类和具体中介者类，此时可以使用观察者模式和状态模式来解决这个问题。
}
