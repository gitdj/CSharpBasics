using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class UtilityHelper
    {
        private string logs = string.Empty;        
        public UtilityHelper()
        {
            logs = "DefaultConstructor";
            Console.WriteLine(logs);
        }

        ~ UtilityHelper()
        {
            logs = "DefaultConstructor";
            Console.WriteLine(logs);
        }
        public UtilityHelper(string logs)
        {
            this.logs = logs;
            Console.WriteLine(logs);

        }
        public string status { get; private set; }

        public string general { get; set; }

        public List<int> numbers { private get; set; }

        public void PrintNumbers()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i]<0)
                {
                    Console.WriteLine(numbers[i] + " is a Negative");
                }
                else if(numbers[i] % 2 == 0)
                {
                    Console.WriteLine(numbers[i] + " is a Even Number");
                }
                else
                {
                    Console.WriteLine(numbers[i] + " is a Odd Number");
                }
            }

            status = "Completed";
        }
    }
}
