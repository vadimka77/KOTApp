using System;
using KOTApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Drawing2D;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOTApp.Data.Migrations
{
    public partial class AppModelv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });



            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.NoAction);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.NoAction);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.NoAction);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.NoAction);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.NoAction);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.NoAction);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateTable(
               name: "CompanyOwners",
               columns: table => new
               {
                   CompanyOwnerId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_CompanyOwners", x => x.CompanyOwnerId);
               });

            migrationBuilder.CreateTable(
                name: "PayTimeFrames",
                columns: table => new
                {
                    PayTFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TFDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TFPayFrequency = table.Column<int>(type: "int", nullable: false),
                    TFStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TFEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTimeFrames", x => x.PayTFId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyOwnerId = table.Column<int>(type: "int", nullable: false),
                    CompanyOwnerPercent = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentFrequency = table.Column<int>(type: "int", nullable: false),
                    CurrentTFStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentTFEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentTFPayTFId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyOwners_CompanyOwnerId",
                        column: x => x.CompanyOwnerId,
                        principalTable: "CompanyOwners",
                        principalColumn: "CompanyOwnerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Companies_PayTimeFrames_CurrentTFPayTFId",
                        column: x => x.CurrentTFPayTFId,
                        principalTable: "PayTimeFrames",
                        principalColumn: "PayTFId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrawAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EmpCommPercent = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    AdvancePercent = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdvancePercent = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    COTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NETSale = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrossProfit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyOwnerAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CompanyOwnerPercent = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmpCommAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EmpCommPercent = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EmpBalanceAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayRates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PayTFId = table.Column<int>(type: "int", nullable: false),
                    TFCommPercent = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayRates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeePayRates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeePayRates_PayTimeFrames_PayTFId",
                        column: x => x.PayTFId,
                        principalTable: "PayTimeFrames",
                        principalColumn: "PayTFId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChangeOrders",
                columns: table => new
                {
                    ChangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeOrders", x => x.ChangeId);
                    table.ForeignKey(
                        name: "FK_ChangeOrders_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TxEntries",
                columns: table => new
                {
                    TxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TxType = table.Column<int>(type: "int", nullable: false),
                    TxDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TxEntries", x => x.TxId);
                    table.ForeignKey(
                        name: "FK_TxEntries_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_TxEntries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_ChangeOrders_ContractId",
                table: "ChangeOrders",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyOwnerId",
                table: "Companies",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CurrentTFPayTFId",
                table: "Companies",
                column: "CurrentTFPayTFId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayRates_EmployeeId",
                table: "EmployeePayRates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayRates_PayTFId",
                table: "EmployeePayRates",
                column: "PayTFId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TxEntries_ContractId",
                table: "TxEntries",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TxEntries_EmployeeId",
                table: "TxEntries",
                column: "EmployeeId");

            //migrationBuilder.InsertData
            //insert seed data via sql
            /* migrationBuilder.Sql(
             @"
 SET IDENTITY_INSERT [dbo].[PayTimeFrames] ON 
 INSERT [dbo].[PayTimeFrames] ([PayTFId], [TFPayFrequency], [TFDisplayName], [TFStart], [TFEnd]) VALUES (1, 1, N'2022-TF1-week_1_2', N'01/01/2022', N'01/15/2022')
 INSERT [dbo].[PayTimeFrames] ([PayTFId], [TFPayFrequency], [TFDisplayName], [TFStart], [TFEnd]) VALUES (2, 2, N'2022-TF1-month1', N'01/01/2022', N'01/30/2022')
 SET IDENTITY_INSERT [dbo].[PayTimeFrames] OFF
 GO

 SET IDENTITY_INSERT [dbo].[CompanyOwners] ON 

 INSERT [dbo].[CompanyOwners] ([CompanyOwnerId], [OwnerName], [OwnerPhone], [Email], [Password]) VALUES (1, N'MAXIM BOSS', N'555-555-1234', N'max@cars.com', N'test')
 INSERT [dbo].[CompanyOwners] ([CompanyOwnerId], [OwnerName], [OwnerPhone], [Email], [Password]) VALUES (2, N'Peter2', N'111', N'xxx@xs.com', N'test2')
 SET IDENTITY_INSERT [dbo].[CompanyOwners] OFF
 GO

 SET IDENTITY_INSERT [dbo].[Companies] ON 

 INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyAddress], [PaymentFrequency], [CurrentTFStart], [CurrentTFEnd], [CurrentTFPayTFId],[CompanyOwnerId], [CompanyOwnerPercent]) VALUES (1, N'BMW-Cars', N'Moscow City', 1, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-15T00:00:00.0000000' AS DateTime2),1, 1, 10.00)
 INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyAddress], [PaymentFrequency], [CurrentTFStart], [CurrentTFEnd], [CurrentTFPayTFId],[CompanyOwnerId], [CompanyOwnerPercent]) VALUES (2, N'Lexus Dealer', N'addr1', 1, CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-15T00:00:00.0000000' AS DateTime2),2, 1, 5.00)
 INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyAddress], [PaymentFrequency], [CurrentTFStart], [CurrentTFEnd], [CurrentTFPayTFId],[CompanyOwnerId], [CompanyOwnerPercent]) VALUES (3, N'AliExpress', N'china', 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-02-01T00:00:00.0000000' AS DateTime2),2, 2, 0.00 )
 SET IDENTITY_INSERT [dbo].[Companies] OFF
 GO
 SET IDENTITY_INSERT [dbo].[Employees] ON 

 INSERT [dbo].[Employees] ([EmployeeId], [CompanyId], [HiredDate], [TermDate], [DrawAmount], [EmpCommPercent],[AdvancePercent], [FirstName], [LastName]) VALUES (1, 1, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL,100, 20.0000, 5.0, N'BMW', N'emp1')
 INSERT [dbo].[Employees] ([EmployeeId], [CompanyId], [HiredDate], [TermDate], [DrawAmount], [EmpCommPercent],[AdvancePercent], [FirstName], [LastName]) VALUES (2, 2, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL,50, 0.0000, 3.0, N'lex-first', N'lex-last')
 INSERT [dbo].[Employees] ([EmployeeId], [CompanyId], [HiredDate], [TermDate], [DrawAmount], [EmpCommPercent],[AdvancePercent], [FirstName], [LastName]) VALUES (3, 1, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL,100, 15.0000, 5.0, N'BMW', N'emp2')
 INSERT [dbo].[Employees] ([EmployeeId], [CompanyId], [HiredDate], [TermDate], [DrawAmount], [EmpCommPercent],[AdvancePercent], [FirstName], [LastName]) VALUES (4, 3, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL,10, 0.0000, 1.0, N'ali-e', N'chen')

 SET IDENTITY_INSERT [dbo].[Employees] OFF
 GO
 SET IDENTITY_INSERT [dbo].[Contracts] ON 

 INSERT [dbo].[Contracts] ([ContractId], [CompanyId], [StartDate], [ContractAmount], [ContractName], [EmployeeId], [CompanyOwnerPercent], [CompanyOwnerAmount], [AdvanceAmount], [AdvancePercent], [COTotal], [CloseDate], [CompletionCertificate], [Cost], [EmpBalanceAmount], [EmpCommAmount], [EmpCommPercent], [GrossProfit], [NETSale]) 
                   VALUES (1, 1, CAST(N'2022-01-10T00:00:00.0000000' AS DateTime2), 2000.0000, N'BMW-Sale1', 1, CAST(10.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, N'-', CAST(1000.00 AS Decimal(18, 2)), CAST(-15.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)))
 SET IDENTITY_INSERT [dbo].[Contracts] OFF
 GO

 SET IDENTITY_INSERT [dbo].[TxEntries] ON 
 INSERT [dbo].[TxEntries] ([TxId], [EmployeeId], [TxDate], [TxAmount], [TxType], [Descr], [ContractId], [CompanyId]) VALUES (1, 1, CAST(N'2022-01-10T00:00:00.0000000' AS DateTime2), 60.0000, 3, N'3.00 Advance', 1, 1)
 SET IDENTITY_INSERT [dbo].[TxEntries] OFF
 GO
             ");
            */

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChangeOrders");

            migrationBuilder.DropTable(
                name: "EmployeePayRates");

            migrationBuilder.DropTable(
                name: "TxEntries");

            

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyOwners");

            migrationBuilder.DropTable(
                name: "PayTimeFrames");
        }
    }
}
