using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    /// <summary>
    /// 1) create a hotel mgmt.  system to perform different operation  given below.                                                                     first you have to book a room according to your convenience . 
    /// then you will choose the services you want 
    /// then a bill will generate with all the details 
    /// and also with the tax
    /// </summary>
    class Program
    {
        public static List<Room> RoomsBooked = new List<Room>();
        public static List<Service> ServicesChosen = new List<Service>();
        public static Service service = new Service();
        //declare as a variable

        public static void Main(string[] args)
        {
            bool cntn = true;
            while (cntn)
            {
                Console.WriteLine("Press Y to proceed to book a room");
                Console.WriteLine("Press S for services");
                Console.WriteLine("Press B for billing");

                Console.WriteLine("Press X to exit");

                string input = Console.ReadLine();

                if (input == "Y")
                {
                    BookRoom(out Room c);
                    RoomsBooked.Add(c);
                    c.retrieveBooking();
                }
                if (input == "X")
                {
                    Console.WriteLine("good bye.....");
                    cntn = false;
                }
                if (input == "S")
                {
                    service.ServicesAvail();

                    Console.WriteLine("Would you like to choose one? Y/N");
                    string input2 = Console.ReadLine();
                    if (input2 == "Y")
                    {
                        ChoosingService();
                    }
                    else
                    {
                        Console.WriteLine("Exiting.....");
                        return;
                    }
                }
                if (input == "B")
                {
                    Console.WriteLine("Please input guest ID");
                    int tempUser = Int32.Parse(Console.ReadLine());
                    Bill(tempUser);
                }
            }


        }

        public static void BookRoom(out Room c)
        {
            Console.WriteLine("Please input guest ID");
            int gId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please input guest name");
            string gName = Console.ReadLine();
            Console.WriteLine("Please select the type of room you would like to book");
            Console.WriteLine("1) First Class    2) Second Class      3) Third Class ");
            int roomSelected = Convert.ToInt32(Console.ReadLine());

            int tempCost;

            if (roomSelected == 1)
            {
                tempCost = 300;
            }
            else if (roomSelected == 2)
            {
                tempCost = 400;
            }
            else
            {
                tempCost = 500;
            }
            Room tempRoom = new Room { guestId = gId, guestName = gName, roomType = roomSelected, roomCost = tempCost };
            c = tempRoom;


        }

        public static void ChoosingService()
        {
            Console.WriteLine("Choose the service that you would like");
            int tempChosenService = Int32.Parse(Console.ReadLine());
            var ChosenService = service.arrayService[tempChosenService];

            Console.WriteLine("Please input guest ID");
            int tempUser = Int32.Parse(Console.ReadLine());
            var guest = RoomsBooked.First(x => x.guestId == tempUser);

            Console.WriteLine("How much does the service cost?");
            int tempCost = Int32.Parse(Console.ReadLine());
            service.ServiceCost = tempCost;

            Service service1 = new Service() { GuestId = tempUser, ServiceCost = tempCost };
            ServicesChosen.Add(service1);
        }


        public static void Bill(int id)
        {
            int b = 0;
            int a = 0;

            foreach (Room item in RoomsBooked)
            {
                if (item.guestId == id)
                {
                    b = item.roomCost;
                }
            }
            foreach (Service item in ServicesChosen)
            {
                if (item.GuestId == id)
                {
                    a = item.ServiceCost;
                }
            }

            int Bill = a + b;
            int totalBill = Bill * (5 / 100);

            Console.WriteLine("Total Bill is: " + totalBill);

        }

    }
}
