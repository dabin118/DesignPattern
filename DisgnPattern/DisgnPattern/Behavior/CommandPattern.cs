using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisgnPattern.Behavior
{
    //命令模式：
    //命令模式是把一个操作或者行为抽象为一个对象中，通过对命令的抽象化来使得发出命令的责任和执行命令的责任分隔开。
    //命令模式的实现可以提供命令的撤销和恢复功能。
    public class CommandPattern
    {

        public static void Test()
        {
            //用命令模式 调用命令

            //客户角色：

            //定义命令的接受者
            Receiver r = new Receiver();
            //定义接受什么命令
            Command c = new ConcreteCommand(r);
            //让Receive执行Command
            Invoke i = new Invoke(c);
            //执行
            i.ExecuteCommand();
        }
    }

    ///命令模式是实现把发出命令的责任和执行命令的责任分割开，
    ///然而中间必须有某个对象来帮助发出命令者来传达命令，使得执行命令的接收者可以收到命令并执行命令。
    ///角色：
    ///客户角色（公司领导）：发出一个具体的命令并确认其接收者，命令发出者
    ///命令角色（发出的命令）：申明了一个给所有具体命令类实现的抽象接口
    ///具体命令角色：定义了一个接收者和行为的弱耦合，负责调用接收者的相应方法
    ///请求者角色（中层领导——》让员工干活）：负责调用命令对象执行命令
    ///接收者角色（干活的员工）：负责具体行为的执行，执行命令
    ///



    ///命令接收者
    public class Receiver
    {
        public void DoBusiness()
        {
            Console.WriteLine("干具体的活");
        }
    }

    //抽象的命令：定义了命令有Receiver执行，并定义命令的执行方法Action
    public abstract class Command
    {
        public Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        public abstract void Action();
    }

    //具体命令
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Action()
        {
            _receiver.DoBusiness();
        }
    }

    //请求者角色，命令发出者
    public class Invoke
    {
        public Command _command;
        public Invoke(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    //    命令模式使得命令发出的一个和接收的一方实现低耦合，从而有以下的优点：
    //命令模式使得新的命令很容易被加入到系统里。
    //可以设计一个命令队列来实现对请求的Undo和Redo操作。
    //可以较容易地将命令写入日志。
    //可以把命令对象聚合在一起，合成为合成命令。合成命令式合成模式的应用。
    //　　命令模式的缺点：
    //使用命令模式可能会导致系统有过多的具体命令类。这会使得命令模式在这样的系统里变得不实际。



}
