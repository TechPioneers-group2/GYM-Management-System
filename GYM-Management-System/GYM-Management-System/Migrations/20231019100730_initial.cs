﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    GymID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: false),
                    ActiveHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.GymID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTiers",
                columns: table => new
                {
                    SubscriptionTierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionTiers", x => x.SubscriptionTierID);
                });

            migrationBuilder.CreateTable(
                name: "Supplements",
                columns: table => new
                {
                    SupplementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.SupplementID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymEquipments",
                columns: table => new
                {
                    GymEquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutOfService = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEquipments", x => x.GymEquipmentID);
                    table.ForeignKey(
                        name: "FK_GymEquipments_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InGym = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionTierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_SubscriptionTiers_SubscriptionTierID",
                        column: x => x.SubscriptionTierID,
                        principalTable: "SubscriptionTiers",
                        principalColumn: "SubscriptionTierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymSupplements",
                columns: table => new
                {
                    SupplementID = table.Column<int>(type: "int", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSupplements", x => new { x.GymID, x.SupplementID });
                    table.ForeignKey(
                        name: "FK_GymSupplements_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymSupplements_Supplements_SupplementID",
                        column: x => x.SupplementID,
                        principalTable: "Supplements",
                        principalColumn: "SupplementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ad8ba74-fa7a-43eb-a3fa-ffd1e6155ca2", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "6d8708c1-c55f-44bd-871e-2c0576a91daf", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" },
                    { "b0c5ab19-fbf9-4d45-b66a-8497af3f5111", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "c2d646db-165f-48ce-82f9-2ea586bd5bd2", "adminUser@example.com", true, false, null, "ADMINUSER@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEP+eZQWxJc027/3XlB4lw99fzQWv8VITemdl7oEbv7wl+4oz1kAA0J2rNBUQoE7vJg==", "1234567890", false, "eea5b660-6ca2-4f75-b200-ee59669669d8", false, "Admin" },
                    { "2", 0, "9d31efb1-504f-418e-8e7e-9c58900392ac", "employeeUser@example.com", true, false, null, "EMPLOYEEUSER@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEKj9cG1KUiS4Kb5Vm5sOea+kYNPoLdX72Uh6cLTW8lBi35+b/BweRKBhVn+8csyVTQ==", "1234567890", false, "dbb52d48-dd60-4863-adf0-c1430598d840", false, "Employee" },
                    { "3", 0, "bc8726c4-e773-484b-9f25-9799c88f0be6", "ClientUser@example.com", true, false, null, "CLIENTUSER@EXAMPLE.COM", "CLIENT", "AQAAAAIAAYagAAAAEBQd3oTDzpsNJGZECAn+06mE9wh94gA2GZgMP4aZVRZ4ldkBMIjjyzuhWbcmRPzGwQ==", "1234567890", false, "68fd6098-7571-46a9-a694-a0561ef52823", false, "Client" },
                    { "4", 0, "d74764a8-17fe-4a83-8815-b25e066e4c37", "Client2User@example.com", true, false, null, "CLIENT2USER@EXAMPLE.COM", "CLIENT2", "AQAAAAIAAYagAAAAEJSDcEX5BHecGsclN0TgTpdKbpTREazj9a2y6ko96lk7yU892CgkqqwlocM0qKNHUQ==", "1234567890", false, "91e0864c-baf1-4b6c-af03-e3c02308c4b2", false, "Client2" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "GymID", "ActiveHours", "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification", "imageURL" },
                values: new object[,]
                {
                    { 1, "5AM-12PM", "Amman - University Street - Building 25", 1, "125", "WillPower - Amman", "Everything ok", "https://techpioneers.blob.core.windows.net/images/AmmanGym.png" },
                    { 2, "6AM-12PM", "Zarqa - 36th Street - Building 20", 1, "100", "WillPower - Zarqa", "Everything ok", "https://techpioneers.blob.core.windows.net/images/ZarqaGym.png" },
                    { 3, "6AM-12PM", "Irbid - Yarmouk University Street - Building 30", 0, "150", "WillPower - Irbid", "Under maintenance until 9-9-2023 AD", "https://techpioneers.blob.core.windows.net/images/IrbidGym.png" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTiers",
                columns: new[] { "SubscriptionTierID", "Length", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "1 month", "30 JD" },
                    { 2, 3, "3 months", "60 JD" },
                    { 3, 6, "6 months", "110 JD" },
                    { 4, 12, "12 months", "200 JD" }
                });

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "SupplementID", "Description", "Name", "Price", "imageURL" },
                values: new object[,]
                {
                    { 1, "Whey protein is a mixture of proteins isolated from whey, which is the liquid part of milk that separates during cheese production.\r\nMilk actually contains two main types of protein: casein (80%) and whey (20%).", "Whey Protein Powder", 100.0, "https://techpioneers.blob.core.windows.net/images/WheyProteinPowder.png" },
                    { 2, "Creatine is a combination of three different amino acids: glycine, arginine, and methionine.", "Creatine Monohydrate", 90.0, "https://techpioneers.blob.core.windows.net/images/CreatineMonohydrate.png" },
                    { 3, "Branched-Chain Amino Acids (BCAAs) are a group of three essential amino acids: leucine, isoleucine, and valine. They are called branched-chain because they are the only three amino acids to have a chain that branches off to one side.", "Branched-Chain Amino Acids (BCAAs)", 45.0, "https://techpioneers.blob.core.windows.net/images/Branched-ChainAminoAcidsBCAAs.png" },
                    { 4, "A pre-workout blend is a class of powdered drink mixes that are consumed 20-30 minutes prior to the beginning of a rigorous workout to increase exercise performance.", "Pre-Workout Blend", 60.0, "https://techpioneers.blob.core.windows.net/images/Pre-WorkoutBlend.png" },
                    { 5, "BCAA Energy Drink is a powerful blend of Branched-Chain Amino Acids (BCAAs), providing energy and supporting muscle recovery during workouts.", "BCAA Energy Drink", 5.0, "https://techpioneers.blob.core.windows.net/images/BCAAEnergyDrink.png" },
                    { 6, "This Pre-Workout Nitric Oxide Booster is designed to enhance focus, increase energy levels, and improve blood flow for optimal workout performance.", "Pre-Workout Nitric Oxide Booster", 60.0, "https://techpioneers.blob.core.windows.net/images/Pre-WorkoutNitricOxideBooster.png" },
                    { 7, "Glutamine Capsules provide essential amino acids that aid in muscle recovery, immune system support, and reducing muscle soreness after intense workouts.", "Glutamine Capsules", 25.0, "https://techpioneers.blob.core.windows.net/images/GlutamineCapsules.png" },
                    { 8, "Omega-3 Fish Oil supplements are rich in essential fatty acids that support cardiovascular health, joint function, and muscle recovery.", "Omega-3 Fish Oil", 17.0, "https://techpioneers.blob.core.windows.net/images/Omega-3FishOil.png" },
                    { 9, "L-Carnitine Fat Burner helps convert stored body fat into energy, making it an effective supplement for those looking to manage weight and increase endurance.", "L-Carnitine Fat Burner", 17.0, "https://techpioneers.blob.core.windows.net/images/LCarnitineFatBurner.png" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 10, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "createAdmin", "5ad8ba74-fa7a-43eb-a3fa-ffd1e6155ca2" },
                    { 11, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "updateAdmin", "5ad8ba74-fa7a-43eb-a3fa-ffd1e6155ca2" },
                    { 12, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "deleteAdmin", "5ad8ba74-fa7a-43eb-a3fa-ffd1e6155ca2" },
                    { 13, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "readAdmin", "5ad8ba74-fa7a-43eb-a3fa-ffd1e6155ca2" },
                    { 14, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "createEmployee", "6d8708c1-c55f-44bd-871e-2c0576a91daf" },
                    { 15, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "updateEmployee", "6d8708c1-c55f-44bd-871e-2c0576a91daf" },
                    { 16, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "readEmployee", "6d8708c1-c55f-44bd-871e-2c0576a91daf" },
                    { 17, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "updateClient", "b0c5ab19-fbf9-4d45-b66a-8497af3f5111" },
                    { 18, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "readClient", "b0c5ab19-fbf9-4d45-b66a-8497af3f5111" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, "Client", new DateTime(2023, 10, 19, 13, 7, 29, 864, DateTimeKind.Local).AddTicks(1275), new DateTime(2024, 4, 19, 13, 7, 29, 864, DateTimeKind.Local).AddTicks(1288), 1, "3" },
                    { 2, 1, true, "Client2", new DateTime(2023, 10, 19, 13, 7, 29, 864, DateTimeKind.Local).AddTicks(1295), new DateTime(2024, 4, 19, 13, 7, 29, 864, DateTimeKind.Local).AddTicks(1295), 1, "4" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "GymID", "IsAvailable", "JobDescription", "Name", "Salary", "UserId", "WorkingDays", "WorkingHours" },
                values: new object[] { 1, 1, true, "Demo", "Employee", "$300", "2", "S M T W T F S", "9AM - 5PM" });

            migrationBuilder.InsertData(
                table: "GymEquipments",
                columns: new[] { "GymEquipmentID", "GymID", "Name", "OutOfService", "PhotoUrl", "Quantity" },
                values: new object[,]
                {
                    { 2, 1, "bench press", 0, "https://m.media-amazon.com/images/I/61cGWhpz3ZL._AC_UF1000,1000_QL80_.jpg", 2 },
                    { 3, 1, "treadmill", 2, "https://shop.lifefitness.com/cdn/shop/products/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.jpg?v=1678726811", 10 },
                    { 4, 2, "dumbbells", 0, "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit", 60 },
                    { 5, 2, "elliptical machine", 0, "https://www.precorhomefitness.com/cdn/shop/products/precor-efx-635-elliptical_5000x.jpg?v=1686422733", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GymID",
                table: "Clients",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SubscriptionTierID",
                table: "Clients",
                column: "SubscriptionTierID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GymID",
                table: "Employees",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_GymEquipments_GymID",
                table: "GymEquipments",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_GymSupplements_SupplementID",
                table: "GymSupplements",
                column: "SupplementID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "GymEquipments");

            migrationBuilder.DropTable(
                name: "GymSupplements");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubscriptionTiers");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Supplements");
        }
    }
}