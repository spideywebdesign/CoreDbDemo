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

            modelBuilder.Entity("CoreDbDemo.Model.Entity.ArchivedStaffmemberDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.HasKey("Id");

                    b.ToTable("ArchivedStaffMembers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.AreaManagerDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Surname");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("AreaManagers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.BrandDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.ExternalSystemDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExternalSystems");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.RequestDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Access");

                    b.Property<DateTime>("Created");

                    b.Property<int>("ExternalSystemId");

                    b.Property<DateTime?>("Modified");

                    b.Property<DateTime>("RequestDate");

                    b.Property<DateTime?>("RequestProcessedDate");

                    b.Property<int>("StaffMemberId");

                    b.HasKey("Id");

                    b.HasIndex("ExternalSystemId");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.RetailerDbo", b =>
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

                    b.Property<int?>("AreaManagerId");

                    b.Property<int?>("BrandId");

                    b.Property<string>("County")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Postcode");

                    b.Property<string>("RetailerCode");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AreaManagerId");

                    b.HasIndex("BrandId");

                    b.ToTable("Retailers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.StaffMemberDbo", b =>
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

                    b.Property<DateTime?>("Modified");

                    b.Property<int>("RetailerId");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("RetailerId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.RequestDbo", b =>
                {
                    b.HasOne("CoreDbDemo.Model.Entity.ExternalSystemDbo", "ExternalSystem")
                        .WithMany("Requests")
                        .HasForeignKey("ExternalSystemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CoreDbDemo.Model.Entity.StaffMemberDbo", "StaffMember")
                        .WithMany("Requests")
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.RetailerDbo", b =>
                {
                    b.HasOne("CoreDbDemo.Model.Entity.AreaManagerDbo", "AreaManager")
                        .WithMany("Retailers")
                        .HasForeignKey("AreaManagerId");

                    b.HasOne("CoreDbDemo.Model.Entity.BrandDbo", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("CoreDbDemo.Model.Entity.StaffMemberDbo", b =>
                {
                    b.HasOne("CoreDbDemo.Model.Entity.RetailerDbo", "Retailer")
                        .WithMany("StaffMembers")
                        .HasForeignKey("RetailerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
