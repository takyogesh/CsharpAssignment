using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBookingSystem
{
    public enum BookingStatus { Pending, Confirmed, Cancled }
    public enum PaymentStatus{ Unpaid, Pending, Completed, Failed, Cancelled, Refunded }
    public class Booking
    {
        private String bookingNumber;
        private int numberOfSeats;
        private DateTime createdOn;
        private BookingStatus status;
        private Show show = Show.getInstance();
        
        public bool cancel;
        List<Account> acc;

        public void bookSeat(String name,int seat)
        {
            List<Movie> movie =show.availableMovie();
            //take movie name and seat number to book the seat
            Console.WriteLine("Seat book");
            try
            {
                foreach (var m in movie)
                {
                    {
                        bookingNumber = "101";
                        numberOfSeats = seat;
                        createdOn = DateTime.Now;
                        status = BookingStatus.Confirmed;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("null pointer exception");
            }
        }


    }

   
}
