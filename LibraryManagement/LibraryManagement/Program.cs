using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagingInventory managingInventoryObj= new ManagingInventory();
            managingInventoryObj.userRegister();
           managingInventoryObj.allUser();
            managingInventoryObj.addBook();
            managingInventoryObj.allBooks();
            managingInventoryObj.BorrowBook();
            managingInventoryObj.issuedDetail();
            Console.Read();
        }
    }
}
