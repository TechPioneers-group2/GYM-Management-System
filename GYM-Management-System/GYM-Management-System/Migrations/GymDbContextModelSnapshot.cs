﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gym_management_system_front_end.Models.Data;

#nullable disable

namespace GYM_Management_System.Migrations
{
    [DbContext(typeof(GymDbContext))]
    partial class GymDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "83f60b0a-34f2-4379-8728-8771a5853804",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "74d5be6d-f19f-4be3-bdc1-a591123648ad",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 10,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "createAdmin",
                            RoleId = "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "updateAdmin",
                            RoleId = "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "deleteAdmin",
                            RoleId = "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "readAdmin",
                            RoleId = "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "createEmployee",
                            RoleId = "83f60b0a-34f2-4379-8728-8771a5853804"
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "updateEmployee",
                            RoleId = "83f60b0a-34f2-4379-8728-8771a5853804"
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "readEmployee",
                            RoleId = "83f60b0a-34f2-4379-8728-8771a5853804"
                        },
                        new
                        {
                            Id = 17,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "updateClient",
                            RoleId = "74d5be6d-f19f-4be3-bdc1-a591123648ad"
                        },
                        new
                        {
                            Id = 18,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "readClient",
                            RoleId = "74d5be6d-f19f-4be3-bdc1-a591123648ad"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "acbd167b-fb08-49d6-a2e5-b892422699dd",
                            Email = "adminUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINUSER@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEHo0r+Y/rxZxh6e3tru6vNPc3LGe/bWpB2c2GKtoGbQbLTP+c+s80V/gmyLDOESclA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "66d4b29e-0d96-4e95-a96a-c644df502a22",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "46d64411-e579-4e42-9a34-3453b4f1df1e",
                            Email = "employeeUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEEUSER@EXAMPLE.COM",
                            NormalizedUserName = "EMPLOYEE",
                            PasswordHash = "AQAAAAIAAYagAAAAEKTfh9M0NtbuqyvmItfW0MXrpusIwRsGnIfogh6akDM3blcx3GriK1HiVVrVTeskiA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a19eca7f-0d18-48f0-a7b3-16f44ec99ce6",
                            TwoFactorEnabled = false,
                            UserName = "Employee"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b55c92da-32c0-43c4-bf58-32c46be64e8d",
                            Email = "ClientUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENTUSER@EXAMPLE.COM",
                            NormalizedUserName = "CLIENT",
                            PasswordHash = "AQAAAAIAAYagAAAAEI4pEyMY6pSXbpNBHA3iRcjHsyesGrudL6uUOINFw+8RNR1vsh9hjT3P6M0ltF5zwA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b01e9541-15a8-41bb-9aab-821065fbe8b2",
                            TwoFactorEnabled = false,
                            UserName = "Client"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3c8298d3-2bb8-4942-b227-9e467a4d1520",
                            Email = "Client2User@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT2USER@EXAMPLE.COM",
                            NormalizedUserName = "CLIENT2",
                            PasswordHash = "AQAAAAIAAYagAAAAEBRWtsu30PgIRu4nsMcOqKXX8Ay2CGAYTomXj7xmM7ydQigHjbUQPSRYPi+HzBIZPw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "41c1985d-5ff2-4592-a9bb-badd0f03d174",
                            TwoFactorEnabled = false,
                            UserName = "Client2"
                        });
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<int>("GymID")
                        .HasColumnType("int");

                    b.Property<bool>("InGym")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubscriptionExpiry")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionTierID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.HasIndex("GymID");

                    b.HasIndex("SubscriptionTierID");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientID = 1,
                            GymID = 1,
                            InGym = true,
                            Name = "Client",
                            SubscriptionDate = new DateTime(2023, 10, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4735),
                            SubscriptionExpiry = new DateTime(2024, 4, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4755),
                            SubscriptionTierID = 1,
                            UserId = "3"
                        },
                        new
                        {
                            ClientID = 2,
                            GymID = 1,
                            InGym = true,
                            Name = "Client2",
                            SubscriptionDate = new DateTime(2023, 10, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4767),
                            SubscriptionExpiry = new DateTime(2024, 4, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4768),
                            SubscriptionTierID = 1,
                            UserId = "4"
                        });
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<int>("GymID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("GymID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            GymID = 1,
                            IsAvailable = true,
                            JobDescription = "Demo",
                            Name = "Employee",
                            Salary = "$300",
                            UserId = "2",
                            WorkingDays = "S M T W T F S",
                            WorkingHours = "9AM - 5PM"
                        });
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Gym", b =>
                {
                    b.Property<int>("GymID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GymID"));

                    b.Property<string>("ActiveHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentCapacity")
                        .HasColumnType("int");

                    b.Property<string>("MaxCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GymID");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            GymID = 1,
                            ActiveHours = "5AM-12PM",
                            Address = "Amman - University Street - Building 25",
                            CurrentCapacity = 1,
                            MaxCapacity = "125",
                            Name = "WillPower - Amman",
                            Notification = "Everything ok"
                        },
                        new
                        {
                            GymID = 2,
                            ActiveHours = "6AM-12PM",
                            Address = "Zarqa - 36th Street - Building 20",
                            CurrentCapacity = 1,
                            MaxCapacity = "100",
                            Name = "WillPower - Zarqa",
                            Notification = "Everything ok"
                        },
                        new
                        {
                            GymID = 3,
                            ActiveHours = "6AM-12PM",
                            Address = "Irbid - Yarmouk University Street - Building 30",
                            CurrentCapacity = 0,
                            MaxCapacity = "150",
                            Name = "WillPower - Irbid",
                            Notification = "Under maintenance until 9-9-2023 AD"
                        });
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.GymEquipment", b =>
                {
                    b.Property<int>("GymEquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GymEquipmentID"));

                    b.Property<int>("GymID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutOfService")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("GymEquipmentID");

                    b.HasIndex("GymID");

                    b.ToTable("GymEquipments");

                    b.HasData(
                        new
                        {
                            GymEquipmentID = 2,
                            GymID = 1,
                            Name = "bench press",
                            OutOfService = 0,
                            Quantity = 2
                        },
                        new
                        {
                            GymEquipmentID = 3,
                            GymID = 1,
                            Name = "treadmill",
                            OutOfService = 2,
                            Quantity = 10
                        },
                        new
                        {
                            GymEquipmentID = 4,
                            GymID = 2,
                            Name = "dumbbells",
                            OutOfService = 0,
                            Quantity = 60
                        },
                        new
                        {
                            GymEquipmentID = 5,
                            GymID = 2,
                            Name = "elliptical machine",
                            OutOfService = 0,
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.GymSupplement", b =>
                {
                    b.Property<int>("GymID")
                        .HasColumnType("int");

                    b.Property<int>("SupplementID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("GymID", "SupplementID");

                    b.HasIndex("SupplementID");

                    b.ToTable("GymSupplements");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.SubscriptionTier", b =>
                {
                    b.Property<int>("SubscriptionTierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionTierID"));

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionTierID");

                    b.ToTable("SubscriptionTiers");

                    b.HasData(
                        new
                        {
                            SubscriptionTierID = 1,
                            Length = 1,
                            Name = "1 month",
                            Price = "30 JD"
                        },
                        new
                        {
                            SubscriptionTierID = 2,
                            Length = 3,
                            Name = "3 months",
                            Price = "60 JD"
                        },
                        new
                        {
                            SubscriptionTierID = 3,
                            Length = 6,
                            Name = "6 months",
                            Price = "110 JD"
                        },
                        new
                        {
                            SubscriptionTierID = 4,
                            Length = 12,
                            Name = "12 months",
                            Price = "200 JD"
                        });
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Supplement", b =>
                {
                    b.Property<int>("SupplementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplementID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplementID");

                    b.ToTable("Supplements");

                    b.HasData(
                        new
                        {
                            SupplementID = 1,
                            Description = "Whey protein is a mixture of proteins isolated from whey, which is the liquid part of milk that separates during cheese production.\r\nMilk actually contains two main types of protein: casein (80%) and whey (20%).",
                            Name = "Whey Protein Powder",
                            Price = "80 JD"
                        },
                        new
                        {
                            SupplementID = 2,
                            Description = "Creatine is a combination of three different amino acids: glycine, arginine, and methionine.",
                            Name = "Creatine Monohydrate",
                            Price = "40 JD"
                        },
                        new
                        {
                            SupplementID = 3,
                            Description = "Branched-Chain Amino Acids (BCAAs) are a group of three essential amino acids: leucine, isoleucine, and valine. They are called branched-chain because they are the only three amino acids to have a chain that branches off to one side.",
                            Name = "Branched-Chain Amino Acids (BCAAs)",
                            Price = "30 JD"
                        },
                        new
                        {
                            SupplementID = 4,
                            Description = "A pre-workout blend is a class of powdered drink mixes that are consumed 20-30 minutes prior to the beginning of a rigorous workout to increase exercise performance.",
                            Name = "Pre-Workout Blend",
                            Price = "50 JD"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gym_management_system_front_end.Models.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Client", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.Gym", "Gym")
                        .WithMany("Clients")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gym_management_system_front_end.Models.Models.SubscriptionTier", "SubscriptionTierOBJ")
                        .WithMany("Clients")
                        .HasForeignKey("SubscriptionTierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("SubscriptionTierOBJ");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Employee", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.Gym", "Gym")
                        .WithMany("Employees")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.GymEquipment", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.Gym", "Gym")
                        .WithMany("GymEquipments")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.GymSupplement", b =>
                {
                    b.HasOne("gym_management_system_front_end.Models.Models.Gym", "Gym")
                        .WithMany("GymSupplements")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gym_management_system_front_end.Models.Models.Supplement", "Supplements")
                        .WithMany("GymSupplements")
                        .HasForeignKey("SupplementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Gym", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Employees");

                    b.Navigation("GymEquipments");

                    b.Navigation("GymSupplements");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.SubscriptionTier", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("gym_management_system_front_end.Models.Models.Supplement", b =>
                {
                    b.Navigation("GymSupplements");
                });
#pragma warning restore 612, 618
        }
    }
}
