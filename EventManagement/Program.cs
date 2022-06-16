using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            repeat:
            menu();
            Console.WriteLine("choose the option");
            int i = Convert.ToInt32(Console.ReadLine());
            switch(i)
            {
                case 1:
                    CustomerMenu();
                    goto repeat;
                case 2:
                    Adminmenu();
                    goto repeat;
                case 3:
                    break;
            }
            // a.Add();
            // a.GetAllListOfCustomer();
            //Events e = new Events();
            //e.AddEventDetail();
           // c.Login("9403623155", "yoge@124");
            Console.Read();
        }

        private static void menu()
        {
            Console.WriteLine("Enter 1 for customer");
            Console.WriteLine("Enter 2 for admin");
            Console.WriteLine("Enter 3 for close");
        } 
        private static void Adminmenu()
        {
            Admin a = new Admin();
            Events e = new Events();
            home:
            Console.WriteLine("Enter 1 for Register Admin");
            Console.WriteLine("Enter 2 for GEt All list of Customer");
            Console.WriteLine("Enter 3 for GEt All list of Event");
            Console.WriteLine("Enter 4 for Add event");
            Console.WriteLine("Enter 5 to Go Back");

            Console.WriteLine("choose the option");
            int i = Convert.ToInt32(Console.ReadLine());
            switch(i)
            {
                case 1:
                    a.RegisterAdmin();
                    goto home;
                case 2:
                    a.GetAllListOfCustomer();
                    goto home;
                case 3:
                    e.ListOfEvent();
                    goto home;
                case 4:
                    e.AddEventDetail();
                    goto home;
                case 5:
                    break;
            }
        } 
        private static void CustomerMenu()
        {
            Customer c = new Customer();
            home:
            Console.WriteLine("Enter 1 for Register Customer");
            Console.WriteLine("Enter 2 for view available venue");
            Console.WriteLine("Enter 3 for book the event");
            Console.WriteLine("Enter 4 to close");

            Console.WriteLine("choose the option");
            int i = Convert.ToInt32(Console.ReadLine());
            switch(i)
            {
                case 1:
                    c.RegisterCustomer();
                    goto home;
                case 2:
                    Events.AvlEvent();
                    goto home;
                case 3:
                    Events.Book();
                    goto home;
                case 4:
                    break;
            }


        }
    }
}
