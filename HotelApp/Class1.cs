using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    class Room
    {
        public int guestId { get; set; }
        public string guestName { get; set; }
        public int roomType { get; set; }
        public int roomCost { get; set; }
        public List<Service> srvcesRequested { get; set; }

        public void retrieveBooking()
        {
            Console.WriteLine("here are your booking details......");
            Console.WriteLine("Guest ID is: " + guestId);
            Console.WriteLine("Guest name is: " + guestName);
            Console.WriteLine("Room Type is: Class " + roomType);
            Console.WriteLine("Room Cost: $ " + roomCost);

            Console.ReadLine();

        }

    }


    class Service
    {
        public string ServiceName { get; set; }
        public int ServiceCost { get; set; }
        public int GuestId { get; set; }

        public string[] arrayService =
            { "Room Cleaning",
            "Serve Lunch",
            "Serve Dinner",
            "Laundry",
            "Overseas Calls"
            };

        public void ServicesAvail()
        {
            Service service = new Service();
            Console.WriteLine("Here is the list of services offered by the Hotel");
            for (int i = 0; i < service.arrayService.Length; i++)
            {
                Console.Write(i + ") ");
                Console.WriteLine(service.arrayService[i]);
            }

        }

    }
}
