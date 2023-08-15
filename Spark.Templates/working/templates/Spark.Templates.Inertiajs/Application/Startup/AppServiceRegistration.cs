using Spark.Templates.Inertiajs.Application.Database;
using Spark.Templates.Inertiajs.Application.Events.Listeners;
using Spark.Templates.Inertiajs.Application.Models;
using Spark.Templates.Inertiajs.Application.Services.Auth;
using Spark.Templates.Inertiajs.Application.Services;
using Spark.Library.Database;
using Spark.Library.Logging;
using Coravel;
using InertiaCore.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Spark.Library.Auth;
using Spark.Templates.Inertiajs.Application.Jobs;
using Spark.Library.Mail;

namespace Spark.Templates.Inertiajs.Application.Startup
{
    public static class AppServiceRegistration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
            services.AddInertia();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddCustomServices();
            services.AddDatabase<DatabaseContext>(config);
            services.AddLogger(config);
            services.AddAuthorization(config, new string[] { CustomRoles.Admin, CustomRoles.User });
            services.AddAuthentication<IAuthValidator>(config);
            services.AddJobServices();
            services.AddScheduler();
            services.AddQueue();
            services.AddEventServices();
            services.AddEvents();
            services.AddMailer(config);
            return services;
        }

        private static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // add custom services
            services.AddScoped<UsersService>();
            services.AddScoped<RolesService>();
            services.AddScoped<IAuthValidator, AuthValidator>();
            services.AddScoped<AuthService>();
            return services;
        }

        private static IServiceCollection AddEventServices(this IServiceCollection services)
        {
            // add custom events here
            services.AddTransient<EmailNewUser>();
            return services;
        }

        private static IServiceCollection AddJobServices(this IServiceCollection services)
        {
            // add custom background tasks here
            services.AddTransient<ExampleJob>();
            return services;
        }
    }
}
