using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.addAccount("A101", "123@abc", "akash");
            account.addAccount("A102", "123@gmail", "piyush");
            Account.getList();
           
            Show show = Show.getInstance();
            show.addShow();
            Booking b = new Booking();
            b.bookSeat("veer", 3);
            Console.Read();
        }
    }
}
