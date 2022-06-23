using Microsoft.EntityFrameworkCore;
using TrainMaster.Entities;

namespace TrainMaster
{
    public class TrainMasterContext: DbContext
    {
        public TrainMasterContext()
        { }

        public virtual DbSet<TrainSchedule> ? TrainSchedules { get; set; }
        public virtual DbSet<Train> ? Trains  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-00LQG0A;Initial Catalog=TrainMasterCF;Integrated Security=True;");
        }
       
    }
}
