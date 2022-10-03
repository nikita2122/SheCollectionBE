using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SheCollectionBE.DB_Models;
using SheCollectionBE.Helpers;
using SheCollectionBE.Models;

namespace SheCollectionBE.Context
{
    // NOTE: Scaffolded by "Scaffold-DbContext" in PM console (DB First Approach)
    public partial class SheCollectionContext : DbContext
    {
        public SheCollectionContext(DbContextOptions<SheCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<CustomerTable> CustomerTables { get; set; }
        public DbSet<DateTable> DateTables { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<NotificationTable> NotificationTables { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderTable> OrderTables { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }
        public DbSet<ProductPromotionalItemDiscount> ProductPromotionalItemDiscounts { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PromotionalItem> PromotionalItems { get; set; }
        public DbSet<PromotionalItemDiscount> PromotionalItemDiscounts { get; set; }
        public DbSet<QuantityOnHand> QuantityOnHands { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesLine> SalesLines { get; set; }
        public DbSet<SalesStatus> SalesStatuses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleTimeslot> ScheduleTimeslots { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServicePromotionalItemDiscount> ServicePromotionalItemDiscounts { get; set; }
        public DbSet<ServiceTable> ServiceTables { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<StockTake> StockTakes { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<EmailResetModel> EmailResetTable { get; set; }
        public DbSet<DbBackup> DbBackups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var lst = new List<UserRole>()
            {
                new UserRole() { UserRoleId = 1, UserRoleName = "Admin" },
                new UserRole() { UserRoleId = 2, UserRoleName = "Customer" },
            };
            modelBuilder.Entity<UserRole>().HasData(lst);
            modelBuilder.Entity<UserTable>().HasData(
                new UserTable() { UserName = "Admin", UserPassword = Hasher.HashPassword("Secret123$$"), UserTableId = 10, UserRoleId = 1, Picture = "" }
                );
            modelBuilder.Entity<Title>().HasData(
               new Title() { TitleId = 1, TitleName = "Mr" },
               new Title() { TitleId = 2, TitleName = "Mrs" },
               new Title() { TitleId = 3, TitleName = "Dr" },
               new Title() { TitleId = 4, TitleName = "Ms" }
               );
            modelBuilder.Entity<Size>().HasData(
                new Size() { SizeId = 1, SizeName = "S" },
                new Size() { SizeId = 2, SizeName = "M" },
                new Size() { SizeId = 3, SizeName = "L" },
                new Size() { SizeId = 4, SizeName = "XL" },
                new Size() { SizeId = 5, SizeName = "XXL" }
                );

            modelBuilder.Entity<Colour>().HasData(
                new Colour() { ColourId = 1, ColourName = "RED" },
                new Colour() { ColourId = 2, ColourName = "GREEN" },
                new Colour() { ColourId = 3, ColourName = "BLUE" },
                new Colour() { ColourId = 4, ColourName = "BROWN" }
                );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory() { ProductCategoryId = 1, ProductCategoryName = "hair care", ProductCategoryDescription = "hair care items", imgUrl = "" },
                new ProductCategory() { ProductCategoryId = 2, ProductCategoryName = "nail care", ProductCategoryDescription = "nail care items", imgUrl = "" }
                );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType() { ProductTypeId = 1, ProductCategoryId = 1, ProductTypeName = "Single use", imgUrl = "" }
                );
            modelBuilder.Entity<ServiceCategory>().HasData(
                new ServiceCategory() { ServiceCategoryId = 1, ServiceCategoryName = "Hair platting", ServiceCategoryDescription = "Braiding or extending", imgUrl = "" }
                );
            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType() { ServiceTypeId = 1, ServiceCategoryId = 1, ServiceTypeName = "Hair extending", imgUrl = "" },
                new ServiceType() { ServiceTypeId = 2, ServiceCategoryId = 1, ServiceTypeName = "Hair braiding", imgUrl = "" }
                );

            modelBuilder.Entity<ServiceTable>().HasData(
               new ServiceTable() { ServiceTableId = 1, ServiceTypeId = 1, ServiceName = "Hair extending", ServiceDescription = " ext", ServicePicture = "", ServicePrice = 499.99m, DurationMax = 10, DurationMin = 5 }
               );
            modelBuilder.Entity<EmployeeType>().HasData(
               new EmployeeType() { EmployeeTypeId = 1, EmployeeTypeDescription = "hair dresser", EmployeeTypeName = "braider" }
               );

            modelBuilder.Entity<Employee>().HasData(
               new Employee() { EmployeeId = 1, UserId = 10, EmployeeEmail = "a@gmail.com", EmployeeName = "Admin", EmployeeNumber = "10199", EmployeeSurname = "Admin", EmployeeTypeId = 1 }
               );
            modelBuilder.Entity<BookingStatus>().HasData(
               new BookingStatus() { BookingStatusId = 1, BookingStatusName = "Upcoming" }
               );
            base.OnModelCreating(modelBuilder);
        }
    }
}
