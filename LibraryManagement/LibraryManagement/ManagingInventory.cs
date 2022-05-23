using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class ManagingInventory
    {
        // To add delete books in record
        User userObj = User.getInstance();
        //add user
        public void userRegister()
        {
            /* Console.WriteLine("Enter user iD");
             int id = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Enter user Name");
             String name = Console.ReadLine();
             Console.WriteLine("Enter user Pass");
             String pass = Console.ReadLine();

              userObj.addUser(id, name, pass);
             Console.WriteLine("User Added Successfully");*/
            userObj.addUser(1, "yoge", "9999");
            userObj.addUser(2, "akash", "9999");
            userObj.addUser(3, "vinay", "9999");
        }
        // get all user details
        public void allUser()
        {
            userObj.userDetails();
        }

        Books booksObj = Books.getInstance();
        public void addBook()
        {
            booksObj.addBooks(1, "TOM", "JkRowling");
            booksObj.addBooks(2, "M3", "Patnaik");
            booksObj.addBooks(3, "Java", "Gosling");
        }
        public void allBooks()
        {
            booksObj.booksDetails();
        }

        IssuedBook handler = new IssuedBook();
        public void BorrowBook()
        {
            handler.borrow(1, "Java");
        }
        public void issuedDetail()
        {
            handler.UserDetails();
        }
        public void returnBook()
        {
            handler.returnBook("5/30/2022", 1, "java");
        }
        public void allRecord()
        {
            handler.AllDetails();
        }
        


    }
}
