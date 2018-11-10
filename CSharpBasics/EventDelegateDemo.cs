using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public delegate void EventDelegate(string log);
    public class CustomEventHandler
    {
        public void Log(string log)
        {
            Console.WriteLine(log);
        }
    }
    
    public class CalOperations
    {
        public int Add(int a, int b)
        {
            Console.WriteLine("Add Method");
            return a + b;
        }
    
        public int Sub(int a, int b)
        {
            Console.WriteLine("Sub Method");
            return a - b;
        }
        public int Mul(int a, int b)
        {
            Console.WriteLine("Mul Method");
            return a * b;
        }



        CustomEventHandler eventHandler;
        private event EventDelegate Logger;
        public CalOperations()
        {
            eventHandler = new CustomEventHandler();
            Logger = eventHandler.Log;
        }

        public void Add2(int a, int b)
        {
            Console.WriteLine("Add Method :-", (a + b).ToString());
            Logger("Triggered");

        }

        public void Sub2(int a, int b)
        {
            Console.WriteLine("Sub Method :-", (a - b).ToString());
            Logger("Triggered");
        }
    }
}
