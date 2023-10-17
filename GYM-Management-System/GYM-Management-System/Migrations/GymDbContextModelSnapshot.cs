﻿// <auto-generated />
using System;
using GYM_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            modelBuilder.Entity("GYM_Management_System.Models.ApplicationUser", b =>
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
                            ConcurrencyStamp = "8516e032-c0f2-4685-bcbb-ba3d72533fef",
                            Email = "adminUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINUSER@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEJmzu7+JsS/tQjO3a7jDlOjzup0eeiVu5Bx1Oaq9St3NTmMiSSB+1Urqe9L9fcaC/g==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "82d1480a-e6d4-437c-ae51-ec2d971f9581",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fcb10b71-f250-48e5-accc-cc265ef2277a",
                            Email = "employeeUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEEUSER@EXAMPLE.COM",
                            NormalizedUserName = "EMPLOYEE",
                            PasswordHash = "AQAAAAIAAYagAAAAEHsUK2bQaW3aDbylLRQuAleQcwRXr/viZ3MYsHLxCWV0V13eNhvoiQYm9Igb8ClZhw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "239ab76e-4580-4dc8-bb1e-cd25250aedc9",
                            TwoFactorEnabled = false,
                            UserName = "Employee"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "873859e5-6e71-4871-bbd5-e12f7db4fd9e",
                            Email = "ClientUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENTUSER@EXAMPLE.COM",
                            NormalizedUserName = "CLIENT",
                            PasswordHash = "AQAAAAIAAYagAAAAEKWJ9AAaO14RCycBg+VB/07/Y122K2jVKkzMBOBygzhxkPu0R/LW2+qLmG9TmNL6Jg==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "17536a36-6f69-4c78-8d6e-dbe6fe1eeb0e",
                            TwoFactorEnabled = false,
                            UserName = "Client"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6a02f881-c8f0-425c-ae8c-6a5b19e479d3",
                            Email = "Client2User@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT2USER@EXAMPLE.COM",
                            NormalizedUserName = "CLIENT2",
                            PasswordHash = "AQAAAAIAAYagAAAAEBGqw9sngCwb+u95rik51AWFFLIWB9TZh5XYeqGbwboi9JM/xDj8iJgDCrBrzfjVqA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45c83d57-35f6-4b0e-9069-03d14c6a65aa",
                            TwoFactorEnabled = false,
                            UserName = "Client2"
                        });
                });

            modelBuilder.Entity("GYM_Management_System.Models.Client", b =>
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
                            SubscriptionDate = new DateTime(2023, 10, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3718),
                            SubscriptionExpiry = new DateTime(2024, 4, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3738),
                            SubscriptionTierID = 1,
                            UserId = "3"
                        },
                        new
                        {
                            ClientID = 2,
                            GymID = 1,
                            InGym = true,
                            Name = "Client2",
                            SubscriptionDate = new DateTime(2023, 10, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3747),
                            SubscriptionExpiry = new DateTime(2024, 4, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3748),
                            SubscriptionTierID = 1,
                            UserId = "4"
                        });
                });

            modelBuilder.Entity("GYM_Management_System.Models.Employee", b =>
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

            modelBuilder.Entity("GYM_Management_System.Models.Gym", b =>
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

            modelBuilder.Entity("GYM_Management_System.Models.GymEquipment", b =>
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

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            PhotoUrl = "https://m.media-amazon.com/images/I/61cGWhpz3ZL._AC_UF1000,1000_QL80_.jpg",
                            Quantity = 2
                        },
                        new
                        {
                            GymEquipmentID = 3,
                            GymID = 1,
                            Name = "treadmill",
                            OutOfService = 2,
                            PhotoUrl = "https://shop.lifefitness.com/cdn/shop/products/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.jpg?v=1678726811",
                            Quantity = 10
                        },
                        new
                        {
                            GymEquipmentID = 4,
                            GymID = 2,
                            Name = "dumbbells",
                            OutOfService = 0,
                            PhotoUrl = "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit",
                            Quantity = 60
                        },
                        new
                        {
                            GymEquipmentID = 5,
                            GymID = 2,
                            Name = "elliptical machine",
                            OutOfService = 0,
                            PhotoUrl = "https://www.precorhomefitness.com/cdn/shop/products/precor-efx-635-elliptical_5000x.jpg?v=1686422733",
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("GYM_Management_System.Models.GymSupplement", b =>
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

            modelBuilder.Entity("GYM_Management_System.Models.SubscriptionTier", b =>
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

            modelBuilder.Entity("GYM_Management_System.Models.Supplement", b =>
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
                            Id = "2d865ed7-99c4-4747-be7b-ef0b44a00459",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "c1872983-0667-47ac-ac7e-f3754c7e8a01",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "e1ddbe4f-ca50-4928-be1b-176a046a12b6",
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
                            RoleId = "2d865ed7-99c4-4747-be7b-ef0b44a00459"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "updateAdmin",
                            RoleId = "2d865ed7-99c4-4747-be7b-ef0b44a00459"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "deleteAdmin",
                            RoleId = "2d865ed7-99c4-4747-be7b-ef0b44a00459"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "readAdmin",
                            RoleId = "2d865ed7-99c4-4747-be7b-ef0b44a00459"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "createEmployee",
                            RoleId = "c1872983-0667-47ac-ac7e-f3754c7e8a01"
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "updateEmployee",
                            RoleId = "c1872983-0667-47ac-ac7e-f3754c7e8a01"
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "readEmployee",
                            RoleId = "c1872983-0667-47ac-ac7e-f3754c7e8a01"
                        },
                        new
                        {
                            Id = 17,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "updateClient",
                            RoleId = "e1ddbe4f-ca50-4928-be1b-176a046a12b6"
                        },
                        new
                        {
                            Id = 18,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "readClient",
                            RoleId = "e1ddbe4f-ca50-4928-be1b-176a046a12b6"
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

            modelBuilder.Entity("GYM_Management_System.Models.Client", b =>
                {
                    b.HasOne("GYM_Management_System.Models.Gym", "Gym")
                        .WithMany("Clients")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GYM_Management_System.Models.SubscriptionTier", "SubscriptionTierOBJ")
                        .WithMany("Clients")
                        .HasForeignKey("SubscriptionTierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("SubscriptionTierOBJ");
                });

            modelBuilder.Entity("GYM_Management_System.Models.Employee", b =>
                {
                    b.HasOne("GYM_Management_System.Models.Gym", "Gym")
                        .WithMany("Employees")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("GYM_Management_System.Models.GymEquipment", b =>
                {
                    b.HasOne("GYM_Management_System.Models.Gym", "Gym")
                        .WithMany("GymEquipments")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("GYM_Management_System.Models.GymSupplement", b =>
                {
                    b.HasOne("GYM_Management_System.Models.Gym", "Gym")
                        .WithMany("GymSupplements")
                        .HasForeignKey("GymID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GYM_Management_System.Models.Supplement", "Supplements")
                        .WithMany("GymSupplements")
                        .HasForeignKey("SupplementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("Supplements");
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
                    b.HasOne("GYM_Management_System.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GYM_Management_System.Models.ApplicationUser", null)
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

                    b.HasOne("GYM_Management_System.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GYM_Management_System.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GYM_Management_System.Models.Gym", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Employees");

                    b.Navigation("GymEquipments");

                    b.Navigation("GymSupplements");
                });

            modelBuilder.Entity("GYM_Management_System.Models.SubscriptionTier", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("GYM_Management_System.Models.Supplement", b =>
                {
                    b.Navigation("GymSupplements");
                });
#pragma warning restore 612, 618
        }
    }
}
