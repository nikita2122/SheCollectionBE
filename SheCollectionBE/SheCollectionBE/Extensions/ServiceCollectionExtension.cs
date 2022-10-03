using SheCollectionBE.Services.BookingService;
using SheCollectionBE.Services.ProductService;
using SheCollectionBE.Services.SizeService;
using SheCollectionBE.Services.ProductSizeService;
using SheCollectionBE.Services.ColourService;
using SheCollectionBE.Services.ProductColourService;
using SheCollectionBE.Services.ProductTypeService;
using SheCollectionBE.Services.CategoryService;
using SheCollectionBE.Services.UserService;
using SheCollectionBE.Services.AuthService;
using SheCollectionBE.Services.CartService;
using SheCollectionBE.Services.CartLineService;
using SheCollectionBE.Services.OrderService;
using SheCollectionBE.Services.OrderLineService;
using SheCollectionBE.Services.OrderStatusService;
using SheCollectionBE.Services.CustomerService;
using SheCollectionBE.Services.TitleService;
using SheCollectionBE.Services.UserRoleService;
using SheCollectionBE.Services.EmailService;
using SheCollectionBE.Services.ServiceCategoryService;
using SheCollectionBE.Services.ServiceTypeService;
using SheCollectionBE.Services.ServicesService;
using SheCollectionBE.Services.ScheduleService;
using SheCollectionBE.Services.EmployeeService;
using SheCollectionBE.Services.EmployeeScheduleService;
using SheCollectionBE.Services.EmployeeTypeService;
using SheCollectionBE.Services.TimeSlotService;
using SheCollectionBE.Services.BookingStatusService;

namespace SheCollectionBE.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISizeService, SizeService>();
            services.AddTransient<IProductSizeService, ProductSizeService>();
            services.AddTransient<IColourService, ColourService>();
            services.AddTransient<IProductColourService, ProductColourService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartLineService, CartLineService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderLineService, OrderLineService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ITitleService, TitleService>();
            services.AddTransient<IBookingStatusService, BookingStatusService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IServiceCategoryService ,ServiceCategoryService >();
            services.AddTransient<IServiceTypeService ,ServiceTypeService >();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IEmployeeTypeService, EmployeeTypeService>();
            services.AddTransient<IEmployeeScheduleService, EmployeeScheduleService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<ITimeSlotService, TimeSlotService>();

            return services;
        }
    }
}
