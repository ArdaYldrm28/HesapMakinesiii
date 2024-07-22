﻿// <auto-generated />
using System;
using HesapMakinesiii.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HesapMakinesiii.Migrations
{
    [DbContext(typeof(CalculatorDbContext))]
    partial class CalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("HesapMakinesiii.Data.Calculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Result")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Calculations");
                });
#pragma warning restore 612, 618
        }
    }
}
