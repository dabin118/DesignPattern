﻿using DisgnPattern.Behavior;
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

            TestMementoPattern();


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

        #region 外观模式
        public static void TestFacadePattern()
        {
            FacadePattern.Test();
        }


        #endregion

        #region 享元模式
        public static void TestFlyweightPattern()
        {
            FlyweightPattern.Test();
        }

        #endregion

        #region 代理模式
        public static void TestProxyPattern()
        {
            ProxyPattern.Test();
        }
        #endregion

        #endregion


        #region 行为型模式
        #region 模板方法模式

        public static void TestTemplateMethodPattern()
        {
            TemplateMethodPattern.Test();
        }

        #endregion


        #region 命令模式

        public static void TestCommandPattern()
        {
            CommandPattern.Test();
        }

        #endregion

        #region 迭代器模式
        public static void TestIteratorPattern()
        {
            IteratorPattern.Test();
        }
        #endregion

        #region 观察者模式

        public static void TestObserverPattern()
        {
            ObserverPattern.Test();
        }

        #endregion

        #region 中介者模式
        public static void TestMediatorPattern()
        {
            MediatorPattern.Test();
        }
        #endregion

        #region 状态者模式

        public static void TestStatePattern()
        {
            StatePattern.Test();
        }

        #endregion

        #region 策略模式

        public static void TestStragetyPattern()
        {
            StragetyPattern.Test();
        }

        #endregion


        #region 责任链模式

        public static void TestChainOfResponsibity()
        {
            ChainOfResponsibity.Test();
        }


        #endregion

        #region 访问者模式

        public static void TestVistorPattern()
        {
            VistorPattern.Test();
        }

        #endregion

        #region 备忘录模式

        public static void TestMementoPattern()
        {
            MementoPattern.Test();
        }


        #endregion
        #endregion

    }
}
