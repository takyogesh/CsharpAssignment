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
            Console.WriteLine(" Manage Item      \t Press :1  ");
            Console.WriteLine(" Manage Customres \t Press :2  ");
            Console.WriteLine(" Close App        \t Press :3  ");
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
    }
}
