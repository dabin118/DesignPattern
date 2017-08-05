using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Behavior
{
    //模板方法模式：
    //在一个抽象类中定义一个操作中的算法骨架，而将一些步骤延迟到子类中去实现。
    //模板方法使得子类可以不改变一个算法的结构前提下，重新定义算法的某些特定步骤，
    //模板方法模式把不变行为搬到超类中，从而去除了子类中的重复代码。




    public class TemplateMethodPattern
    {
        public static void Test()
        {
            Spinach spinach = new Spinach();
            spinach.CookVegetable();

        }
    }
    //把相同的部分抽象出来到抽象类中去定义，具体子类来实现具体的不同部分，
    //这个思路也正式模板方法的实现精髓所在


    //例如：炒蔬菜




    //模板方法，
    //不要把模版方法定义为Virtual或abstract方法，避免被子类重写，防止更改流程的执行顺序
    public abstract class Vegetable
    {
        public void CookVegetable()
        {
            Console.WriteLine("炒蔬菜的一般做法");
            this.PourOil();
            this.HeatOil();
            this.PourVegetable();
            this.AddSource();

        }

        public void PourOil()
        {
            Console.WriteLine("倒油");
        }

        public void HeatOil()
        {
            Console.WriteLine("把油烧热");

        }

        public abstract void PourVegetable();

        public void AddSource()
        {
            Console.WriteLine("添加调味");
        }

    }


    public class Spinach : Vegetable
    {
        public override void PourVegetable()
        {
            Console.WriteLine("把菠菜倒进锅中");
        }
    }

    public class ChineseCabbage : Vegetable
    {
        public override void PourVegetable()
        {
            Console.WriteLine("把大白菜倒进锅中");
        }
    }


    //优点：
    //实现了代码复用
    //能够灵活应对子步骤的变化，符合开放-封闭原则
    //缺点：因为引入了一个抽象类，如果具体实现过多的话，需要用户或开发人员需要花更多的时间去理清类之间的关系。
}
