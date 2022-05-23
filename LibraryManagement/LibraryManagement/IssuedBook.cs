using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class IssuedBook
    {
        static Books booksObj = Books.getInstance();
        static User userObj = User.getInstance();

        String issueDate = DateTime.Now.ToShortDateString();
        String returnDate;
        int costPerDay { get; } = 10;
        int fine { get; }=200;

        static int size = 5;
        String[] UserDetail = new String[size];
        String[] UpdatedUserDetail = new String[size];
        static int index = 0;

        String[] users = userObj.allUser();
        int userIndex = 0;
        String[] allBooks = booksObj.allBooks();
        int bookIndex = 0;
        public Boolean bookExist(String bookName)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (allBooks[i].Contains(bookName))
                {
                    bookIndex = i;
                    return true;
                }
            }
            bookIndex = -1;
            return false;

        }
        public Boolean userExist(int userID)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Contains(Convert.ToString(userID)))
                {
                    userIndex = i;
                    return true;
                }
            }
            userIndex = -1;
            return false;
        }

        public void borrow(int userID,String bookName)
        {
            Boolean isUserRegister = userExist(userID);
            Boolean isBookAvl = bookExist(bookName);
            if (!isUserRegister)
                Console.WriteLine("User not register");
            else if (!isBookAvl)
                Console.WriteLine("Book not available");
            else if(isUserRegister && isBookAvl)
            {
                if (index < UserDetail.Length)
                {
                    UserDetail[index++] = "userID\t" + userID + "\tbookName\t" + bookName + "\tissueDate\t" + issueDate;
                }
                else
                {
                    int newSize = size + 1;
                    String[] usersNew = new string[newSize];
                    for (int i = 0; i < users.Length; i++)
                    {
                        usersNew[i] = UserDetail[i];
                    }
                    usersNew[index++] = "userID\t" + userID + "\tbookName\t"+ bookName + "\tissueDate\t"+ issueDate;
                    UserDetail = usersNew;
                }
            }
        }
        public void returnBook(String returnDate, int userID, String bookName)
        {
           this.returnDate = returnDate;

            //string returndate = "5/26/2022";
            DateTime iDate = Convert.ToDateTime(returnDate);
            DateTime rDate = Convert.ToDateTime(iDate);

            var d = iDate - rDate;
            int totalCost = 0;
            if (d.Days<7)
                totalCost = d.Days* costPerDay;
            else
                totalCost = (fine) + d.Days * costPerDay;

            int index = 0;
            for(int i=0;i<users.Length;i++)
            {
                if (!(!allBooks[i].Contains(bookName) || !users[i].Contains(Convert.ToString(userID))))
                {
                    index = i;
                }
                else
                    index = 0;
            }
            int uIndex = 0;
            String old = UserDetail[index];
            UpdatedUserDetail[uIndex++] = UserDetail[index] + "returnDate" + returnDate + "totalCostOfIssue"+ totalCost;
        }
        public void UserDetails()
        {
            foreach (string s in UserDetail)
                Console.WriteLine(s);
        }
        public void AllDetails()
        {
            foreach (string s in UpdatedUserDetail)
                Console.WriteLine(s);
        }




    }
}
