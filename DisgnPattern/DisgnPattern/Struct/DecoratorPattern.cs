﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Struct
{
    //装饰者模式：要对一个对象添加不同的功能，如果用继承类来实现的话，那就要定义很多类，使用装饰者模式用来给一个对象添加额外的职责
    public class DecoratorPattern
    {

        public static void Test()
        {
            // 我买了个苹果手机
            Phone phone = new ApplePhone();

            // 现在想贴膜了
            Decorator applePhoneWithSticker = new Sticker(phone);
            // 扩展贴膜行为
            applePhoneWithSticker.Print();
            Console.WriteLine("----------------------\n");

            // 现在我想有挂件了
            Decorator applePhoneWithAccessories = new Accessories(phone);
            // 扩展手机挂件行为
            applePhoneWithAccessories.Print();
            Console.WriteLine("----------------------\n");

            // 现在我同时有贴膜和手机挂件了
            Sticker sticker = new Sticker(phone);
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            applePhoneWithAccessoriesAndSticker.Print();
            Console.ReadLine();
        }
    }

    
    //装饰者模式以对客户透明的方式动态地给一个对象附加上更多的责任，装饰者模式相比生成子类可以更灵活地增加功能。



    //例子：
    //给手机添加贴膜，手机挂件，手机外壳等


    /// <summary>
    /// 手机抽象类，即装饰者模式中的抽象组件类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }


    /// <summary>
    /// 苹果手机，即装饰着模式中的具体组件类
    /// </summary>
    public class ApplePhone : Phone
    {
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }

    /// <summary>
    /// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自Phone
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone phone;
        public Decorator(Phone p)
        {
            this.phone = p;
        }
        public override void Print()
        {
            if (phone != null)
            {
                phone.Print();
            }
        }
    }


    /// <summary>
    /// 贴膜，即具体装饰者
    /// </summary>
    public class Sticker : Decorator
    {
        public Sticker(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddSticker();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }

    /// <summary>
    /// 手机挂件
    /// </summary>
    public class Accessories : Decorator
    {
        public Accessories(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddAccessories();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }

    //分析：
    //当子类转化成父类的时候，对象会保留子类的方法
    //抽象出的装饰类：添加了构造方法，并定义一个与抽象构件接口一致的接口
    //具体装饰类：给构件对象添加附加责任
    //当使用具体装饰类的功能的时候，用具体装饰类的对象来实现


    //优点：
    //装饰这模式和继承的目的都是扩展对象的功能，但装饰者模式比继承更灵活
    //通过使用不同的具体装饰类以及这些类的排列组合，设计师可以创造出很多不同行为的组合
    //装饰者模式有很好地可扩展性

    //缺点：装饰者模式会导致设计中出现许多小对象，如果过度使用，会让程序变的更复杂。并且更多的对象会是的差错变得困难，特别是这些对象看上去都很像。






}
