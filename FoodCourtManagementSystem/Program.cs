using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    class Program
    {
        /* static void Main(string[] args)
         {
           
            
           
             Console.Read();
         }*/
        private static void menu()
        {
           // Console.WriteLine("Press 1 : for manage the user");
            Console.WriteLine("Press 1 : for The Manage Food Items");
            Console.WriteLine("Press 2 : for the Manage the Category ");
            Console.WriteLine("Press 3 : for the Manage the sales");
            Console.WriteLine("Press 4: for the Reports Of The Project Food Court Management System");

            Console.WriteLine("Press 5 : exit");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Account.admin ad = new Account.admin();
            ad.register(1, "Yogesh", "1122334455", "yo@123");
            ad.register(2, "Pratik", "1112223334", "pr@123");
            ad.register(3, "Vinay", "1111222233", "vi@123");
            FoodCategory manageFoodCategory = new FoodCategory();
            Sales manageSales = new Sales();
            FoodItems manageFoodItems = new FoodItems();
            Reports report = new Reports();
        mainmenu:
            menu();


            int choisedata = Convert.ToInt32(Console.ReadLine());
            switch (choisedata)
            {
                case 1:
                    manageFoodItems.ManageFI();
                    goto mainmenu;
                case 2:
                    manageFoodCategory.ManageFC();
                    goto mainmenu;
                case 3:
                    manageSales.ManageSale();
                    goto mainmenu;
                case 4:
                    report.ManageReport();
                    goto mainmenu;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong choise");
                    goto mainmenu;

            }

            Console.ReadLine();
        }
    }
}
