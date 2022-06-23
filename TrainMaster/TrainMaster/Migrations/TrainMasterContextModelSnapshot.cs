﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainMaster;

#nullable disable

namespace TrainMaster.Migrations
{
    [DbContext(typeof(TrainMasterContext))]
    partial class TrainMasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrainMaster.Entities.Train", b =>
                {
                    b.Property<int>("TrainNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainNo"), 1L, 1);

                    b.Property<string>("FromStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("JourneyEndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("JourneyStartTime")
                        .HasColumnType("time");

                    b.Property<string>("ToStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainNo");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("TrainMaster.Entities.TrainSchedule", b =>
                {
                    b.Property<int?>("TrainNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("TrainNo"), 1L, 1);

                    b.Property<int?>("TrainNo1")
                        .HasColumnType("int");

                    b.Property<string>("TrainRunDays")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainNo");

                    b.HasIndex("TrainNo1");

                    b.ToTable("TrainSchedules");
                });

            modelBuilder.Entity("TrainMaster.Entities.TrainSchedule", b =>
                {
                    b.HasOne("TrainMaster.Entities.Train", "Train")
                        .WithMany("trainSchedules")
                        .HasForeignKey("TrainNo1");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("TrainMaster.Entities.Train", b =>
                {
                    b.Navigation("trainSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
