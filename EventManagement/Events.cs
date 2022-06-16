using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagement
{
    class Events
    {
        int id;
        string eventName;
        int days;
        string venue;
        int venueCostPerDay;
        string lighting;
        int lightingCost;
        string flowers;
        int flowersCost;
        string food;
        int foodCost;
        int total;


        public static string connectionStr = "Data Source=DESKTOP-00LQG0A;Initial Catalog=eventManagement;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionStr);
        public void AddEventDetail()
        {
            Console.WriteLine("Enter the Event Name");
            eventName = Console.ReadLine();
            Console.WriteLine("Enter the number of days require for event");
            days = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Venue Name");
            venue = Console.ReadLine();
            Console.WriteLine("Enter the venue cost per day");
            venueCostPerDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the lighting type");
            lighting = Console.ReadLine();
            Console.WriteLine("Enter the lighting cost");
            lightingCost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the flowres decorators");
            flowers = Console.ReadLine();
            Console.WriteLine("Enter the decorating cost");
            flowersCost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the food cater");
            food = Console.ReadLine();
            Console.WriteLine("Enter the food catering cost");
            foodCost = Convert.ToInt32(Console.ReadLine());
            int total = days * (venueCostPerDay+lightingCost+flowersCost+foodCost);
            SqlDataAdapter sda = new SqlDataAdapter("Insert into Event values('" + eventName + "'," + days + ",'" + venue + "'," + venueCostPerDay + ",'"+lighting+"',"+lightingCost+",'"+flowers+"',"+flowersCost+",'"+food+"',"+foodCost+","+total+")", 
                connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void ListOfEvent()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Event", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static void AvlEvent()
        {
            Console.WriteLine("enter the venue you want to check detail");
            string venue = Console.ReadLine();
            SqlDataAdapter sda = new SqlDataAdapter("select eventName,venueCostPerDay,Lighting,lightingCost,flowers,flowersCost,foodCater,foodCterCost from Event where venue='"+venue+"'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Rows[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }

        public static void Book()
        {
            Console.WriteLine("enter the venue you want to book");
            string ven = Console.ReadLine();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Event where venue='" + ven +"'",connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int ID = Convert.ToInt32(dt.Rows[0][0]);
            string eventName = Convert.ToString(dt.Rows[0][1]);
            int days = Convert.ToInt32(dt.Rows[0][2]);
            string venue = Convert.ToString(dt.Rows[0][3]);
            int venueCostPerDay = Convert.ToInt32(dt.Rows[0][4]);
            string lighting = Convert.ToString(dt.Rows[0][5]); 
            int lightingCost = Convert.ToInt32(dt.Rows[0][6]);
            string flowers = Convert.ToString(dt.Rows[0][7]);
            int flowersCost = Convert.ToInt32(dt.Rows[0][8]);
            string food = Convert.ToString(dt.Rows[0][9]);
            int foodCost = Convert.ToInt32(dt.Rows[0][10]);
            Console.WriteLine("enter number of days to book this venue");
            days = Convert.ToInt32( Console.ReadLine());
            int total = days * (venueCostPerDay + lightingCost + flowersCost + foodCost);

            SqlDataAdapter sda1 = new SqlDataAdapter("Insert into Customer values("+ID+",'"+eventName+"',"+days+",'"+venue+"','"+lighting+"','"+flowers+"','"+food+"',"+total+")", connection);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
        }



    }
}
