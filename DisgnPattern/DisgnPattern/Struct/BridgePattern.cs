using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Struct
{
    public class BridgePattern
    {
        public static void TestBridgePattern()
        {
            // 创建一个遥控器
            RemoteControl remoteControl = new ConcreteRemote();
            // 长虹电视机
            remoteControl.ChntrolTV = new ChangHong();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.WriteLine();

            // 三星牌电视机
            remoteControl.ChntrolTV = new Samsung();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.Read();
        }
    }
    //桥接模式：即将抽象部分与实现部分脱耦，使它们可以独立变化。
    // 一种抽象的方法：不用一味的抽象继承，而是把两个抽象角色耦合，来实现各自抽象的变化

    //例子：
    //多种遥控器，一一对应多种电视

    //一般方法：抽象出遥控器和电视的抽象对象之后，继承抽象对象，他们的子类相互实现功能
    //这样引起的问题是： 多种遥控器与多种电视之前的继承，以及相互之间的关系M*N倍增长

    public class RemoteControl
    {
        public TV ChntrolTV { get; set; }
        public virtual void On()
        {
            ChntrolTV.On();
        }
        public virtual void Off()
        {
            ChntrolTV.Off();
        }
        public virtual void SetChannel()
        {
            ChntrolTV.TurnChannel();
        }
    }

    /// <summary>
    /// 具体遥控器
    /// </summary>
    public class ConcreteRemote : RemoteControl
    {
        public override void SetChannel()
        {
            Console.WriteLine("---------------------");
            base.SetChannel();
            Console.WriteLine("---------------------");
        }
    }

    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TurnChannel();

    }

    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("长虹牌电视机已经关掉了");
        }

        public override void TurnChannel()
        {
            Console.WriteLine("长虹牌电视机换频道");
        }
    }

    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("三星牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("三星牌电视机已经关掉了");
        }

        public override void TurnChannel()
        {
            Console.WriteLine("三星牌电视机换频道");
        }
    }

    //例如：BLL与DAL之间的解耦：可以在BLL成中间引用DAL层中一个引用 IBLL层中耦合IDAL，数据库之间切换，就不用大动代码

   
}
