using DisgnPattern.Product;
using DisgnPattern.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DisgnPattern
{
    public class Program
    {
        static void Main(string[] args)
        {

            TestCompositePattern();


            Console.ReadKey();
        }

        #region 创建型模式
        #region  单例模式
        public static void TestSingleton()
        {
            Singleton single = Singleton.GetInstance();
        }
        #endregion

        #region 简单工厂模式

        public static void TestSimpleFactory()
        {


            //这样的坏处是 Customer与Food 之间耦合度高，Customer依赖于Food.
            //Customer要处理Food逻辑，当Food逻辑修改的时候，必须去修改代码
            Food food1 = Custommer.Cook("西红柿炒蛋");
            food1.Print();

            Food food2 = Custommer.Cook("土豆肉丝");
            food2.Print();


            //简单工厂模式，让这些做菜的操作给工厂去做，让Customer对Food的依赖关系从直接的变成间接的。
            //降低了对象之间的耦合
            // 客户想点一个西红柿炒蛋      
            Food food3 = SimpleFactory.CreateFood("西红柿炒蛋");
            food3.Print();

            // 客户想点一个土豆肉丝
            Food food4 = SimpleFactory.CreateFood("土豆肉丝");
            food4.Print();

            //优点：实现了责任的分割，代码复用，
            //缺点：工厂类中的逻辑出错，影响大；需求修改工厂代码逻辑也要修改；
            //应用场景：工厂类创建的对象比较少，可以考虑。客户只知道传入参数，不关心创建对象的逻辑


        }





        #endregion

        #region 工厂方法模式

        public static void TestFactoryMethod()
        {
            // 初始化做菜的两个工厂（）
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            // 开始做西红柿炒蛋
            Food tomatoScrambleEggs = tomatoScrambledEggsFactory.CreateFoddFactory();
            tomatoScrambleEggs.Print();

            //开始做土豆肉丝
            Food shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.CreateFoddFactory();
            shreddedPorkWithPotatoes.Print();

        }
        #endregion

        #region 抽象工厂模式
        public static void TestAbstractFactory()
        {
            AbstractFactoryTest hangzhou = new HangzhouFactory();
            hangzhou.CreateA().Print();
            hangzhou.CreateB().Print();

            AbstractFactoryTest shanghai = new ShangHaiFactory();
            shanghai.CreateA().Print();
            shanghai.CreateB().Print();

        }
        #endregion

        #region 建造者模式

        public static void TestBuilderPattern()
        {
            // 客户找到电脑城老板说要买电脑，这里要装两台电脑
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 老板叫员工去组装第一台电脑
            director.Construct(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

        }

        #endregion

        #region 原型模式
        public static void PrototypePattern()
        {
            MonkeyKingPrototype prototypeMonkeyKing = new ConcretePrototype("MonkeyKing");

            // 变一个
            MonkeyKingPrototype cloneMonkeyKing = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);



            // 变两个
            MonkeyKingPrototype cloneMonkeyKing2 = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.Id);
            Console.ReadLine();
        }
        #endregion
        #endregion


        #region 结构型模式
        #region 适配器模式

        public static void TestAdapter()
        {
            AdapterPattern.Test();
        }


        #endregion

        #region 桥接模式

        public static void TestBridge()
        {
            BridgePattern.TestBridgePattern();
        }

        #endregion

        #region 装饰者模式
        public static void TestDecoratorPattern()
        {
            DecoratorPattern.Test();
        }

        #endregion

        #region 组合模式

        public static void TestCompositePattern()
        {
            CompositePattern.Test();
        }

        #endregion


        #endregion


    }
}
