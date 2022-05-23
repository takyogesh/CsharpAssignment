using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Books
    {
        int bookID;
        String bookName;
        String bookAuthor;

        static int size = 5;
        string[] books = new string[size];
        static int index = 0;

        private static Books instance = null;

        public static Books getInstance()
        {
            if (instance == null)
            {
                instance = new Books();
            }
            return instance;
        }
        private Books()
        {
            bookID = 0;
            bookName = "";
            bookAuthor = "";
            books[index++] = "bookID\tbookName\tbookAuthor";


        }
        public void addBooks(int id, string name, string author)
        {
            this.bookID = id;
            this.bookName = name;
            this.bookAuthor = author;
            if (index < books.Length)
                books[index++] = bookID + "\t" + bookName + "\t" + bookAuthor;
            else
            {
                int newSize = size + 1;
                String[] newBooks = new string[newSize];
                for (int i = 0; i < books.Length; i++)
                {
                    newBooks[i] = books[i];
                }
                newBooks[index++] = bookID + "\t" + bookName + "\t" + bookAuthor;
                books = newBooks;
            }
        }
        public void booksDetails()
        {
            foreach (string s in books)
                Console.WriteLine(s);
        }
        public String[] allBooks()
        {
            return books;
        }

    }
}
