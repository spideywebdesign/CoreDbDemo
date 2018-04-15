﻿// <auto-generated />
using CoreDbDemo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CoreDbDemo.Data.Migrations
{
    [DbContext(typeof(CoreDbDemoContext))]
    partial class CoreDbDemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreDbDemo.Model.Entity.ArchivedStaffmember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.HasKey("Id");

                    b.ToTable("ArchivedStaffMembers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Access");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<DateTime>("RequestDate");

                    b.Property<DateTime>("RequestProcessedDate");

                    b.Property<int?>("StaffMemberId")
                        .IsRequired();

                    b.Property<int?>("SystemId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.HasIndex("SystemId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.Retailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Address2")
                        .HasMaxLength(200);

                    b.Property<string>("Address3")
                        .HasMaxLength(200);

                    b.Property<string>("County")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Postcode");

                    b.Property<string>("RetailerCode");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Retailers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.StaffMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("RetailerId")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("RetailerId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.System", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.Request", b =>
                {
                    b.HasOne("CoreDbDemo.Model.Entity.StaffMember", "StaffMember")
                        .WithMany("Requests")
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreDbDemo.Model.Entity.System", "System")
                        .WithMany("Requests")
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.StaffMember", b =>
                {
                    b.HasOne("CoreDbDemo.Model.Entity.Retailer", "Retailer")
                        .WithMany("StaffMembers")
                        .HasForeignKey("RetailerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
