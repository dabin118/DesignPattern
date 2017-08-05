using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Struct
{

    //桥接模式：
    //将抽象部分与实现部分分离，使它们都可以独立的变化。
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

    // 一种抽象的方法：不用一味的抽象继承，而是把两个抽象角色耦合，来实现各自抽象的变化

    //例子：
    //多种遥控器，一一对应多种电视

    //一般方法：抽象出遥控器和电视的抽象对象之后，继承抽象对象，他们的子类相互实现功能
    //这样引起的问题是： 多种遥控器与多种电视之前的继承，以及相互之间的关系M*N倍增长

    /// <summary>
    /// 抽象遥控器
    /// </summary>
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


    /// <summary>
    /// 抽象电视
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TurnChannel();

    }

    /// <summary>
    /// 具体长虹电视
    /// </summary>
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

    /// <summary>
    /// 具体三星电视
    /// </summary>
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

    //桥接模式的实现中，遥控器的功能实现方法不在遥控器抽象类中去实现了，
    //而是把实现部分用来另一个电视机类去封装它，然而遥控器中只包含电视机类的一个引用，


    //优点：
    //把抽象接口与其实现解耦。
    //抽象和实现可以独立扩展，不会影响到对方。
    //实现细节对客户透明，对用于隐藏了具体实现细节。
    //缺点： 增加了系统的复杂度

    //例如：BLL与DAL之间的解耦：可以在BLL成中间引用DAL层中一个引用 IBLL层中耦合IDAL，数据库之间切换，就不用大动代码


}
