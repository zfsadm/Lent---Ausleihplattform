﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lent.Models;

namespace lent.Migrations
{
    [DbContext(typeof(lentContext))]
    [Migration("20180926084301_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lent.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BorrowerForeignkey");

                    b.Property<string>("Category");

                    b.Property<string>("Discription");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerForeignkey");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.HasIndex("BorrowerForeignkey");

                    b.HasIndex("OwnerForeignkey");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("lent.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("lent.Models.Item", b =>
                {
                    b.HasOne("lent.Models.User", "Borrower")
                        .WithMany("borrowedItems")
                        .HasForeignKey("BorrowerForeignkey")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("lent.Models.User", "Owner")
                        .WithMany("ownedItems")
                        .HasForeignKey("OwnerForeignkey")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
