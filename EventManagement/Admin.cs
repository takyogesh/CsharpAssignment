using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EventManagement
{
   public class Admin
    {
        int id;
        string name;
        string ph;
        string password;
        string role;
        public string connectionStr = Events.connectionStr;

        public string RegisterAdmin()
        {
            Console.WriteLine("Enter the Name");
            name = Console.ReadLine();  
            Console.WriteLine("Enter the phone number");
            ph = Console.ReadLine(); 
            Console.WriteLine("Enter the Passward");
            password = Console.ReadLine();
           
            role = "Admin";
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("Insert into Admin values('"+name+"','"+ph+"','"+password+"','"+role+"')", connection);
            connection.Open();
            int rowAffected= command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected == 0)
                return "Not Inserted";
            return "Inserted";
        }
        public void GetAllListOfCustomer()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand("select ID,Name,Phone from Admin where Role='Customer'", connection);
            DataTable dt = new DataTable();
            connection.Open();
            SqlDataReader sda = command.ExecuteReader();
            dt.Load(sda);
            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
       
    }
}
