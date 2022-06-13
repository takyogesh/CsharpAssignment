using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtManagementSystem
{
   public class Sales: ReadAndWrite
    {
        ArrayList arrayList = new ArrayList();
        public void ManageSale()
        {
        AgainAndAgain:
            menu();
            int choise = Convert.ToInt32(System.Console.ReadLine());
            switch (choise)
            {
                case 1:
                addmore:
                    Console.Write(" Enter the new sales id : ");
                    int newsalesid = Convert.ToInt32(System.Console.ReadLine());
                    Console.Write("Enter the New sales item name : ");
                    string newsaleitemname = Console.ReadLine();
                    Console.Write("Enter the Customer Name");
                    string cusname = Console.ReadLine();
                    Console.Write("Enter customer Phone Number : ");
                    long phone = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Number of Plate :  ");
                    int noPlate = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the cost As per Plate : ");
                    int perplatecost = Convert.ToInt32(Console.ReadLine());


                    string date = DateTime.Now.ToString();
                    arrayList.Add(newsalesid);
                    arrayList.Add(newsaleitemname);
                    arrayList.Add(cusname);
                    arrayList.Add(phone);
                    arrayList.Add(perplatecost);
                    arrayList.Add(noPlate);
                    arrayList.Add(noPlate * perplatecost);
                    arrayList.Add(date);
                    AddnewItem(@"D:\FoodCourt\sales.txt", arrayList);
                    arrayList.Clear();
                    Console.Write(" Do you Want more Press 1:");
                    int check = Convert.ToInt32(Console.ReadLine());
                    if (check == 1)
                    {
                        goto addmore;
                    }
                    goto AgainAndAgain;
                case 2:
                    Console.Write("Enter the sales id To Show Of Its Details : ");
                    int showcatid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the sales name To Show Of Its Details : ");
                    string showcatname = Console.ReadLine();
                    ViewDetailsOfItems(showcatid, showcatname, @"D:\FoodCourt\sales.txt");
                    goto AgainAndAgain;
                case 3:
                    ListAllItem(@"D:\FoodCourt\sales.txt");
                    goto AgainAndAgain;
                case 4:
                updatemore:
                    Console.Write("Enter the   sales id To update Of Its Details : ");
                    int updatesalesid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the  sales name To update Of Its Details : ");
                    string updatesalesname = Console.ReadLine();
                    ViewDetailsOfItems(updatesalesid, updatesalesname, @"D:\FoodCourt\sales.txt");
                    Console.Write("Enter the update sales item name ");
                    string newsaleitemname2 = Console.ReadLine();
                    Console.Write("Enter the  update Customer Name");
                    string cusname2 = Console.ReadLine();
                    Console.Write("Enter customer  update Phone Number");
                    long phone2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the update  Number of Plate ");
                    int noPlate2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the  update cost As per Plate");
                    int perplatecost2 = Convert.ToInt32(Console.ReadLine());


                    string date2 = DateTime.Now.ToString();
                    arrayList.Add(updatesalesid);
                    arrayList.Add(newsaleitemname2);
                    arrayList.Add(cusname2);
                    arrayList.Add(phone2);
                    arrayList.Add(perplatecost2);
                    arrayList.Add(noPlate2);
                    arrayList.Add(noPlate2 * perplatecost2);
                    arrayList.Add(date2);
                    UpdateExistItem(updatesalesid, updatesalesname, arrayList, @"D:\FoodCourt\sales.txt");
                    arrayList.Clear();
                    Console.Write(" Do you Want more Press 1:");
                    int check2 = Convert.ToInt32(Console.ReadLine());
                    if (check2 == 1)
                    {
                        goto updatemore;
                    }
                    goto AgainAndAgain;



                case 5:
                    break;
                default:
                    Console.WriteLine(" wrong Choise ");
                    goto AgainAndAgain;
            }
        }

        private void menu()
        {
            Console.WriteLine("Press 1 : for The Add New Sales ");
            Console.WriteLine("Press 2 : for the Show Details Of sales ");
            Console.WriteLine("Press 3 : for the Show List Of All sales ");
            Console.WriteLine("Press 4 : Update The Exist sales ");
            Console.WriteLine("Press 5 : Goto OutSide");
            Console.Write("                                                     ");

        }
    }
}
