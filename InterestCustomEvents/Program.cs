using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCustomEvents
{
    /// <summary>
    /// PART 2
 /// Default Delegates and events
 /// Custom Event Args
 /// Custom Even Args
 /// </summary>

    delegate void interestDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calculator = new Calculate();
            calculator.CalculateInterestEvent += Calculator_CalculateInterestEvent;

            //multi cast delegate
            interestDelegate interestDelegate = new interestDelegate(calculator.GetPrincipal);
            interestDelegate += calculator.GetInterest;
            interestDelegate += calculator.GetTime;
            interestDelegate += calculator.CalculateSimpleInt;

            //run the delegate with multiple funcs
            interestDelegate();

            Console.ReadLine();

        }

        private static void Calculator_CalculateInterestEvent(object sender, CustomEventArgs e)
        {
            //Console.WriteLine("Simple interest is; " + e.SimpleInterest);
        }

        //uses the new EventArgs you customed
        private static void Calculator_CalculateInterestEvent1(object sender, CustomEventArgs result)
        {
            Console.WriteLine("Simple interest is; " + result.SimpleInterest);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
