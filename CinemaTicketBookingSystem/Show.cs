using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBookingSystem
{
   public class Show
    {
            private int showId;
            private DateTime startTime;
            private DateTime endTime;
            private CinemaHall playedAt;
            private Movie movie;
        CineCinemaHallSeat seat = new CineCinemaHallSeat();
        public List<Movie> m = new List<Movie>();
        static Show show = null;
        private Show() { }
        public static Show getInstance()
        {
            if (show == null)
                return new Show();
            else
                return show;
        }

        public void addShow()
        {
            Console.WriteLine("Show added");
            m.Add(new Movie("Veer", "ActionMovie", 3, "Hindi", DateTime.Parse("5/25/2015"), "india"));
            m.Add(new Movie("Sholay", "ActionMovie",4, "Hindi", DateTime.Parse("2/14/1998"), "india"));
            m.Add(new Movie("RRR", "ActionMovie", 2, "Hindi", DateTime.Parse("4/18/2022"), "india"));
            seat.addSeat();
        }
        public List<Movie> availableMovie()
        {
            foreach(var avlMovie in m)
            {
                Console.WriteLine(avlMovie);
            }
            return m;
        }
    }
    public class Movie
    {
            private String title;
            private String description;
            private int durationInMins;
            private String language;
            private DateTime releaseDate;
            private String country;

        public Movie(string title, string description, int durationInMins, string language, DateTime releaseDate, string country)
        {
            this.title = title;
            this.description = description;
            this.durationInMins = durationInMins;
            this.language = language;
            this.releaseDate = releaseDate;
            this.country = country;
        }
    }
}
