using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
    enum category { Veg, NonVeg,chinese,Icecream, Colddrink}
  public class FoodCategory
    {
        public static List<FoodCategory> categoryList = new List<FoodCategory>();
        int categoryID;
        string categoryType;

        public FoodCategory() { }
        public FoodCategory(int categoryID, string categoryType)
        {
            this.categoryID = categoryID;
            this.categoryType = categoryType;
        }
        public override string ToString()
        {
            return "" + categoryID + "" + categoryType + "";
        }

        public void addCategory(int categoryID, int categoryType)
        {
            String s = Enum.GetName(typeof(category), categoryType);
            categoryList.Add(new FoodCategory(categoryID,s));
        }
        public void listOfCategory()
        {
            foreach(var l in categoryList)
            {
                Console.WriteLine(l);
            }
        }
        
    }
}
