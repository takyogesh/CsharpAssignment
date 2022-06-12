using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    public class FoodItems
    {
        int sr;
        string foodName;
        int stock;
        DateTime day;
        Dictionary<string, int> priceList = new Dictionary<string, int>();
        List<FoodCategory> listCat = FoodCategory.categoryList;
       public List<FoodItems> foodItems = new List<FoodItems>();
        FoodCategory foodCategory = new FoodCategory();
        public FoodItems(){ }
        public FoodItems(int sr, string foodName, int stock)
        {
            this.sr = sr;
            this.foodName = foodName;
            this.stock = stock;
            this.day = DateTime.Now;
        }
        public void addItems()
        {
            /*  1 Veg
                2 Icecream
                3 NonVeg
            */
            Console.WriteLine("Choose category");
            foodCategory.listOfCategory();
            foreach(var lis in listCat)
            {
                
            }



        }
        

    }
}
