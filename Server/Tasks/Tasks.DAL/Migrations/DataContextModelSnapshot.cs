﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasks.DAL.Data;

namespace Tasks.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Tasks.Core.Model.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Tasks.Core.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Tasks.Core.Model.Note", b =>
                {
                    b.HasOne("Tasks.Core.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
