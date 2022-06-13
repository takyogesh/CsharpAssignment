using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
  public class FoodCategory : ReadAndWrite
    {
        public static List<FoodCategory> categoryList = new List<FoodCategory>();
        ArrayList arrayList = new ArrayList();
        int categoryID;
        string categoryType;

        public FoodCategory() { }
       /* public FoodCategory(int categoryID, string categoryType)
        {
            this.categoryID = categoryID;
            this.categoryType = categoryType;
        }*/
      /*  public override string ToString()
        {
            return "" + categoryID + "" + categoryType + "";
        }*/
        public void ManageFC()
        {
           Repeat:
            menu();
            int choise = Convert.ToInt32(System.Console.ReadLine());
            switch (choise)
            {
                case 1:
                addmore:
                    Console.Write(" Enter Category id ");
                    int categoryID = Convert.ToInt32(System.Console.ReadLine());
                    Console.Write("Enter Category Tyoe ");
                    string categoryType = Console.ReadLine();
                    string date = DateTime.Now.ToString();
                    // arrayList.Add(new FoodCategory(catId,catName));
                    arrayList.Add(categoryID);
                    arrayList.Add(categoryType);
                    arrayList.Add(date);
                    AddnewItem(@"D:\FoodCourt\category.txt", arrayList);
                    arrayList.Clear();
                    Console.WriteLine("To add more choose 1:");
                    int check = Convert.ToInt32(Console.ReadLine());
                    if (check == 1)
                    {
                        goto addmore;
                    }
                    goto Repeat;
                case 2:
                    Console.Write("Enter the category id To Show Of Its Details : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the category name To Show Of Its Details : ");
                    string name = Console.ReadLine();
                    ViewDetailsOfItems(id, name, @"D:\FoodCourt\category.txt");
                    goto Repeat;
                case 3:
                    ListAllItem(@"D:\FoodCourt\category.txt");
                    goto Repeat;
                case 4:
                updatemore:
                    Console.Write("Enter the   category id To update Of Its Details : ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the  category name To update Of Its Details : ");
                    string updateCatType = Console.ReadLine();
                    ViewDetailsOfItems(updateId, updateCatType, @"D:\FoodCourt\category.txt");
                    Console.Write("Enter the new Name Of its Above Category : ");
                    string updatename = Console.ReadLine();
                    string date2 = DateTime.Now.ToString();
                    arrayList.Add(updateId);
                    arrayList.Add(updateCatType);
                    arrayList.Add(date2);
                    UpdateExistItem(updateId, updateCatType, arrayList, @"D:\FoodCourt\category.txt");
                    arrayList.Clear();
                    Console.Write("To add more choose 1:");
                    int check2 = Convert.ToInt32(Console.ReadLine());
                    if (check2 == 1)
                    {
                        goto updatemore;
                    }
                    goto Repeat;

                case 5:
                    break;
                default:
                    Console.WriteLine(" wrong Choise ");
                    goto Repeat;
            }
        }
        private void menu()
        {
            Console.WriteLine("Press 1 : for The Add New Category ");
            Console.WriteLine("Press 2 : for the Show Details Of category ");
            Console.WriteLine("Press 3 : for the Show List Of All cateGory ");
            Console.WriteLine("Press 4 : Update The Exist category ");
            Console.WriteLine("Press 5 : Home Menu");
            Console.WriteLine();
        }
    }
}
