using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Product
{

    //原型模式:
    //每个类实例都是相同的，当我们需要多个相同的类实例时，没必要每次都使用new运算符去创建相同的类实例对象
    //此时我们一般思路就是想——只创建一个类实例对象，
    //如果后面需要更多这样的实例，可以通过对原来对象拷贝一份来完成创建，这样在内存中不需要创建多个相同的类实例，从而减少内存的消耗和达到类实例的复用。


    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }
        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }

        // 克隆方法，即孙大圣说“变”
        public abstract MonkeyKingPrototype Clone();
    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        { }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public override MonkeyKingPrototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }
    //优点：
    //原型模式向客户隐藏了创建新实例的复杂性
    //原型模式允许动态增加或较少产品类。
    //原型模式简化了实例的创建结构，工厂方法模式需要有一个与产品类等级结构相同的等级结构，而原型模式不需要这样。
    //产品类不需要事先确定产品的等级结构，因为原型模式适用于任何的等级结构

    //缺点：
    //每个类必须配备一个克隆方法
    //配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。

    //理解：
    //原型模式用一个原型对象来指明所要创建的对象类型，然后用复制这个原型对象的方法来创建出更多的同类型对象，
    //它与工厂方法模式的实现非常相似，其中原型模式中的Clone方法就类似工厂方法模式中的工厂方法，
    //只是工厂方法模式的工厂方法是通过new运算符重新创建一个新的对象（相当于原型模式的深拷贝实现），
    //而原型模式是通过调用MemberwiseClone方法来对原来对象进行拷贝，也就是复制




}
