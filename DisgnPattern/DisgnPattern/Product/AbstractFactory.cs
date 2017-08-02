using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Product
{

    //抽象工厂模式
    //提供一个创建产品的接口来负责创建相关或依赖的对象，而不具体明确指定具体类
    public class AbstractFactory
    {
        public static void Test()
        {
            AbstractFactoryTest hangzhou = new HangzhouFactory();
            hangzhou.CreateA().Print();
            hangzhou.CreateB().Print();

            AbstractFactoryTest shanghai = new ShangHaiFactory();
            shanghai.CreateA().Print();
            shanghai.CreateB().Print();
        }

    }

    


    /// <summary>
    /// 抽象工厂类，提供创建两个不同产品的接口
    /// </summary>
    public abstract class AbstractFactoryTest
    {
        // 抽象工厂提供创建一系列产品的接口，这里作为例子，只给出了绝味中鸭脖和鸭架的创建接口
        public abstract ProductA CreateA();
        public abstract ProductB CreateB();
    }



    /// <summary>
    /// 杭州工厂负责制作产品
    /// </summary>
    public class HangzhouFactory : AbstractFactoryTest
    {
        // 杭州生产A
        public override ProductA CreateA()
        {
            return new HangzhouProductA();
        }
        // 杭州生产B
        public override ProductB CreateB()
        {
            return new HangzhouProductB();
        }
    }


    /// <summary>
    /// 上海工厂负责制作产品
    /// </summary>
    public class ShangHaiFactory : AbstractFactoryTest
    {
        // 上海生产A
        public override ProductA CreateA()
        {
            return new ShangHaiProductA();
        }
        // 上海生产B
        public override ProductB CreateB()
        {
            return new ShangHaiProductB();
        }
    }

    #region  产品定义

    /// <summary>
    /// 产品A抽象类，供每个地方的产品A类继承
    /// </summary>
    public abstract class ProductA
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 产品B抽象类，供每个地方的产品B类继承
    /// </summary>
    public abstract class ProductB
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }


    /// <summary>
    /// 杭州的本地化产品A
    /// </summary>
    public class HangzhouProductA : ProductA
    {
        public override void Print()
        {
            Console.WriteLine("杭州的产品A");
        }
    }

    /// <summary>
    /// 杭州本地化产品B
    /// </summary>
    public class HangzhouProductB : ProductB
    {
        public override void Print()
        {
            Console.WriteLine("杭州的产品B");
        }
    }

    /// <summary>
    /// 上海产品A
    /// </summary>
    public class ShangHaiProductA : ProductA
    {
        public override void Print()
        {
            Console.WriteLine("上海产品A");
        }
    }

    /// <summary>
    /// 上海产品B
    /// </summary>
    public class ShangHaiProductB : ProductB
    {
        public override void Print()
        {
            Console.WriteLine("上海产品B");
        }
    }
    #endregion


    //理解：
    //抽象，将对象的创建封装起来，
    //将具体产品的创建延迟到具体工厂的子类中
    //可以减少客户端与具体产品类之间的依赖，从而使系统耦合度低，（减少ShangHaiFactory.CreateA 与 ShangHaiProductA）的联系
    //这样更于有利后期的维护和扩展

    //缺点：
    //很难支持新种类产品的变化。
    //这是因为抽象工厂接口中已经确定了可以被创建的产品集合，（抽象）
    //如果需要添加新产品，此时就必须去修改抽象工厂的接口，（工厂要生产新的产品，在抽象工厂中添加的话，相关的继承都要修改）
    //这样就涉及到抽象工厂类的以及所有子类的改变，这样也就违背了“开发——封闭”原则。


    //使用情形
    //一个系统不要求依赖产品类实例如何被创建、组合和表达的表达，这点也是所有工厂模式应用的前提。
    //这个系统有多个系列产品，而系统中只消费其中某一系列产品
    //系统要求提供一个产品类的库，所有产品以同样的接口出现，客户端不需要依赖具体实现。









}
