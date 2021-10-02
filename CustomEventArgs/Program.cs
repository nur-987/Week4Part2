using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
    /// <summary>
    /// Write a program which uses the EventHandler delagate 
    /// to notify the caller using a custom eventArgs. 
    /// In the custom eventargs you should have your Message and an exception object 
    /// to notify whether exception occured or not.
    /// 
    /// WITH EX object passed
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.AddedItemEvent += MyClass_AddedItemEvent;

            bool b = true;
            char answer = 'A';
            while (b)
            {
                try
                {
                    answer = GetCharacter();
                }
                catch (MyCustomExceptions ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                if (answer == 'Y')
                {
                    Console.WriteLine("What would u like to add?");
                    string input = Console.ReadLine();
                    myClass.AddItem(input);

                }
                else
                {
                    Console.WriteLine("Thank you. GoodBye!");
                    b = false;
                }
            }
            Console.ReadLine();

        }

        private static char GetCharacter()
        {
            char answer;
            Console.WriteLine("Would you like to add new item in list? Y/N");
            try
            {
                answer = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Unable to proceed. Wrong format");
                Console.WriteLine($"{ex.Message}");
                throw new MyCustomExceptions("My custom exception. An exception occured", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to proceed. Response NULL");
                Console.WriteLine($"{ex.Message}");
                throw new MyCustomExceptions("My custom exception. An exception occured", ex);
            }

            return answer;
        }

        private static void MyClass_AddedItemEvent(object sender, MyCustomArgs e)
        {
            Console.WriteLine("Total number of items in list is: " + e.NewCount);
        }
    }

    class MyClass
    {
        public event EventHandler<MyCustomArgs> AddedItemEvent;

        public static List<string> myList = new List<string>();

        public void AddItem(string newStr)
        {
            int result = 0;
            myList.Add(newStr);
            try
            {
                result = myList.Count();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Unable to proceed.");
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to proceed.");
                Console.WriteLine($"{ex.Message}");
            }

            if (AddedItemEvent != null)
            {
                MyCustomArgs customArgs = new MyCustomArgs();
                customArgs.NewCount = result;
                AddedItemEvent(this, customArgs);
            }

        }

    }
}
