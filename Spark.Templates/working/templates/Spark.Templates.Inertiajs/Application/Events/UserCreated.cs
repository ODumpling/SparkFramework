using Spark.Templates.Inertiajs.Application.Models;
using Coravel.Events.Interfaces;

namespace Spark.Templates.Inertiajs.Application.Events
{

    public class UserCreated : IEvent
    {
        public User User { get; set; }

        public UserCreated(User user)
        {
            this.User = user;
        }
    }
}
