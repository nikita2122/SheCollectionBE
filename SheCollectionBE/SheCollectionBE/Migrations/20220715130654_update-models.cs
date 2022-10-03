using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    BookingStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.BookingStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    ColourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColourName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.ColourId);
                });

            migrationBuilder.CreateTable(
                name: "DateTables",
                columns: table => new
                {
                    DateTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTables", x => x.DateTableId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.NotificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatuses",
                columns: table => new
                {
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatuses", x => x.PaymentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PromotionalItems",
                columns: table => new
                {
                    PromotionalItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionalItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromotionalItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromotionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionalItems", x => x.PromotionalItemId);
                });

            migrationBuilder.CreateTable(
                name: "SalesStatuses",
                columns: table => new
                {
                    SalesStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesStatuses", x => x.SalesStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.ServiceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "StockTakes",
                columns: table => new
                {
                    StockTakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockTakeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTakes", x => x.StockTakeId);
                });

            migrationBuilder.CreateTable(
                name: "Timeslots",
                columns: table => new
                {
                    TimeslotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslots", x => x.TimeslotId);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_DateTables_DateId",
                        column: x => x.DateId,
                        principalTable: "DateTables",
                        principalColumn: "DateTableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                    table.ForeignKey(
                        name: "FK_ProductTypes_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "PromotionalItemDiscounts",
                columns: table => new
                {
                    PromotionalItemDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    PromotionalItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionalItemDiscounts", x => x.PromotionalItemDiscountId);
                    table.ForeignKey(
                        name: "FK_PromotionalItemDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId");
                    table.ForeignKey(
                        name: "FK_PromotionalItemDiscounts_PromotionalItems_PromotionalItemId",
                        column: x => x.PromotionalItemId,
                        principalTable: "PromotionalItems",
                        principalColumn: "PromotionalItemId");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_SalesStatuses_SalesStatusId",
                        column: x => x.SalesStatusId,
                        principalTable: "SalesStatuses",
                        principalColumn: "SalesStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                    table.ForeignKey(
                        name: "FK_ServiceTypes_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "ServiceCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTables",
                columns: table => new
                {
                    UserTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTables", x => x.UserTableId);
                    table.ForeignKey(
                        name: "FK_UserTables_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTimeslots",
                columns: table => new
                {
                    ScheduleTimeslotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    TimeslotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTimeslots", x => x.ScheduleTimeslotId);
                    table.ForeignKey(
                        name: "FK_ScheduleTimeslots_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleTimeslots_Timeslots_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "Timeslots",
                        principalColumn: "TimeslotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    ProductPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerTables",
                columns: table => new
                {
                    CustomerTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    UserTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTables", x => x.CustomerTableId);
                    table.ForeignKey(
                        name: "FK_CustomerTables_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "TitleId");
                    table.ForeignKey(
                        name: "FK_CustomerTables_UserTables_UserTableId",
                        column: x => x.UserTableId,
                        principalTable: "UserTables",
                        principalColumn: "UserTableId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeId");
                    table.ForeignKey(
                        name: "FK_Employees_UserTables_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTables",
                        principalColumn: "UserTableId");
                });

            migrationBuilder.CreateTable(
                name: "NotificationTables",
                columns: table => new
                {
                    NotificationTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: true),
                    UserTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTables", x => x.NotificationTableId);
                    table.ForeignKey(
                        name: "FK_NotificationTables_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "NotificationTypeId");
                    table.ForeignKey(
                        name: "FK_NotificationTables_UserTables_UserTableId",
                        column: x => x.UserTableId,
                        principalTable: "UserTables",
                        principalColumn: "UserTableId");
                });

            migrationBuilder.CreateTable(
                name: "CartLines",
                columns: table => new
                {
                    CartLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartQuantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLines", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_CartLines_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductColours",
                columns: table => new
                {
                    ProductColourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColourId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColours", x => x.ProductColourId);
                    table.ForeignKey(
                        name: "FK_ProductColours_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "ColourId");
                    table.ForeignKey(
                        name: "FK_ProductColours_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductPromotionalItemDiscounts",
                columns: table => new
                {
                    ProductPromotionalItemDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PromotionalItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromotionalItemDiscounts", x => x.ProductPromotionalItemDiscountId);
                    table.ForeignKey(
                        name: "FK_ProductPromotionalItemDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId");
                    table.ForeignKey(
                        name: "FK_ProductPromotionalItemDiscounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductPromotionalItemDiscounts_PromotionalItems_PromotionalItemId",
                        column: x => x.PromotionalItemId,
                        principalTable: "PromotionalItems",
                        principalColumn: "PromotionalItemId");
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.ProductSizeId);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId");
                });

            migrationBuilder.CreateTable(
                name: "QuantityOnHands",
                columns: table => new
                {
                    QuantityOnHandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    StockTakeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityOnHands", x => x.QuantityOnHandId);
                    table.ForeignKey(
                        name: "FK_QuantityOnHands_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_QuantityOnHands_StockTakes_StockTakeId",
                        column: x => x.StockTakeId,
                        principalTable: "StockTakes",
                        principalColumn: "StockTakeId");
                });

            migrationBuilder.CreateTable(
                name: "SalesLines",
                columns: table => new
                {
                    SalesLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SalesSaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLines", x => x.SalesLineId);
                    table.ForeignKey(
                        name: "FK_SalesLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesLines_Sales_SalesSaleId",
                        column: x => x.SalesSaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTables",
                columns: table => new
                {
                    OrderTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOrderQuantity = table.Column<int>(type: "int", nullable: false),
                    CustomerTableId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTables", x => x.OrderTableId);
                    table.ForeignKey(
                        name: "FK_OrderTables_CustomerTables_CustomerTableId",
                        column: x => x.CustomerTableId,
                        principalTable: "CustomerTables",
                        principalColumn: "CustomerTableId");
                    table.ForeignKey(
                        name: "FK_OrderTables_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    TimeslotId = table.Column<int>(type: "int", nullable: true),
                    BookingStatusId = table.Column<int>(type: "int", nullable: true),
                    BookingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingStatuses_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatuses",
                        principalColumn: "BookingStatusId");
                    table.ForeignKey(
                        name: "FK_Bookings_CustomerTables_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTables",
                        principalColumn: "CustomerTableId");
                    table.ForeignKey(
                        name: "FK_Bookings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Bookings_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId");
                    table.ForeignKey(
                        name: "FK_Bookings_Timeslots_TimeslotId",
                        column: x => x.TimeslotId,
                        principalTable: "Timeslots",
                        principalColumn: "TimeslotId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSchedules",
                columns: table => new
                {
                    EmployeeScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSchedules", x => x.EmployeeScheduleId);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.OrderLineId);
                    table.ForeignKey(
                        name: "FK_OrderLines_OrderTables_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTables",
                        principalColumn: "OrderTableId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    SalesId = table.Column<int>(type: "int", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_Payments_OrderTables_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTables",
                        principalColumn: "OrderTableId");
                    table.ForeignKey(
                        name: "FK_Payments_PaymentStatuses_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatuses",
                        principalColumn: "PaymentStatusId");
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId");
                    table.ForeignKey(
                        name: "FK_Payments_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "SaleId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTables",
                columns: table => new
                {
                    ServiceTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTables", x => x.ServiceTableId);
                    table.ForeignKey(
                        name: "FK_ServiceTables_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTables_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePromotionalItemDiscounts",
                columns: table => new
                {
                    ServicePromotionalItemDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    PromotionalItemId = table.Column<int>(type: "int", nullable: false),
                    ServiceTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePromotionalItemDiscounts", x => x.ServicePromotionalItemDiscountId);
                    table.ForeignKey(
                        name: "FK_ServicePromotionalItemDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePromotionalItemDiscounts_PromotionalItems_PromotionalItemId",
                        column: x => x.PromotionalItemId,
                        principalTable: "PromotionalItems",
                        principalColumn: "PromotionalItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePromotionalItemDiscounts_ServiceTables_ServiceTableId",
                        column: x => x.ServiceTableId,
                        principalTable: "ServiceTables",
                        principalColumn: "ServiceTableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EmployeeId",
                table: "Bookings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ScheduleId",
                table: "Bookings",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeslotId",
                table: "Bookings",
                column: "TimeslotId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_CartId",
                table: "CartLines",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_ProductId",
                table: "CartLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTables_TitleId",
                table: "CustomerTables",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTables_UserTableId",
                table: "CustomerTables",
                column: "UserTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_ScheduleId",
                table: "EmployeeSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTables_NotificationTypeId",
                table: "NotificationTables",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTables_UserTableId",
                table: "NotificationTables",
                column: "UserTableId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTables_CustomerTableId",
                table: "OrderTables",
                column: "CustomerTableId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTables_OrderStatusId",
                table: "OrderTables",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStatusId",
                table: "Payments",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SalesId",
                table: "Payments",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColours_ColourId",
                table: "ProductColours",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColours_ProductId",
                table: "ProductColours",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotionalItemDiscounts_DiscountId",
                table: "ProductPromotionalItemDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotionalItemDiscounts_ProductId",
                table: "ProductPromotionalItemDiscounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotionalItemDiscounts_PromotionalItemId",
                table: "ProductPromotionalItemDiscounts",
                column: "PromotionalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeId",
                table: "ProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ProductCategoryId",
                table: "ProductTypes",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionalItemDiscounts_DiscountId",
                table: "PromotionalItemDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionalItemDiscounts_PromotionalItemId",
                table: "PromotionalItemDiscounts",
                column: "PromotionalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityOnHands_ProductId",
                table: "QuantityOnHands",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityOnHands_StockTakeId",
                table: "QuantityOnHands",
                column: "StockTakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesStatusId",
                table: "Sales",
                column: "SalesStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLines_ProductId",
                table: "SalesLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesLines_SalesSaleId",
                table: "SalesLines",
                column: "SalesSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DateId",
                table: "Schedules",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimeslots_ScheduleId",
                table: "ScheduleTimeslots",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTimeslots_TimeslotId",
                table: "ScheduleTimeslots",
                column: "TimeslotId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePromotionalItemDiscounts_DiscountId",
                table: "ServicePromotionalItemDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePromotionalItemDiscounts_PromotionalItemId",
                table: "ServicePromotionalItemDiscounts",
                column: "PromotionalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePromotionalItemDiscounts_ServiceTableId",
                table: "ServicePromotionalItemDiscounts",
                column: "ServiceTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTables_BookingId",
                table: "ServiceTables",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTables_ServiceTypeId",
                table: "ServiceTables",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ServiceCategoryId",
                table: "ServiceTypes",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_UserRoleId",
                table: "UserTables",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLines");

            migrationBuilder.DropTable(
                name: "EmployeeSchedules");

            migrationBuilder.DropTable(
                name: "NotificationTables");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductColours");

            migrationBuilder.DropTable(
                name: "ProductPromotionalItemDiscounts");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "PromotionalItemDiscounts");

            migrationBuilder.DropTable(
                name: "QuantityOnHands");

            migrationBuilder.DropTable(
                name: "SalesLines");

            migrationBuilder.DropTable(
                name: "ScheduleTimeslots");

            migrationBuilder.DropTable(
                name: "ServicePromotionalItemDiscounts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "OrderTables");

            migrationBuilder.DropTable(
                name: "PaymentStatuses");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "StockTakes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "PromotionalItems");

            migrationBuilder.DropTable(
                name: "ServiceTables");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "SalesStatuses");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "CustomerTables");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "UserTables");

            migrationBuilder.DropTable(
                name: "DateTables");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
