using System;
using System.ComponentModel.DataAnnotations;

namespace Conan.Data.Models
{
    public class Message
    {
        public int Id {get; set;}
        [Required]
        public string UserName {get;set;}
        [Required]
        public string Text {get; set;}
        public DateTime Date { get; set; }
        public string SenderID { get; set; }
        public virtual AppUser Sender { get; set; }
        public string ReceiverID { get; set; }
        public virtual AppUser Receiver { get; set; }
    }
}