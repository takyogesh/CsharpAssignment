using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrderAssignmentConsole
{
   public class CustomerModule
    {
         public static string connectionString = @"Data Source=DESKTOP-00LQG0A;Initial Catalog=OrderAssignmentConsoleApp;Integrated Security=True";
         SqlConnection connection = new SqlConnection(connectionString);
         DataTable dataTable = new DataTable();
         SqlDataAdapter sda;
         string FirstName;
         string LastName;
         string PhoneNumber;
         string Email;
      
        private void TakeInput()
        {
            Console.WriteLine("Enter the First Name");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter The Last Name");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter the Phone Number");
            PhoneNumber = Console.ReadLine();
            if (FirstName != "" && LastName != "" && PhoneNumber.ToString().Length == 10 && Email != "")
            {
            EnterValidmail:
                Console.WriteLine("Enter the Email");

                Email = Console.ReadLine();
                if (!MailValidate(Email))
                {
                    Console.WriteLine("Enter Valid Email Address");
                    goto EnterValidmail;
                }
            }
        }
        #region AddCustomer
        public void AddCustomers()
        {
            TakeInput();
            try
            {
                if (!CustomerExistOrNot(Email))
                {
                    string sql = "insert into Customers values('" + FirstName + "','" + LastName + "'," + PhoneNumber + ",'" + Email + "')";
                    sda = new SqlDataAdapter(sql, connection);
                    sda.Fill(dataTable);
                    Console.WriteLine("Customer Add Successfully ");
                    MailSend(Email, FirstName, LastName);
                }
                else
                {
                    Console.WriteLine("User Already Exist Use Another   ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region DeleteCustomer
        public void DeleteCustomers()
        {
            Console.WriteLine("Enter The Valid Eamil That Customer You Want to delete");
            Email = Console.ReadLine();
            if (MailValidate(Email))
            {
                if (CustomerExistOrNot(Email))
                {
                    string sql = "delete from Customers where Email='" + Email + "'";
                    sda = new SqlDataAdapter(sql, connection);
                    sda.Fill(dataTable);
                    Console.WriteLine("Customer Delete Successfully..");
                }
                else
                    Console.WriteLine(" Email Does not exist in the record");
            }
            else
            {
                Console.WriteLine("Enter the Valid Email");
            }
        }
        #endregion
        #region UpdateCustomer
        public void UpdateCustomers()
        {
            string newEmail;
                Console.WriteLine("Enter the Email");
                Email = Console.ReadLine();
                string oldEmail = Email;
            if (MailValidate(Email))
            {
                if (CustomerExistOrNot(Email))
                {
                    TakeInput();
                    try
                    {
                        string sql = "update Customers set FirstName='" + FirstName + "',LastName='" + LastName + "',Phone_no=" + PhoneNumber + ",Email='" + Email + "' where Email='" + oldEmail + "'";
                        sda = new SqlDataAdapter(sql, connection);
                        sda.Fill(dataTable);
                        Console.WriteLine(" Update data Successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
                else
                    Console.WriteLine("Customer Does not Exist with this Email Address\n Enter The data again");
            }
            else
                Console.WriteLine("Please Enter The Valid Email");
        }
        #endregion
        #region List of All Customer
        public void ListOfAllCustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                sda = new SqlDataAdapter("select * from Customers", connection);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //print column
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        Console.Write(dt.Columns[i].ColumnName + "    ");
                    }
                    Console.WriteLine();
                    //print all the list of register customer
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            Console.Write(dt.Rows[i][j] + "       ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("No Data Found...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        private bool CustomerExistOrNot(string mail)
        {
            DataTable dt = new DataTable();
            string sql = "select * from Customers where Email='" + mail + "'";
            sda = new SqlDataAdapter(sql, connection);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void MailSend(string to, string firstname, string lastname)
        {
            string from = "ytak989@gmail.com";
            string password = "jmhxccwbsjppybiz";
            string subject = "Welcome Dear Customer";
            string body = "<h1>Dear, " + firstname + " " + lastname + "</h1> \n Thanks for registering with us";
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public bool MailValidate(string email)
        {
            Regex eml = new Regex(@"^[a-zA-Z]+[._]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}([.]+[a-zA-Z]{2,3}){0,1}");
            Match m = eml.Match(email);
            if (m.Success)
                return true;
            else
                return false;
        }
        public void Menu()
        {
            MainMenu:
            Console.WriteLine("To Add Customer      Press :1 ");
            Console.WriteLine("To Delete Customer   Press :2 ");
            Console.WriteLine("To update Customer   Press :3 ");
            Console.WriteLine("To Show All Customer Press :4 ");
            Console.WriteLine("To Exit              Press :5 ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddCustomers();
                    goto MainMenu;
                case 2:
                    DeleteCustomers();
                    goto MainMenu;
                case 3:
                    UpdateCustomers();
                    goto MainMenu;
                case 4:
                    ListOfAllCustomer();
                    goto MainMenu;
                case 5:
                    break;
            }
        }
    }
}