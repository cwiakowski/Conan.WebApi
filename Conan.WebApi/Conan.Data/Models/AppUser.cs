using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Conan.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Messages = new List<Message>();
        }

        public virtual ICollection<Message> Messages { get; set; }

        public string GetName() => Email;
    }
}