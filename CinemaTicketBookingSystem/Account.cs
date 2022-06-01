using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBookingSystem
{
   public class Account
    {
        private String id;
        public String name;
        private String password;
        static List<Account> account = new List<Account>();

        public Account(string id, string password, string name)
        {
            this.id = id;
            this.password = password;
            this.name = name;
        }

        public Account()
        { }
        public static  void getList()
        {
            try
            {
                for (int i = 0; i < account.Count; i++)
                {
                    Console.WriteLine(account[i].id + " " + account[i].name);
                }
            }
            catch
            {
                Console.WriteLine("");
            }
        }
        public void addAccount(string id, string password, string name)
        {
            {
                for (int i = 0; i <=account.Count; i++)
                {
                    try
                    {
                        if (!account[i].id.Contains(id))
                            account.Add(new Account(id, password, name));
                        else
                            Console.WriteLine("account exist");
                    }
                    catch
                    {
                        account.Add(new Account(id, password, name));
                        break;
                    }
                }
            }
        }
        public bool resetPassword(String id,String passward)
        {
            bool flag = false;
            foreach(var list in account)
            {
                if(list.id==id)
                {
                    list.password = password;
                    flag = true;
                }
            }
            return flag;
        }
    }
    public abstract class Person
    {
       public abstract void addUser(string name, string address, string email, string phone);
        public abstract void addAdmin(string name, string address, string email, string phone);

       //public abstract bool Account(string name);
    }
    public class Customer : Person
    {
        private String name;
        private String address;
        private String email;
        private String phone;
        List<Account> acc;
        List<Customer> custAdmin = new List<Customer>();
        List<Customer> custUser = new List<Customer>();
        public Customer(string name, string address, string email, string phone)
        {
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

        public override void addAdmin(string name, string address, string email, string phone)
        {
            foreach(var data in acc)
            {
                if(data.name==name)
                {
                    custAdmin.Add(new Customer(name, address, email, phone));
                }
            }
            Console.WriteLine("admin add");
        }

        public override void addUser(string name, string address, string email, string phone)
        {
            foreach (var data in acc)
            {
                if (data.name == name)
                {
                    custUser.Add(new Customer(name, address, email, phone));
                }
            }
            Console.WriteLine("user add"); 
        }
    }

}
