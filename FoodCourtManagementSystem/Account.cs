using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using newt

namespace FoodCourtManagementSystem
{
   public class Account
    {
           public static  List<admin> adminList = new List<admin>();
           public static  List<customer> customerList = new List<customer>();

       public class admin
        {
            int id;
            string name;
            string ph;
            string pass;
           
            public admin() { }
            public admin(int id, string name, string ph,string pass)
            {
                this.id = id;
                this.name = name;
                this.ph = ph;
                this.pass = pass;
            }
            public void register(int id, string name, string ph, string pass)
            {
                if (adminList == null)
                {
                    adminList.Add(new admin(id, name, ph, pass));
                }
                else
                {
                    foreach(var list in adminList)
                    {
                        if (list.id != id)
                        {
                            adminList.Add(new admin(id, name, ph, pass));
                        }
                        else
                            Console.WriteLine("admin already exist");
                    }
                }
            }
        } 
       public class customer
        {
            int id;
            string name;
            string ph;
            string pass;
            public customer() { }
            public customer(int id, string name, string ph, string pass)
            {
                this.id = id;
                this.name = name;
                this.ph = ph;
                this.pass = pass;
            }
            public void register(int id, string name, string ph, string pass)
            {
               
                if (adminList == null)
                {
                    customerList.Add(new customer(id, name, ph, pass));
                }
                else
                {
                    foreach (var list in customerList)
                    {
                        if (list.id != id)
                        {
                            customerList.Add(new customer(id, name, ph, pass));
                        }
                        else
                            Console.WriteLine("customer already exist");
                    }
                }
            }
        }
        public class ReadWrite
        {
            public static void WriteToFile(string fileName, string data)
            {
                File.WriteAllText(fileName, data);
            }

            public static string ReadFromFile(string fileName)
            {
                return File.ReadAllText(fileName);
            }
            private static string SerializeData(List<T> list)
            {
                string result = JsonConvert.SerializeObject(list);
                return result;
            }
        }
    }
}
