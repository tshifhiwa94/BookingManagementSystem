using BookingManagement.Data;
using BookingManagement.Domain.Users;
using BookingManagement.Repositories;
using BookingManagement.Repositories.BaseRepositories;
using BookingManagement.Repositories.BaseRepository;
using BookingManagement.Repositories.BranchRepository;
using BookingManagement.Repositories.DepartmentsRepository;
using BookingManagement.Repositories.NotificationsRepository;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Repositories.ResourcesRepository;
using BookingManagement.Repositories.ServicesRepository;
using BookingManagement.Repositories.UserRepository;
using BookingManagement.Services.AddressService;
using BookingManagement.Services.AuthService;
using BookingManagement.Services.BranchService;
using BookingManagement.Services.DepartmentsService;
using BookingManagement.Services.PersonService;
using BookingManagement.Services.ResourcesService;
using BookingManagement.Services.ServicesService;
using BookingManagement.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace BookingManagement.Extensions
{
    public static class DomainExtensions
    {
        public static void BookingManagentDomain(this IServiceCollection services, IConfiguration configuration)
        {

            // Register repositories here
            //services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceRequestRepository, ResourceRequestRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();


            // Register services here
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IResourceService, ResourceService>();
            //services.AddScoped<IResourceRequestService, ResourceRequestService>();
            services.AddScoped<IServiceService, ServiceService>();
            //services.AddScoped<IServiceRequestService, ServiceRequestService>();
            //services.AddScoped<INotificationService, NotificationService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // 📦 Controller and JSON settings
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });


            services.AddDbContext<BookManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



            // 📦 Register Identity User
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BookManagementDbContext>()
                .AddDefaultTokenProviders();
            // Register SignIn Manager
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<RoleManager<IdentityRole>>();

            // 📦 Register HttpContext accessor (needed for user claim access)
            services.AddHttpContextAccessor();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["AppSettings:Issuer"],
                        ValidAudience = configuration["AppSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!))
                    };
                });

        }
    }
}
