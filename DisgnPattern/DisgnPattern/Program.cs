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
            SimpleFactory.Test();
        }





        #endregion

        #region 工厂方法模式

        public static void TestFactoryMethod()
        {
            FactoryMethod.Test();

        }
        #endregion

        #region 抽象工厂模式
        public static void TestAbstractFactory()
        {
            AbstractFactory.Test();

        }
        #endregion

        #region 建造者模式

        public static void TestBuilderPattern()
        {
            BuilderPattern.Test();

        }

        #endregion

        #region 原型模式
        public static void TestPrototypePattern()
        {
            PrototypePattern.Test();
            
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
