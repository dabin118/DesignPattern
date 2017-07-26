using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Product
{
    /// <summary>
    /// 简单工厂类, 负责 新建食物对象
    /// </summary>
    public class SimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;

            if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            else if (type.Equals("土豆肉丝"))
            {
                food = new ShreddedPorkWithPotatoes();
            }
            return food;

        }


        public static void Test()
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
    }

    /// <summary>
    /// 客户吃饭的逻辑
    /// 自己新建食物对象
    /// </summary>
    public class Custommer
    {
        
        public static Food Cook(string type)
        {
            Food food = null;

            if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            else if (type.Equals("土豆肉丝"))
            {
                food = new ShreddedPorkWithPotatoes();
            }
            return food;

        }
    }

    /// <summary>
    /// 菜抽象类
    /// </summary>
    public abstract class Food
    {
        public Food() { }
        // 输出点了什么菜
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒鸡蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒蛋！");
        }
    }

    /// <summary>
    /// 土豆肉丝这道菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份土豆肉丝");
        }
    }



}
