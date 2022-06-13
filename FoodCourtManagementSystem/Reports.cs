using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    class Reports :ReadAndWrite
    {
        public void ManageReport()
        {
        upper:
            menu();
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    ListAllItem(@"D:\FoodCourt\fooditem.txt");
                    goto upper;
                case 2:
                    ListAllItem(@"D:\FoodCourt\category.txt");
                    goto upper;
                case 3:
                    ListAllItem(@"D:\FoodCourt\sales.txt");
                    goto upper;
                case 4:
                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    goto upper;
            }
        }
        private void menu()
        {
            Console.WriteLine("Press 1 : for The Show Reports Of FoodItems ");
            Console.WriteLine("Press 2 : for the Show Reports of food category ");
            Console.WriteLine("Press 3 : for the Show Reports of sales");
            Console.WriteLine("Press 4 : Goto OutSide");
            Console.WriteLine();
        }
    }
}
