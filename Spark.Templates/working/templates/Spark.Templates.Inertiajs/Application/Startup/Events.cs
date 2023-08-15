using Spark.Templates.Inertiajs.Application.Events.Listeners;
using Spark.Templates.Inertiajs.Application.Events;
using Coravel.Events.Interfaces;
using Coravel;

namespace Spark.Templates.Inertiajs.Application.Startup
{
    public static class Events
    {
        public static IServiceProvider RegisterEvents(this IServiceProvider services)
        {
            IEventRegistration registration = services.ConfigureEvents();

            // add events and listeners here
            registration
                .Register<UserCreated>()
                .Subscribe<EmailNewUser>();

            return services;
        }
    }
}
