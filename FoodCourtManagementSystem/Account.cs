using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                    ReadWrite.WriteToFile("AdminList.json", JsonConvert.SerializeObject(adminList));
                }
                else
                {
                    foreach(var list in adminList)
                    {
                        if (list.id != id)
                        {
                            String oldFile = ReadWrite.ReadFromFile("AdminList.json");
                            List<admin> updateAdminList = JsonConvert.DeserializeObject<List<admin>>(oldFile);
                            updateAdminList.Add(new admin(id, name, ph, pass));
                            ReadWrite.WriteToFile("AdminList.json", JsonConvert.SerializeObject(updateAdminList));
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
                    ReadWrite.WriteToFile("CustomerList.json", JsonConvert.SerializeObject(customerList));
                }
                else
                {
                    foreach (var list in customerList)
                    {
                        if (list.id != id)
                        {
                            String oldFile = ReadWrite.ReadFromFile("CustomerList.json");
                            List<customer> updateCustomerList = JsonConvert.DeserializeObject<List<customer>>(oldFile);
                            updateCustomerList.Add(new customer(id, name, ph, pass));
                            ReadWrite.WriteToFile("AdminList.json", JsonConvert.SerializeObject(updateCustomerList));

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
          
        }
    }
}
