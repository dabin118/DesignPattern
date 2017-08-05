using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Struct
{
    /// <summary>
    /// 外观模式 
    /// 客户端程序经常会与复杂系统的内部子系统进行耦合，从而导致客户端程序随着子系统的变化而变化，
    /// 然而为了将复杂系统的内部子系统与客户端之间的依赖解耦，从而就有了外观模式，也称作 ”门面“模式。
    /// </summary>
    public class FacadePattern
    {
        private static SystemFacade facade = new SystemFacade();
        public static void Test()
        {
            //外观模式
            //提供了为所有子系统设计一个统一的接口
            //调用的时候，调用外观类中的方法，简化了客户端的操作，避免紧耦合
            facade.FunA_B();


            //一般模式
            //让客户端与三个子系统都发生了耦合，使得客户端程序依赖于子系统
            SystemA systemA = new SystemA();
            SystemB systemB = new SystemB();

            systemA.FunA();
            systemB.FunB();


        }
    }


    ///外观模式：为子系统中的一组接口提供一个一致的界面，用来访问子系统中的一群接口。
    ///外观定义了一个高层接口，让子系统更容易使用。
    ///使用外观模式时，我们创建了一个统一的类，用来包装子系统中一个或多个复杂的类，
    ///客户端可以直接通过外观类来调用内部子系统中方法，从而外观模式让客户和子系统之间避免了紧耦合。
    ///

    public class SystemFacade
    {
        private SystemA systemA;
        private SystemB systemB;

        public SystemFacade()
        {
            systemA = new SystemA();
            systemB = new SystemB();

        }

        public void FunA_B()
        {
            systemA.FunA();
            systemB.FunB();
            Console.WriteLine("组合成外观类的功能A&B");
        }


    }

    public class SystemA
    {
        public void FunA()
        {
            Console.WriteLine("子系统A的功能A");

        }
    }

    public class SystemB
    {
        public void FunB()
        {
            Console.WriteLine("子系统B的功能B");
        }
    }



    //优点：
    //外观模式对客户屏蔽了子系统组件，从而简化了接口，减少了客户处理的对象数目并使子系统的使用更加简单。
    //外观模式实现了子系统与客户之间的松耦合关系，而子系统内部的功能组件是紧耦合的。松耦合使得子系统的组件变化不会影响到它的客户。
    //缺点：
    //如果增加新的子系统可能需要修改外观类或客户端的源代码，这样就违背了”开——闭原则“（不过这点也是不可避免）。



    ///外观模式的实现核心主要是——由外观类去保存各个子系统的引用，实现由一个统一的外观类去包装多个子系统类，
    ///然而客户端只需要引用这个外观类，然后由外观类来调用各个子系统中的方法。
    ///
    /// 
    ///适配器模式是将一个对象包装起来以改变其接口，而外观是将一群对象 ”包装“起来以简化其接口。
    ///它们的意图是不一样的，适配器是将接口转换为不同接口，而外观模式是提供一个统一的接口来简化接口。
    ///
    /// 
    ///外观模式，为子系统的一组接口提供一个统一的接口，该模式定义了一个高层接口，这一个高层接口使的子系统更加容易使用。并且外观模式可以解决层结构分离、降低系统耦合度和为新旧系统交互提供接口功能。

}
