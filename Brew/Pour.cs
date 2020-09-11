using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Brewing
{
    public abstract class CellPhone
    {
        public virtual void SendMessage()
        {
            Console.WriteLine("SMS Sent");
        }
    }

    public class FruitPhone : CellPhone
    {
        public override void SendMessage()
        {
            Console.WriteLine("Fancy message sent with a blue bubble, how fancy.");
            base.SendMessage();
        }
    }

    public class RobotPhone : CellPhone
    {
        public override void SendMessage()
        {
            CellPhone phone = new FruitPhone();
            phone.SendMessage();
            Console.WriteLine("Sent RCS Message with awesome features");
            base.SendMessage();
        }
    }
}