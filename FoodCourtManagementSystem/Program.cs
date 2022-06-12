using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Account.admin ad = new Account.admin();
            ad.register(1,"yogi","9822245588","abc@123");
            ad.register(2,"yogi","9822245588","abc@123");
            ad.register(3,"yogi","9822245588","abc@123");
            FoodCategory foodCategory = new FoodCategory();
            foodCategory.addCategory(1,0);
            foodCategory.addCategory(2,3);
            foodCategory.addCategory(3,1);
            
            FoodItems fi = new FoodItems();
            fi.addItems();

            Console.Read();


        }
    }
}
