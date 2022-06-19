using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAssignmentConsole
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ItemModule item = new ItemModule();
            CustomerModule customer = new CustomerModule();
        Menu:
            menu();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    item.ItemMenu();
                    goto Menu;
                case 2:
                    customer.Menu();
                    goto Menu;
                case 3:
                    Environment.Exit(0);
                    break;
            }
            Console.Read();
        }
        private static void menu()
        {
            Console.WriteLine(" Manage Item      Press :1  ");
            Console.WriteLine(" Manage Customres Press :2  ");
            Console.WriteLine(" Close App        Press :3  ");
        }
    }
}
