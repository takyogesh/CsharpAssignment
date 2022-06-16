using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagement
{
   public class Customer
    {
        int id;
        string name;
        string ph;
        string password;
        string role;
        public string connectionStr = Events.connectionStr;

        public string RegisterCustomer()
        {
            Console.WriteLine("Enter the Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter the phone number");
            ph = Console.ReadLine();
            Console.WriteLine("Enter the Passward");
            password = Console.ReadLine();

            role = "Customer";
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("Insert into Admin values('" + name + "','" + ph + "','" + password + "','" + role + "')", connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected == 0)
                return "Not Inserted";
            return "Inserted";
        }
        public void Login(string username, string password)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("select ID from Admin where Phone='" + username + "'and Passward ='"+password+"'", connection);
            connection.Open();
           command.ExecuteNonQuery();
          
                Console.WriteLine("Enter the Venue you look for booking");
                String venue = Console.ReadLine();
                Events.AvlEvent();
                Events.Book();
                connection.Close();
           
        }


    }
}
