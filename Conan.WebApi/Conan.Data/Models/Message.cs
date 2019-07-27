using System;
using System.ComponentModel.DataAnnotations;

namespace Conan.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string Body { get; set; }

        public virtual AppUser FromUser { get; set; }
        public virtual AppUser ToUser { get; set; }
    }
}