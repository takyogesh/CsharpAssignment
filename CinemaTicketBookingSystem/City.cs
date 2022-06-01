using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBookingSystem
{
    public class City
    {
            private String name;
            private String state;
            private String zipCode;

    }
    public class Cinema
    {
            private String name;
            private int totalCinemaHalls;
            private String location;
            private List<CinemaHall> halls;
    }
    public class CineCinemaHallSeat
    {
        private string row;
        private int column;
       static Dictionary<Char, int> seats = new Dictionary<Char, int>();
        public void addSeat()
        {
            Console.WriteLine("Seat added");
            int row= 1;
            int c = 65;
            
           while(row<11 && c<75)
            {
                char col = Convert.ToChar(c);
                seats.Add(col,row);
                row++;c++;
            }
        }
       public static Dictionary<Char,int> getSeat()
        {
            return seats;
        }
    }

    public class CinemaHall
    {
        private String name;
        public Dictionary<Char, int> seats = CineCinemaHallSeat.getSeat();
        List<CinemaHall> hallList = new List<CinemaHall>();

        public CinemaHall(string name)
        {
            this.name = name;
        }
        public void AddCinemaHall(String nameOfHall)
        {
            try
            {
                hallList.Add(new CinemaHall(nameOfHall));
            }
            catch
            {
                Console.WriteLine("erroe while add hall");
            }

        }
    }
   
}
