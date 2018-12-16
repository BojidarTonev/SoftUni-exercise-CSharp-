using System.Collections.Generic;
using TorshiaWebApp.Models.Enums;

namespace TorshiaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Reprots = new List<Report>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public virtual List<Report> Reprots { get; set; }
    }
}
