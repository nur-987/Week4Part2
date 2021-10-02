using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWithCustomException
{
    /// <summary>
    /// Q5- Write a program to enter customer information to the customer collection. 
    ///Customer information can contain id, name, address etc. 
    ///Write methods and/or indexers to access the customer information by id and name.
    /// if you access an customer information which is not present handle the exception and show appropriate messages.
    /// 
    /// custom exception with message - WITHOUT EX object passed
    /// </summary>
    class Program
    {
        public static List<Customer> CustomerList = new List<Customer>();
        static void Main(string[] args)
        {
            AddingCust(1, "aaa", "ccc");
            AddingCust(2, "qqq", "ddd");
            AddingCust(3, "sss", "jjj");

            Console.WriteLine("Which customer to display?");
            int input = Int32.Parse(Console.ReadLine());

            try
            {
                DisplaySelected(input);
            }
            catch (MyCustomEx ex)
            {
                Console.WriteLine($"{ex.Message}");
            }



            Console.ReadLine();
        }

        public static void AddingCust(int id, string name, string address)
        {
            Customer customer = new Customer(id, name, address)
            {
                ID = id,
                Name = name,
                Address = address
            };

            CustomerList.Add(customer);
        }

        public static void DisplayAll()
        {
            foreach (Customer item in CustomerList)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
            }
        }

        public static void DisplaySelected(int i)
        {
            foreach (Customer item in CustomerList)
            {
                if (item.ID == i)
                {
                    Console.WriteLine(item.ID);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Address);

                    break;
                }
                else
                {
                    throw new MyCustomEx("Item is out of range");

                }



            }
        }
    }

}
