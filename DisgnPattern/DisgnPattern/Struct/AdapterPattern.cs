using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Struct
{
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
    //适配器模式：
    //适配器模式——把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作。
    //适配器模式有类的适配器模式和对象的适配器模式两种形式



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

}
