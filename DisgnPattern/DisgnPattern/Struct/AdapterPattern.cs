using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Struct
{
    //适配器模式：
    //适配器模式——把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作。
    //适配器模式有类的适配器模式和对象的适配器模式两种形式
    public class AdapterPattern
    {
        public static void Test()
        {
            //客户端调用的时候，通过适配器对象调用原有的OriginProduct，实现了客户端需要的功能
            INeedProduct realNeed = new ProductAdapter();
            realNeed.Call();


            TargetProduct threehole = new ObjectAdapter();
            threehole.Call();
            Console.ReadLine();
        }
    }

    #region 类匹配模式
    /// <summary>
    /// 客户端真正需要的接口
    /// </summary>
    public interface INeedProduct
    {
        void Call();
    }


    /// <summary>
    /// 原本的接口，需要适配的类
    /// </summary>
    public class OriginProduct
    {
        public void OriginCall()
        {
            Console.WriteLine("原来产品的功能");
        }
    }

    public class ProductAdapter : OriginProduct, INeedProduct
    {
        /// <summary>
        /// 真正需要的接口中的实现方法用原有的产品实现
        /// </summary>
        public void Call()
        {
            // 调用两个孔插头方法
            this.OriginCall();
        }
    }
    #endregion


    #region 对象匹配模式

    public class TargetProduct
    {
        public virtual void Call()
        { }
    }

    public class ObjectAdapter : TargetProduct
    {
        public OriginProduct originProduct = new OriginProduct();
        public override void Call()
        {
            originProduct.OriginCall();
        }
    }
    #endregion


    ///优点：
    ///可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”
    ///可以重新定义Adaptee(被适配的类)的部分行为，因为在类适配器模式中，Adapter是Adaptee的子类
    ///仅仅引入一个对象，并不需要额外的字段来引用Adaptee实例（这个即是优点也是缺点）。


    ///缺点：
    ///1.用一个具体的Adapter类对Adaptee和Target进行匹配，
    ///当如果想要匹配一个类以及所有它的子类时，类的适配器模式就不能胜任了。
    ///因为类的适配器模式中没有引入Adaptee的实例，光调用this.SpecificRequest方法并不能去调用它对应子类的SpecificRequest方法。
    ///2.采用了 “多继承”的实现方式，带来了不良的高耦合。


    //    使用场景
    //在以下情况下可以考虑使用适配器模式：
    //系统需要复用现有类，而该类的接口不符合系统的需求
    //想要建立一个可重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。
    //对于对象适配器模式，在设计里需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。
}
