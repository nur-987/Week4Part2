using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCustomEvents
{
    //no longer need this delegate
    //public delegate void InterestEvent(int result);

    class Calculate
    {
        //Default event handler <Customised Args>
        public event EventHandler<CustomEventArgs> CalculateInterestEvent;

        public int Principal { get; private set; }
        public int Interest { get; private set; }
        public int Time { get; private set; }

        public void GetPrincipal()
        {
            try
            {
                Console.WriteLine("Input Principal");
                Principal = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid! {ex.Message}");
            }

        }

        public void GetInterest()
        {
            try
            {
                Console.WriteLine("Input Interest");
                Interest = Int32.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid! {ex.Message}");
            }

        }

        public void GetTime()
        {
            try
            {
                Console.WriteLine("Input Time range");
                Time = Int32.Parse(Console.ReadLine());
            }


            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Invalid! {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid! {ex.Message}");
            }

        }

        public void CalculateSimpleInt()
        {
            int result = 0;
            try
            {
                result = (Principal * Interest * Time) / 100;
                Console.WriteLine("Total Intrest is: " + result);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Exception raised {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Exception raised {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Exception raised {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception raised {ex.Message}");
            }
            finally
            {

                if (CalculateInterestEvent != null)
                {
                    //instantiate custom Args 
                    //use the property defined in custom EventArgs

                    CustomEventArgs myArgs = new CustomEventArgs();
                    myArgs.SimpleInterest = result;

                    //invoke the event with results to send back
                    CalculateInterestEvent(this, myArgs);

                }
            }
        }

    }
}
