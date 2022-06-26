using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainMaster.Models
{
    public partial class TrainMasterDFContext : DbContext
    {
        public TrainMasterDFContext()
        {
        }

        public TrainMasterDFContext(DbContextOptions<TrainMasterDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Train> Trains { get; set; } = null!;
        public virtual DbSet<TrainSchedule> TrainSchedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-00LQG0A;Database=TrainMasterDF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.Property(e => e.TrainNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<TrainSchedule>(entity =>
            {
                entity.HasIndex(e => e.TrainNo, "IX_TrainSchedules_TrainNo1");

                entity.Property(e => e.Id).HasAnnotation("SqlServer:Identity", "1, 1");

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.TrainSchedules)
                    .HasForeignKey(d => d.TrainNo)
                    .HasConstraintName("FK_TrainSchedules_Trains_TrainNo1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
