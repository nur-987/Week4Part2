using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateExample
{
    /// <summary>
    /// Create a class which has an array with some values. 
    /// Constitute a function which can eveluate whether a user provided parameter is present
    /// in the array using Predicate delegate.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyArray arrayClass = new MyArray();

            //declare predicate
            Predicate<int> myPredicate = arrayClass.GetNumber;
            Console.WriteLine("Input a number to check");
            int input = Int32.Parse(Console.ReadLine());

            //METHOD 1
            myPredicate(input);

            //METHOD 2
            Predicate<int> myPredicate2 = (searchNum) =>
            {
                for (int i = 0; i < arrayClass.myArray.Length; i++)
                {
                    if (arrayClass.myArray[i] == searchNum)
                    {
                        return true;
                    }
                }
                return false;
            };

            Console.WriteLine("The result is: " + myPredicate(input));
            Console.WriteLine("METHOD 2: The result is: " + myPredicate2(input));
            Console.ReadLine();
        }
    }

    class MyArray
    {
        public int[] myArray = new int[5] { 2, 4, 6, 8, 10 };

        public bool GetNumber(int num)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == num)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
