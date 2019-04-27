﻿// <auto-generated />
using System;
using CafeApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CafeApp.Migrations
{
    [DbContext(typeof(CafeContext))]
    [Migration("20190421004535_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CafeApp.Account", b =>
                {
                    b.Property<int>("MembershipNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("MemberSince");

                    b.Property<int>("PaymentMethod");

                    b.HasKey("MembershipNumber")
                        .HasName("PK_Accounts");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CafeApp.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description");

                    b.Property<int>("MembershipNumber");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TransactionType");

                    b.HasKey("TransactionId")
                        .HasName("PK_Transactions");

                    b.HasIndex("MembershipNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CafeApp.Transaction", b =>
                {
                    b.HasOne("CafeApp.Account", "Account")
                        .WithMany()
                        .HasForeignKey("MembershipNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
