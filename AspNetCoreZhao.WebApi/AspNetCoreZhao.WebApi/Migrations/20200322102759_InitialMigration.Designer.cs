﻿// <auto-generated />
using System;
using AspNetCoreZhao.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreZhao.WebApi.Migrations
{
    [DbContext(typeof(RoutineDataContext))]
    [Migration("20200322102759_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("AspNetCoreZhao.WebApi.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f47e01a-c072-427d-a5a6-27a8ae96380e"),
                            Introduction = "Great Company",
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = new Guid("35ca78f2-d595-4890-93c4-db6d5d258f5c"),
                            Introduction = "No Company",
                            Name = "Google"
                        },
                        new
                        {
                            Id = new Guid("77f97e55-be65-470a-a814-379df619da3e"),
                            Introduction = "TuBaolan Company",
                            Name = "Alibaba"
                        });
                });

            modelBuilder.Entity("AspNetCoreZhao.WebApi.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("gender")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11fc1cdf-47de-43e6-8cce-098da8017ecc"),
                            CompanyId = new Guid("0f47e01a-c072-427d-a5a6-27a8ae96380e"),
                            DateOfBirth = new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNo = "0321",
                            FirstName = "123",
                            LastName = "456",
                            gender = 1
                        },
                        new
                        {
                            Id = new Guid("c3b1ce1e-3dad-4547-aebe-0ffa42e1a303"),
                            CompanyId = new Guid("35ca78f2-d595-4890-93c4-db6d5d258f5c"),
                            DateOfBirth = new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNo = "0321",
                            FirstName = "098",
                            LastName = "124",
                            gender = 1
                        });
                });

            modelBuilder.Entity("AspNetCoreZhao.WebApi.Entities.Employee", b =>
                {
                    b.HasOne("AspNetCoreZhao.WebApi.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}